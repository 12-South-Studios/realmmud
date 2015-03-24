namespace Realm.Edit
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.contextBrowseFolder = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuBrowseNewNode = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuBrowseNewClass = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuBrowseDeleteClass = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuBrowseMoveClass = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuBrowseRenameClass = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuBrowseCookData = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblUser = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblDatabase = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblServer = new System.Windows.Forms.ToolStripStatusLabel();
            this.progressStatus = new System.Windows.Forms.ToolStripProgressBar();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuClose = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCloseAll = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuSave = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tagEditorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.badNamesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stringEditorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gameConstantsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gameplayFormulaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reductionRatingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.regenRatingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.powerLevelRatingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.professionXpMultipliersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xpPerLevelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imagesSystem = new System.Windows.Forms.ImageList(this.components);
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.txtFilter = new System.Windows.Forms.TextBox();
            this.treeBrowse = new System.Windows.Forms.TreeView();
            this.contextBrowseNode = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuBrowseDeleteNode = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuBrowseOpenNode = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuBrowseCopyNode = new System.Windows.Forms.ToolStripMenuItem();
            this.createProductToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextSequenceMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuAddSystemNode = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAddCustomNode = new System.Windows.Forms.ToolStripMenuItem();
            this.tabContent = new Realm.Edit.CustomControls.AuraTab();
            this.contextBrowseFolder.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.contextBrowseNode.SuspendLayout();
            this.contextSequenceMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextBrowseFolder
            // 
            this.contextBrowseFolder.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuBrowseNewNode,
            this.toolStripSeparator2,
            this.mnuBrowseNewClass,
            this.mnuBrowseDeleteClass,
            this.mnuBrowseMoveClass,
            this.mnuBrowseRenameClass,
            this.toolStripSeparator5,
            this.mnuBrowseCookData});
            this.contextBrowseFolder.Name = "contextMenuStrip";
            this.contextBrowseFolder.Size = new System.Drawing.Size(148, 148);
            this.contextBrowseFolder.Opening += new System.ComponentModel.CancelEventHandler(this.ContextBrowseOpening);
            // 
            // mnuBrowseNewNode
            // 
            this.mnuBrowseNewNode.Name = "mnuBrowseNewNode";
            this.mnuBrowseNewNode.Size = new System.Drawing.Size(147, 22);
            this.mnuBrowseNewNode.Text = "New XXX";
            this.mnuBrowseNewNode.Click += new System.EventHandler(this.MnuBrowseNewNodeClick);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(144, 6);
            // 
            // mnuBrowseNewClass
            // 
            this.mnuBrowseNewClass.Name = "mnuBrowseNewClass";
            this.mnuBrowseNewClass.Size = new System.Drawing.Size(147, 22);
            this.mnuBrowseNewClass.Text = "New Class";
            this.mnuBrowseNewClass.Click += new System.EventHandler(this.MnuBrowseNewClassClick);
            // 
            // mnuBrowseDeleteClass
            // 
            this.mnuBrowseDeleteClass.Name = "mnuBrowseDeleteClass";
            this.mnuBrowseDeleteClass.Size = new System.Drawing.Size(147, 22);
            this.mnuBrowseDeleteClass.Text = "Delete Class";
            this.mnuBrowseDeleteClass.Click += new System.EventHandler(this.MnuBrowseDeleteClassClick);
            // 
            // mnuBrowseMoveClass
            // 
            this.mnuBrowseMoveClass.Name = "mnuBrowseMoveClass";
            this.mnuBrowseMoveClass.Size = new System.Drawing.Size(147, 22);
            this.mnuBrowseMoveClass.Text = "Move Class";
            this.mnuBrowseMoveClass.Click += new System.EventHandler(this.MnuBrowseMoveClassClick);
            // 
            // mnuBrowseRenameClass
            // 
            this.mnuBrowseRenameClass.Name = "mnuBrowseRenameClass";
            this.mnuBrowseRenameClass.Size = new System.Drawing.Size(147, 22);
            this.mnuBrowseRenameClass.Text = "Rename Class";
            this.mnuBrowseRenameClass.Click += new System.EventHandler(this.MnuBrowseRenameClassClick);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(144, 6);
            // 
            // mnuBrowseCookData
            // 
            this.mnuBrowseCookData.Name = "mnuBrowseCookData";
            this.mnuBrowseCookData.Size = new System.Drawing.Size(147, 22);
            // 
            // statusStrip1
            // 
            this.statusStrip1.AllowMerge = false;
            this.statusStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblUser,
            this.lblDatabase,
            this.lblServer,
            this.progressStatus,
            this.lblStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 609);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.statusStrip1.Size = new System.Drawing.Size(1025, 24);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 10;
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = false;
            this.lblUser.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.lblUser.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.lblUser.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(40, 19);
            this.lblUser.Text = "user";
            // 
            // lblDatabase
            // 
            this.lblDatabase.AutoSize = false;
            this.lblDatabase.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.lblDatabase.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.lblDatabase.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.lblDatabase.Name = "lblDatabase";
            this.lblDatabase.Size = new System.Drawing.Size(100, 19);
            this.lblDatabase.Text = "database";
            // 
            // lblServer
            // 
            this.lblServer.AutoSize = false;
            this.lblServer.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.lblServer.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.lblServer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.lblServer.Name = "lblServer";
            this.lblServer.Size = new System.Drawing.Size(250, 19);
            this.lblServer.Text = "ip addr";
            // 
            // progressStatus
            // 
            this.progressStatus.AutoSize = false;
            this.progressStatus.Name = "progressStatus";
            this.progressStatus.Size = new System.Drawing.Size(200, 18);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = false;
            this.lblStatus.BackColor = System.Drawing.SystemColors.Control;
            this.lblStatus.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.lblStatus.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.lblStatus.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblStatus.Size = new System.Drawing.Size(418, 19);
            this.lblStatus.Spring = true;
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile,
            this.editToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.gameplayFormulaToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1025, 24);
            this.menuStrip1.TabIndex = 11;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mnuFile
            // 
            this.mnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuClose,
            this.mnuCloseAll,
            this.toolStripSeparator6,
            this.mnuSave,
            this.toolStripMenuItem1,
            this.toolStripSeparator1,
            this.mnuExit});
            this.mnuFile.Name = "mnuFile";
            this.mnuFile.Size = new System.Drawing.Size(37, 20);
            this.mnuFile.Text = "&File";
            this.mnuFile.DropDownOpening += new System.EventHandler(this.MnuFileDropDownOpening);
            // 
            // mnuClose
            // 
            this.mnuClose.Name = "mnuClose";
            this.mnuClose.Size = new System.Drawing.Size(187, 22);
            this.mnuClose.Text = "&Close";
            this.mnuClose.Click += new System.EventHandler(this.MnuCloseClick);
            // 
            // mnuCloseAll
            // 
            this.mnuCloseAll.Name = "mnuCloseAll";
            this.mnuCloseAll.Size = new System.Drawing.Size(187, 22);
            this.mnuCloseAll.Text = "Close All";
            this.mnuCloseAll.Click += new System.EventHandler(this.MnuCloseAllClick);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(184, 6);
            // 
            // mnuSave
            // 
            this.mnuSave.Image = ((System.Drawing.Image)(resources.GetObject("mnuSave.Image")));
            this.mnuSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuSave.Name = "mnuSave";
            this.mnuSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.mnuSave.Size = new System.Drawing.Size(187, 22);
            this.mnuSave.Text = "&Save";
            this.mnuSave.Click += new System.EventHandler(this.MnuSaveClick);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.toolStripMenuItem1.Size = new System.Drawing.Size(187, 22);
            this.toolStripMenuItem1.Text = "Save All";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.MnuSaveAll);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(184, 6);
            // 
            // mnuExit
            // 
            this.mnuExit.Name = "mnuExit";
            this.mnuExit.Size = new System.Drawing.Size(187, 22);
            this.mnuExit.Text = "E&xit";
            this.mnuExit.Click += new System.EventHandler(this.MnuExitClick);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoToolStripMenuItem,
            this.redoToolStripMenuItem,
            this.toolStripSeparator3,
            this.cutToolStripMenuItem,
            this.copyToolStripMenuItem,
            this.pasteToolStripMenuItem,
            this.toolStripSeparator4,
            this.selectAllToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "&Edit";
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.undoToolStripMenuItem.Text = "&Undo";
            this.undoToolStripMenuItem.Click += new System.EventHandler(this.UndoToolStripMenuItemClick);
            // 
            // redoToolStripMenuItem
            // 
            this.redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            this.redoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
            this.redoToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.redoToolStripMenuItem.Text = "&Redo";
            this.redoToolStripMenuItem.Click += new System.EventHandler(this.RedoToolStripMenuItemClick);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(141, 6);
            // 
            // cutToolStripMenuItem
            // 
            this.cutToolStripMenuItem.Enabled = false;
            this.cutToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("cutToolStripMenuItem.Image")));
            this.cutToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            this.cutToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.cutToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.cutToolStripMenuItem.Text = "Cu&t";
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Enabled = false;
            this.copyToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("copyToolStripMenuItem.Image")));
            this.copyToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.copyToolStripMenuItem.Text = "&Copy";
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Enabled = false;
            this.pasteToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("pasteToolStripMenuItem.Image")));
            this.pasteToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.pasteToolStripMenuItem.Text = "&Paste";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(141, 6);
            // 
            // selectAllToolStripMenuItem
            // 
            this.selectAllToolStripMenuItem.Enabled = false;
            this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
            this.selectAllToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.selectAllToolStripMenuItem.Text = "Select &All";
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsToolStripMenuItem,
            this.tagEditorToolStripMenuItem,
            this.badNamesToolStripMenuItem,
            this.stringEditorToolStripMenuItem,
            this.gameConstantsToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.toolsToolStripMenuItem.Text = "&Tools";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Enabled = false;
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.optionsToolStripMenuItem.Text = "&Options";
            // 
            // tagEditorToolStripMenuItem
            // 
            this.tagEditorToolStripMenuItem.Name = "tagEditorToolStripMenuItem";
            this.tagEditorToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.tagEditorToolStripMenuItem.Text = "Tag Editor...";
            this.tagEditorToolStripMenuItem.Click += new System.EventHandler(this.TagEditorToolStripMenuItemClick);
            // 
            // badNamesToolStripMenuItem
            // 
            this.badNamesToolStripMenuItem.Name = "badNamesToolStripMenuItem";
            this.badNamesToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.badNamesToolStripMenuItem.Text = "Bad Names";
            this.badNamesToolStripMenuItem.Click += new System.EventHandler(this.BadNamesToolStripMenuItemClick);
            // 
            // stringEditorToolStripMenuItem
            // 
            this.stringEditorToolStripMenuItem.Name = "stringEditorToolStripMenuItem";
            this.stringEditorToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.stringEditorToolStripMenuItem.Text = "String Editor";
            this.stringEditorToolStripMenuItem.Click += new System.EventHandler(this.StringEditorToolStripMenuItemClick);
            // 
            // gameConstantsToolStripMenuItem
            // 
            this.gameConstantsToolStripMenuItem.Name = "gameConstantsToolStripMenuItem";
            this.gameConstantsToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.gameConstantsToolStripMenuItem.Text = "Game Constants";
            this.gameConstantsToolStripMenuItem.Click += new System.EventHandler(this.gameConstantsToolStripMenuItem_Click);
            // 
            // gameplayFormulaToolStripMenuItem
            // 
            this.gameplayFormulaToolStripMenuItem.Name = "gameplayFormulaToolStripMenuItem";
            this.gameplayFormulaToolStripMenuItem.Size = new System.Drawing.Size(12, 20);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.aboutToolStripMenuItem.Text = "&About...";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItemClick);
            // 
            // reductionRatingsToolStripMenuItem
            // 
            this.reductionRatingsToolStripMenuItem.Name = "reductionRatingsToolStripMenuItem";
            this.reductionRatingsToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // regenRatingsToolStripMenuItem
            // 
            this.regenRatingsToolStripMenuItem.Name = "regenRatingsToolStripMenuItem";
            this.regenRatingsToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // powerLevelRatingsToolStripMenuItem
            // 
            this.powerLevelRatingsToolStripMenuItem.Name = "powerLevelRatingsToolStripMenuItem";
            this.powerLevelRatingsToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // professionXpMultipliersToolStripMenuItem
            // 
            this.professionXpMultipliersToolStripMenuItem.Name = "professionXpMultipliersToolStripMenuItem";
            this.professionXpMultipliersToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // xpPerLevelToolStripMenuItem
            // 
            this.xpPerLevelToolStripMenuItem.Name = "xpPerLevelToolStripMenuItem";
            this.xpPerLevelToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // imagesSystem
            // 
            this.imagesSystem.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imagesSystem.ImageSize = new System.Drawing.Size(16, 16);
            this.imagesSystem.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(12, 27);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tabContent);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.txtFilter);
            this.splitContainer1.Panel2.Controls.Add(this.treeBrowse);
            this.splitContainer1.Size = new System.Drawing.Size(1001, 581);
            this.splitContainer1.SplitterDistance = 796;
            this.splitContainer1.TabIndex = 12;
            // 
            // txtFilter
            // 
            this.txtFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFilter.Location = new System.Drawing.Point(3, 2);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(195, 20);
            this.txtFilter.TabIndex = 8;
            this.txtFilter.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtFilterKeyDown);
            // 
            // treeBrowse
            // 
            this.treeBrowse.AllowDrop = true;
            this.treeBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeBrowse.BackColor = System.Drawing.SystemColors.Window;
            this.treeBrowse.HideSelection = false;
            this.treeBrowse.HotTracking = true;
            this.treeBrowse.LabelEdit = true;
            this.treeBrowse.Location = new System.Drawing.Point(3, 26);
            this.treeBrowse.Name = "treeBrowse";
            this.treeBrowse.Size = new System.Drawing.Size(195, 555);
            this.treeBrowse.TabIndex = 7;
            this.treeBrowse.BeforeLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.TreeBrowseBeforeLabelEdit);
            this.treeBrowse.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.TreeBrowseAfterLabelEdit);
            this.treeBrowse.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.TreeBrowseBeforeExpand);
            this.treeBrowse.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.TreeBrowseNodeMouseClick);
            this.treeBrowse.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.TreeBrowseNodeMouseDoubleClick);
            this.treeBrowse.DragDrop += new System.Windows.Forms.DragEventHandler(this.TreeBrowseDragDrop);
            this.treeBrowse.DragOver += new System.Windows.Forms.DragEventHandler(this.TreeBrowseDragOver);
            this.treeBrowse.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TreeBrowseKeyDown);
            this.treeBrowse.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TreeBrowseMouseDown);
            this.treeBrowse.MouseMove += new System.Windows.Forms.MouseEventHandler(this.TreeBrowseMouseMove);
            // 
            // contextBrowseNode
            // 
            this.contextBrowseNode.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuBrowseDeleteNode,
            this.mnuBrowseOpenNode,
            this.mnuBrowseCopyNode,
            this.createProductToolStripMenuItem});
            this.contextBrowseNode.Name = "contextMenuStrip";
            this.contextBrowseNode.Size = new System.Drawing.Size(154, 92);
            // 
            // mnuBrowseDeleteNode
            // 
            this.mnuBrowseDeleteNode.Name = "mnuBrowseDeleteNode";
            this.mnuBrowseDeleteNode.Size = new System.Drawing.Size(153, 22);
            this.mnuBrowseDeleteNode.Text = "Delete";
            this.mnuBrowseDeleteNode.Click += new System.EventHandler(this.MnuBrowseDeleteNodeClick);
            // 
            // mnuBrowseOpenNode
            // 
            this.mnuBrowseOpenNode.Name = "mnuBrowseOpenNode";
            this.mnuBrowseOpenNode.Size = new System.Drawing.Size(153, 22);
            this.mnuBrowseOpenNode.Text = "Open Content";
            this.mnuBrowseOpenNode.Click += new System.EventHandler(this.MnuBrowseOpenNodeClick);
            // 
            // mnuBrowseCopyNode
            // 
            this.mnuBrowseCopyNode.Name = "mnuBrowseCopyNode";
            this.mnuBrowseCopyNode.Size = new System.Drawing.Size(153, 22);
            this.mnuBrowseCopyNode.Text = "Copy";
            this.mnuBrowseCopyNode.Click += new System.EventHandler(this.MnuBrowseCopyNodeClick);
            // 
            // createProductToolStripMenuItem
            // 
            this.createProductToolStripMenuItem.Name = "createProductToolStripMenuItem";
            this.createProductToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.createProductToolStripMenuItem.Text = "Create Product";
            this.createProductToolStripMenuItem.Click += new System.EventHandler(this.CreateProductToolStripMenuItemClick);
            // 
            // contextSequenceMenu
            // 
            this.contextSequenceMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAddSystemNode,
            this.mnuAddCustomNode});
            this.contextSequenceMenu.Name = "contextMenu";
            this.contextSequenceMenu.Size = new System.Drawing.Size(174, 48);
            // 
            // mnuAddSystemNode
            // 
            this.mnuAddSystemNode.Name = "mnuAddSystemNode";
            this.mnuAddSystemNode.Size = new System.Drawing.Size(173, 22);
            this.mnuAddSystemNode.Text = "Add System Node";
            // 
            // mnuAddCustomNode
            // 
            this.mnuAddCustomNode.Name = "mnuAddCustomNode";
            this.mnuAddCustomNode.Size = new System.Drawing.Size(173, 22);
            this.mnuAddCustomNode.Text = "Add Custom Node";
            // 
            // tabContent
            // 
            this.tabContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabContent.HotTrack = true;
            this.tabContent.Location = new System.Drawing.Point(0, 0);
            this.tabContent.Multiline = true;
            this.tabContent.Name = "tabContent";
            this.tabContent.SelectedIndex = 0;
            this.tabContent.Size = new System.Drawing.Size(793, 581);
            this.tabContent.TabIndex = 8;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1025, 633);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RealmEdit";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainFormFormClosing);
            this.Load += new System.EventHandler(this.MainFormLoad);
            this.contextBrowseFolder.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.contextBrowseNode.ResumeLayout(false);
            this.contextSequenceMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextBrowseFolder;
        private System.Windows.Forms.ToolStripMenuItem mnuBrowseNewClass;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuFile;
        private System.Windows.Forms.ToolStripMenuItem mnuSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mnuExit;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redoToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuClose;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem mnuCloseAll;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ImageList imagesSystem;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private Realm.Edit.CustomControls.AuraTab tabContent;
        private System.Windows.Forms.TreeView treeBrowse;
        private System.Windows.Forms.ToolStripMenuItem mnuBrowseDeleteClass;
        private System.Windows.Forms.ToolStripMenuItem mnuBrowseRenameClass;
        private System.Windows.Forms.ContextMenuStrip contextBrowseNode;
        private System.Windows.Forms.ToolStripMenuItem mnuBrowseDeleteNode;
        private System.Windows.Forms.ToolStripMenuItem mnuBrowseNewNode;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ContextMenuStrip contextSequenceMenu;
        private System.Windows.Forms.ToolStripMenuItem mnuAddSystemNode;
        private System.Windows.Forms.ToolStripMenuItem mnuAddCustomNode;
        private System.Windows.Forms.ToolStripStatusLabel lblServer;
        private System.Windows.Forms.ToolStripStatusLabel lblDatabase;
        private System.Windows.Forms.ToolStripStatusLabel lblUser;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.ToolStripProgressBar progressStatus;
        private System.Windows.Forms.ToolStripMenuItem tagEditorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuBrowseOpenNode;
        private System.Windows.Forms.ToolStripMenuItem gameplayFormulaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reductionRatingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem regenRatingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem powerLevelRatingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem professionXpMultipliersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xpPerLevelToolStripMenuItem;
        private System.Windows.Forms.TextBox txtFilter;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem mnuBrowseCookData;
        private System.Windows.Forms.ToolStripMenuItem mnuBrowseCopyNode;
        private System.Windows.Forms.ToolStripMenuItem badNamesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createProductToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuBrowseMoveClass;
        private System.Windows.Forms.ToolStripMenuItem stringEditorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gameConstantsToolStripMenuItem;
    }
}

