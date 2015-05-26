using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Ninject;
using Realm.Admin.DAL;
using Realm.DAL;
using Realm.DAL.Enumerations;
using Realm.DAL.Models;
using Realm.Edit.Builders;
using Realm.Edit.Editor;
using Realm.Edit.EditorControls;
using Realm.Edit.Extensions;
using Realm.Edit.Properties;
using Realm.Edit.Tags;
using Realm.Library.Common;
using Color = System.Drawing.Color;

namespace Realm.Edit
{
    public partial class MainForm : Form
    {
        public bool Loading { get; private set; }
        public TreeNode DragNode { get; private set; }
        public TreeView BrowseTree { get { return treeBrowse; } }
        public ContextMenuStrip BrowseFolder { get { return contextBrowseFolder; } }
        public ToolStripProgressBar ProgressStatus { get { return progressStatus; } }

        public MainForm()
        {
            InitializeComponent();
            Loading = true;
        }

        private void MainFormLoad(object sender, EventArgs e)
        {
            Show();
            Loading = true;
            InitAll();
            Loading = false;
        }

        private void InitAll()
        {
            try
            {
                SystemTags.Init();

                treeBrowse.Nodes.Clear();

                imagesSystem.Images.Clear();
                imagesSystem.Images.Add("openFolder", ShellIcon.extractIconFromFile("shell32.dll", 4, false));
                foreach (var builder in EditorFactory.Builders.Values)
                    imagesSystem.Images.Add(builder.DisplayName, builder.Icon);

                treeBrowse.BeginUpdate();
                treeBrowse.ImageList = imagesSystem;
                tabContent.ImageList = imagesSystem;

                var filterText = txtFilter.Text.Trim();
                Program.MainForm.ProgressStatus.Minimum = 0;
                Program.MainForm.ProgressStatus.Maximum = EditorFactory.Builders.Count;
                Program.MainForm.ProgressStatus.Value = Program.MainForm.ProgressStatus.Minimum;

                // Initialize the interface with the registered editors
                foreach (var builder in EditorFactory.Builders.Values)
                {
                    if (!builder.IsVisible) continue;

                    IRealmDbContext dbContext = Program.NinjectKernel.Get<IRealmDbContext>();
                    var classList = dbContext.SystemClasses
                        .Where(x => x.SystemType == builder.SystemType)
                        .Where(x => x.ParentClassId == null)
                        .ToList();

                    if (classList.Count() > 1)
                        throw new EditorException("Multiple parent classes for system [" + builder.SystemType + "]");

                    if (!classList.Any())
                        throw new EditorException("No parent class for system [" + builder.SystemType + "]");

                    int classId = classList.First().Id;

                    var rootNode = new TreeNode(builder.DisplayPlural);
                    var browseInfo = new EditorBrowseInfo(builder.SystemType, builder.DisplayName, classId, 0);
                    rootNode.Tag = browseInfo;
                    rootNode.ImageKey = Resources.ClosedFolderImageKey;
                    rootNode.ContextMenuStrip = contextBrowseFolder;

                    rootNode.SetupBrowseTree(builder, !String.IsNullOrEmpty(filterText), filterText);
                    if (!builder.HasDelete())
                    {
                        // This will disable for everything...?
                        // contextBrowseNode.Items[0].Enabled = false;
                    }
                    builder.PopulateBrowseNode(rootNode, browseInfo.ClassId, contextBrowseNode, txtFilter.Text.Trim());
                    treeBrowse.Nodes.Add(rootNode);
                    Program.MainForm.ProgressStatus.Value += 1;
                }

                treeBrowse.EndUpdate();
                Application.DoEvents();
                Program.MainForm.SetStatusMessage(EditorFactory.Builders.Count + " builders initialized.");
                Program.Log.InfoFormat(Resources.TEXT_BUILDER_INIT_SUMMARY.Replace("{0}",
                    EditorFactory.Builders.Count.ToString()));
            }
            catch (Exception ex)
            {
                Program.Log.Error(ex.Message, ex);
            }
        }

        public void SetStatusMessage(string msg)
        {
            Program.Log.Info(msg);
            lblStatus.Text = msg;
            lblStatus.BackColor = !String.IsNullOrEmpty(msg.Trim()) ? Color.LightBlue : Color.Empty;
        }

        public void SetWarningMessage(string msg)
        {
            Program.Log.Warn(msg);
            lblStatus.Text = msg;
            lblStatus.BackColor = !String.IsNullOrEmpty(msg.Trim()) ? Color.Yellow : Color.Empty;
        }

        public void SetErrorMessage(string msg)
        {
            Program.Log.Error(msg);
            lblStatus.Text = msg;
            lblStatus.BackColor = !String.IsNullOrEmpty(msg.Trim()) ? Color.Red : Color.Empty;
        }

        public void OpenTab(EditorBrowseInfo browseInfo, bool openCopy, bool makeDirty)
        {
            if (browseInfo == null)
                throw new ArgumentNullException("browseInfo", Resources.NullParameterErrorMessage);

            TabPage page = null;

            // If we are not opening a copy, always create a new page and do not use an already open page.
            if (!openCopy)
                page = FindTab(EnumerationExtensions.GetEnum<SystemTypes>(browseInfo.SystemType), browseInfo.Id);

            if (page != null)
                tabContent.SelectedTab = page;
            else
            {
                var builder = EditorFactory.Builders[EnumerationExtensions.GetEnum<SystemTypes>(browseInfo.SystemType)];
                if (builder.HasEditor())
                {
                    // Create a new edit control based on the selected node 
                    var editControl =
                        EditorFactory.Create(EnumerationExtensions.GetEnum<SystemTypes>(browseInfo.SystemType),
                            browseInfo.ClassId);

                    // Initialize the new control with the content that was dclicked
                    editControl.InitContent(browseInfo.Id);
                    string tabName = editControl.ControlName;
                    if (openCopy)
                    {
                        editControl.MakeCopy();
                        tabName = "*" + editControl.ControlName + "*";
                    }
                    else if (makeDirty)
                    {
                        editControl.MakeDirty();
                        tabName = "*" + editControl.ControlName + "*";
                    }

                    tabName = "[" + editControl.Id + "] " + tabName;

                    CreateContentTab(tabName, editControl);
                }
            }
        }

        public bool CloseTabs(IList tabPages, bool promptSave)
        {
            if (tabPages == null)
                throw new ArgumentNullException("tabPages", Resources.NullParameterErrorMessage);

            // Prompt to save all of the dirty tabs first
            // If there are any cancels, nobody closes
            bool closeAll = true;
            if (promptSave)
            {
                foreach (TabPage tabPage in tabPages.OfType<TabPage>()
                    .Where(x => x.Controls.Count > 0))
                {
                    var editorControl = tabPage.Controls[0] as BaseEditorControl;
                    if (editorControl == null || !editorControl.IsDirty) continue;
                    if (editorControl.PromptSave() != DialogResult.Cancel) continue;

                    closeAll = false;
                    break;
                }
            }

            // If everything is ok, close them all
            if (closeAll)
            {
                foreach (TabPage tabPage in tabPages)
                {
                    tabContent.TabPages.Remove(tabPage);
                    var editorControl = tabPage.Controls[0] as BaseEditorControl;
                    if (editorControl != null) editorControl.Dispose();
                }
            }

            return closeAll;
        }

        public TabPage FindTab(SystemTypes systemType, long id)
        {
            foreach (TabPage page in tabContent.TabPages.OfType<TabPage>()
                .Where(x => x.Controls.Count > 0))
            {
                var editControl = page.Controls[0] as BaseEditorControl;
                if (editControl != null
                    && editControl.SystemType == systemType
                    && editControl.Id == id)
                    return page;
            }

            return null;
        }

        public void CloseTab(TabPage page, bool promptSave)
        {
            var pageList = new List<TabPage> { page };
            CloseTabs(pageList, promptSave);
        }

        private void CreateContentTab(string name, BaseEditorControl control)
        {
            tabContent.SuspendLayout();
            var newPage = new TabPage(name)
            {
                Padding = new Padding(6, 6, 6, 6)
            };
            newPage.Controls.Add(control);

            // This works around a bug it seems.  
            // You can't set the ImageKey property of a dynamic tab.  
            // Yet you can set the ImageIndex
            var keyIndex = 0;
            if (EditorFactory.Builders.ContainsKey(control.SystemType))
                keyIndex = tabContent.ImageList.Images.IndexOfKey(EditorFactory.Builders[control.SystemType].DisplayName);
            newPage.ImageIndex = keyIndex;

            control.Dock = DockStyle.Fill;
            tabContent.TabPages.Add(newPage);
            tabContent.SelectedTab = newPage;
            tabContent.ResumeLayout(true);

            control.DirtyChanged += EditorControlDirtyChanged;
        }

        private void EditorControlDirtyChanged(object sender, EventArgs e)
        {
            var editorControl = sender as BaseEditorControl;
            if (editorControl == null) return;

            foreach (var tabPage in tabContent.TabPages.Cast<TabPage>()
                .Where(tabPage => tabPage.Controls[0].Equals(editorControl)))
            {
                tabPage.Text = editorControl.IsDirty
                                   ? Resources.TEXT_DIRTY_NODE.Replace("{0}", editorControl.ControlName)
                                   : editorControl.ControlName;

                tabPage.Text = Resources.TEXT_NODE.Replace("{0}", editorControl.Id.ToString()).Replace("{1}", tabPage.Text);
                break;
            }
        }

        

        private void RefreshTreeView()
        {
            IRealmDbContext dbContext = Program.NinjectKernel.Get<IRealmDbContext>();

            treeBrowse.Nodes.Clear();
            treeBrowse.ImageList.Images.Clear();

            string filterText = txtFilter.Text.Trim();
            Program.MainForm.ProgressStatus.Minimum = 0;
            Program.MainForm.ProgressStatus.Maximum = EditorFactory.Builders.Count;
            Program.MainForm.ProgressStatus.Value = Program.MainForm.ProgressStatus.Minimum;

            // Initialize the interface with the registered editors
            int iconIndex = 0;
            foreach (EditorBuilder builder in EditorFactory.Builders.Values)
            {
                if (!builder.IsVisible) continue;

                treeBrowse.ImageList.Images.Add(builder.Icon);

                var classList = dbContext.SystemClasses
                    .Where(x => x.SystemType == builder.SystemType)
                    .Where(x => x.ParentClassId == null);

                if (classList.Count() > 1)
                    throw new EditorException("Multiple parent classes for system [" + builder.SystemType + "]");

                if (!classList.Any())
                    throw new EditorException("No parent class for system [" + builder.SystemType + "]");

                int classId = classList.ToList().First().Id;

                var rootNode = new TreeNode(builder.DisplayPlural);
                var browseInfo = new EditorBrowseInfo(builder.SystemType, builder.DisplayName, classId, 0);
                rootNode.Tag = browseInfo;
                rootNode.ImageKey = "closedFolder";
                rootNode.ContextMenuStrip = contextBrowseFolder;

                rootNode.SetupBrowseTree(builder, !String.IsNullOrEmpty(filterText), filterText);
                if (!builder.HasDelete())
                {
                    // This will disable for everything...?
                    // contextBrowseNode.Items[0].Enabled = false;
                }
                builder.PopulateBrowseNode(rootNode, browseInfo.ClassId, contextBrowseNode, txtFilter.Text.Trim());
                treeBrowse.Nodes.Add(rootNode);
                Program.MainForm.ProgressStatus.Value += 1;

                iconIndex++;
            }
        }

        private void SaveTabPage(Control tabPage)
        {
            var editControl = tabPage.Controls[0] as BaseEditorControl;
            if (editControl == null || !editControl.Save()) return;

            var builder = EditorFactory.Builders[editControl.SystemType];
            var browseInfo = editControl.BrowseInfo;
            browseInfo.Id = 0;  // Change to its parent node
            var node = treeBrowse.FindTreeNode(browseInfo);

            if (builder != null && node != null)
                builder.PopulateBrowseNode(node, editControl.ClassId, contextBrowseNode, txtFilter.Text.Trim());
        }

        private void TreeBrowseNodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                // Make sure the node that was right clicked is selected
                treeBrowse.SelectedNode = e.Node;
            }
        }

        private void TreeBrowseBeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            var browseInfo = e.Node.Tag as EditorBrowseInfo;
            if (browseInfo == null) return;

            var builder = EditorFactory.Builders[(SystemTypes)browseInfo.SystemType];
            foreach (TreeNode node in e.Node.Nodes)
            {
                browseInfo = node.Tag as EditorBrowseInfo;
                if (browseInfo == null) continue;
                if (browseInfo.Id <= 0)
                    builder.PopulateBrowseNode(node, browseInfo.ClassId, contextBrowseNode, txtFilter.Text.Trim());
            }
        }

        private void TreeBrowseNodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            e.Node.OpenContentNode();
        }

        private void MnuCloseClick(object sender, EventArgs e)
        {
            int tabIndex = tabContent.SelectedIndex;
            if (tabIndex < 0) return;
            CloseTab(tabContent.SelectedTab, true);

            if (tabIndex > 0)
                --tabIndex;

            if (tabContent.TabPages.Count > 0)
                tabContent.SelectedIndex = tabIndex;
        }

        private void MnuCloseAllClick(object sender, EventArgs e)
        {
            CloseTabs(tabContent.TabPages, true);
        }

        private void MnuExitClick(object sender, EventArgs e)
        {
            if (CloseTabs(tabContent.TabPages, true))
                Application.Exit();
        }

        private void MnuSaveClick(object sender, EventArgs e)
        {
            // Only save the active tab
            // To save all open content, see SaveAll

            if (tabContent.SelectedIndex >= 0)
            {
                SaveTabPage(tabContent.SelectedTab);
            }
        }

        private void MnuSaveAll(object sender, EventArgs e)
        {
            foreach (TabPage tabPage in tabContent.TabPages)
            {
                SaveTabPage(tabPage);
            }
        }

        private void TreeBrowseMouseMove(object sender, MouseEventArgs e)
        {
            if (DragNode == null)
                return;

            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                treeBrowse.DoDragDrop(DragNode, DragDropEffects.Link);
            }

            DragNode = null;
        }

        private void TreeBrowseMouseDown(object sender, MouseEventArgs e)
        {
            DragNode = treeBrowse.GetNodeAt(e.Location);
            if (DragNode == null) return;

            var browseInfo = DragNode.Tag as EditorBrowseInfo;
            if (browseInfo != null && browseInfo.Id <= 0)
                DragNode = null;
        }

        private void MnuFileDropDownOpening(object sender, EventArgs e)
        {
            mnuSave.Enabled = false;
            if (tabContent.SelectedIndex < 0) return;

            //BaseEditorControl editControl = tabContent.SelectedTab.Controls[0] as BaseEditorControl;
            mnuSave.Enabled = true;
        }

        private void ContextBrowseOpening(object sender, CancelEventArgs e)
        {
            var menuStrip = sender as ContextMenuStrip;
            if (menuStrip == null) return;

            var tv = menuStrip.SourceControl as TreeView;
            if (tv == null || !tv.Equals(treeBrowse) || treeBrowse.SelectedNode == null) return;

            var browseInfo = (treeBrowse.SelectedNode.Tag as EditorBrowseInfo);
            if (browseInfo == null) return;

            var builder = EditorFactory.Builders[(SystemTypes)browseInfo.SystemType];
            if (builder == null) return;

            mnuBrowseNewNode.Text = Resources.TEXT_NEW_NODE.Replace("{0}", builder.DisplayName);
            var topNode = (treeBrowse.SelectedNode.Parent == null);
            mnuBrowseNewNode.Enabled = builder.HasEditor() && builder.HasCreate();

            mnuBrowseDeleteClass.Enabled = (!topNode && treeBrowse.SelectedNode.Nodes.Count == 0 && builder.HasDelete());
            mnuBrowseRenameClass.Enabled = !topNode;
        }

        private void MnuBrowseNewNodeClick(object sender, EventArgs e)
        {
            if (treeBrowse.SelectedNode == null) return;

            // Create a new edit control based on the selected node 
            var browseInfo = treeBrowse.SelectedNode.Tag as EditorBrowseInfo;
            if (browseInfo == null) return;

            var builder = EditorFactory.Builders[(SystemTypes)browseInfo.SystemType];
            if (builder == null || !builder.HasCreate()) return;

            var editControl = EditorFactory.Create((SystemTypes)browseInfo.SystemType, browseInfo.ClassId);
            editControl.InitNew();

            // Throw the new edit control into its own tab
            CreateContentTab("[??] " + editControl.ControlName, editControl);
        }

        private void MnuBrowseNewClassClick(object sender, EventArgs e)
        {
            if (treeBrowse.SelectedNode == null) return;
            var browseInfo = treeBrowse.SelectedNode.Tag as EditorBrowseInfo;
            if (browseInfo == null) return;

            IRealmDbContext dbContext = Program.NinjectKernel.Get<IRealmDbContext>();

            var parentClass = dbContext.SystemClasses.FirstOrDefault(x => x.Id == browseInfo.ClassId);
            if (parentClass == null)
                throw new EditorException("Parent Class [" + browseInfo.ClassId + "] cannot be found.");

            var newClass = new SystemClass
            {
                Id = dbContext.SystemClasses.Max(x => x.Id) + 1,
                Name = "<New Class>",
                SystemType = browseInfo.GetSystemType(),
                ParentClassId = parentClass.Id
            };

            dbContext.SystemClasses.Add(newClass);
            dbContext.SaveChanges();

            int classId = newClass.Id;
            if (classId <= 0)
            {
                Program.Log.ErrorFormat("Unable to create new Class {0} for System Type {1}",
                    browseInfo.ClassId, browseInfo.SystemType);
                return;
            }

            treeBrowse.SelectedNode.SetupBrowseTree(EditorFactory.Builders[(SystemTypes) browseInfo.SystemType], true,
                txtFilter.Text.Trim());

            var nodes = treeBrowse.SelectedNode.Nodes.Find("class_" + classId, false);
            if (nodes.Length != 1) return;

            treeBrowse.SelectedNode = nodes[0];
            treeBrowse.LabelEdit = true;
            treeBrowse.SelectedNode.BeginEdit();
        }

        private void TreeBrowseBeforeLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            var browseInfo = treeBrowse.SelectedNode.Tag as EditorBrowseInfo;
            if (browseInfo != null && browseInfo.Id > 0)
                e.CancelEdit = true;
        }

        private void TreeBrowseAfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            if (treeBrowse.SelectedNode == null || e.Label == null) return;
            var browseInfo = treeBrowse.SelectedNode.Tag as EditorBrowseInfo;
            if (browseInfo == null) return;

            IRealmDbContext dbContext = Program.NinjectKernel.Get<IRealmDbContext>();
            var foundClass = dbContext.SystemClasses.FirstOrDefault(x => x.Id == browseInfo.ClassId);
            if (foundClass == null) return;

            if (e.Label.Length > 100)
            {
                e.CancelEdit = true;
                Program.MainForm.SetWarningMessage("Class Name exceeds the maximum length of 100 characters.");
                return;
            }

            foundClass.Name = e.Label;

            try
            {
                dbContext.SaveChanges();
            }
            catch (Exception)
            {
                Program.Log.ErrorFormat("Unable to rename Class {0} to {1}", foundClass.Id, e.Label);
            }
        }

        private void MnuBrowseRenameClassClick(object sender, EventArgs e)
        {
            if (treeBrowse.SelectedNode == null) return;
            treeBrowse.LabelEdit = true;
            treeBrowse.SelectedNode.BeginEdit();
        }

        private void MnuBrowseDeleteClassClick(object sender, EventArgs e)
        {
            if (treeBrowse.SelectedNode == null) return;

            var browseInfo = treeBrowse.SelectedNode.Tag as EditorBrowseInfo;
            if (browseInfo == null) return;

            IRealmDbContext dbContext = Program.NinjectKernel.Get<IRealmDbContext>();
            var foundClass = dbContext.SystemClasses.FirstOrDefault(x => x.Id == browseInfo.ClassId);
            if (foundClass == null) return;

            try
            {
                dbContext.SystemClasses.Remove(foundClass);
                dbContext.SaveChanges();
            }
            catch (Exception)
            {
                Program.Log.ErrorFormat("Unable to delete Class {0}", browseInfo.ClassId);
                return;
            }

            treeBrowse.SelectedNode.Remove();
        }

        private void UndoToolStripMenuItemClick(object sender, EventArgs e)
        {
            //            Program.History.UndoAction();
        }

        private void RedoToolStripMenuItemClick(object sender, EventArgs e)
        {
            //            Program.History.RedoAction();
        }

        private void AboutToolStripMenuItemClick(object sender, EventArgs e)
        {
            var aboutForm = new AboutBox();
            aboutForm.ShowDialog();
        }

        private void MnuBrowseDeleteNodeClick(object sender, EventArgs e)
        {
            treeBrowse.SelectedNode.DeleteBrowseNode(txtFilter.Text);
        }

        private void TreeBrowseKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                treeBrowse.SelectedNode.DeleteBrowseNode(txtFilter.Text);
            }
        }

        private void ProcessTreeBrowseDrag(DragEventArgs e, bool aSetValue)
        {
            var clientPt = treeBrowse.PointToClient(new Point(e.X, e.Y));  //screen coordinates
            var hitInfo = treeBrowse.HitTest(clientPt);
            if (hitInfo.Node == null) return;

            var targetBrowseInfo = hitInfo.Node.Tag as EditorBrowseInfo;
            if (targetBrowseInfo == null) return;

            var targetClassNode = hitInfo.Node;
            var sourceNode = (TreeNode)e.Data.GetData("System.Windows.Forms.TreeNode", true);
            if (sourceNode != null)
            {
                var sourceClassNode = sourceNode.Parent;
                var sourceBrowseInfo = sourceNode.Tag as EditorBrowseInfo;
                if (sourceBrowseInfo == null) return;

                // Make sure the systems match, the target is a folder, and its not already the parent of the sourceNode
                if (sourceBrowseInfo.SystemType == targetBrowseInfo.SystemType
                    && targetBrowseInfo.Id == 0 && sourceNode.Parent != hitInfo.Node)
                {
                    e.Effect = DragDropEffects.Link;
                    if (aSetValue)
                    {
                        var builder = EditorFactory.Builders[(SystemTypes)sourceBrowseInfo.SystemType];
                        builder.Move(sourceBrowseInfo.GetSystemType(), sourceBrowseInfo.Id, targetBrowseInfo.ClassId);

                        if (sourceClassNode.Level == targetClassNode.Level)
                        {
                            // The two can't possibly have a parent/child relations
                            targetClassNode.SetupBrowseTree(builder, true, txtFilter.Text.Trim());
                            sourceClassNode.SetupBrowseTree(builder, true, txtFilter.Text.Trim());

                            targetClassNode.Expand();
                            sourceClassNode.Expand();
                        }
                        else
                        {
                            TreeNode lowNode;
                            int hiClassId = 0;

                            if (sourceClassNode.Level < targetClassNode.Level)
                            {
                                lowNode = sourceClassNode;
                                hiClassId = targetBrowseInfo.ClassId;
                            }
                            else
                            {
                                lowNode = targetClassNode;
                                var editorBrowseInfo = sourceClassNode.Tag as EditorBrowseInfo;
                                if (editorBrowseInfo != null)
                                    hiClassId = editorBrowseInfo.ClassId;
                            }

                            // Find the root node of this system
                            TreeNode rootNode = targetClassNode;
                            while (rootNode.Parent != null)
                                rootNode = rootNode.Parent;

                            // Refresh the node close to the root first (this may remove the other node from the tree)
                            lowNode.SetupBrowseTree(builder, true, txtFilter.Text.Trim());
                            lowNode.Expand();

                            // Find the new node matches the deeper node
                            TreeNode hiNode = rootNode.FindNodeByClass(hiClassId);
                            if (hiNode != null)
                            {
                                hiNode.SetupBrowseTree(builder, true, txtFilter.Text.Trim());
                                hiNode.Expand();
                            }
                        }
                    }
                }
            }

            var targetBuilder = EditorFactory.Builders[(SystemTypes)targetBrowseInfo.SystemType];
            bool handled = targetBuilder.HandleCustomDrag(e, targetBrowseInfo, aSetValue);
            if (!aSetValue || !handled) return;

            if (targetBrowseInfo.Id != 0)
                targetClassNode = targetClassNode.Parent;

            targetClassNode.SetupBrowseTree(targetBuilder, true, txtFilter.Text.Trim());
            targetClassNode.Expand();
        }

        private void TreeBrowseDragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.None;    // Assume nothing will happen
            ProcessTreeBrowseDrag(e, false);
        }

        private void TreeBrowseDragDrop(object sender, DragEventArgs e)
        {
            ProcessTreeBrowseDrag(e, true);
        }

        private void MainFormFormClosing(object sender, FormClosingEventArgs e)
        {
            Settings.Default.Save();
        }

        private void TagEditorToolStripMenuItemClick(object sender, EventArgs e)
        {
            if (Loading) return;
            using (var tagForm = new TagEditorForm())
            {
                tagForm.ShowDialog(this);
            }
        }

        private void MnuBrowseOpenNodeClick(object sender, EventArgs e)
        {
            treeBrowse.SelectedNode.OpenContentNode();
        }

        private void MnuBrowseCopyNodeClick(object sender, EventArgs e)
        {
            treeBrowse.SelectedNode.OpenContentNode(true);
        }

        private void TxtFilterKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Return) return;
            Loading = false;
            InitAll();
        }

        private void BadNamesToolStripMenuItemClick(object sender, EventArgs e)
        {
            if (Loading) return;

            using (var badNames = new BadNames(Program.NinjectKernel.Get<IRealmAdminDbContext>()))
            {
                badNames.ShowDialog(this);
            }
        }

        private void CreateProductToolStripMenuItemClick(object sender, EventArgs e)
        {
            if (treeBrowse.SelectedNode == null) return;
            var browseInfo = treeBrowse.SelectedNode.Tag as EditorBrowseInfo;
            if (browseInfo == null || browseInfo.Id <= 0) return;

            var editControl = EditorFactory.Create((SystemTypes)browseInfo.SystemType, browseInfo.ClassId);
            editControl.InitContent(browseInfo.Id);
            browseInfo = editControl.MakeProduct();
            if (browseInfo != null)
            {
                OpenTab(browseInfo, false, true);
            }
        }

        private void MnuBrowseMoveClassClick(object sender, EventArgs e)
        {
            if (treeBrowse.SelectedNode == null) return;

            var browseInfo = treeBrowse.SelectedNode.Tag as EditorBrowseInfo;
            if (browseInfo == null) return;

            using (var classWindow = new ClassListWindow(browseInfo.ClassId))
            {
                classWindow.ShowDialog(this);
                RefreshTreeView();
            }
        }

        private void StringEditorToolStripMenuItemClick(object sender, EventArgs e)
        {
            if (Loading) return;

            using (var stringWindow = new StringTable())
            {
                stringWindow.ShowDialog(this);
            }
        }

        private void gameConstantsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Loading) return;

            // todo fix this
            //using (var constantsWindow = new GameConstants(Program.NinjectKernel.Get<IGameConstantDal>()))
            //{
            //    constantsWindow.ShowDialog(this);
            //}
        }
    }
}