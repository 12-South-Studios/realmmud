using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Xml;

namespace RealmEdit
{
    // **************************************************
    // NpcControl
    // **************************************************
    public partial class NpcControl : BaseEditorControl
    {
        public NpcControl()    // default Ctor needed for editor
        {
            InitializeComponent();
            initControls();
            Id = 0;
        }

        public NpcControl(int aClassId)
            : base(EditorSystemType.Npc, aClassId)
        {
            InitializeComponent();
            initControls();
            Id = 0;
        }

        private void initControls()
        {
            TextBoxUtils.initTextBox(txtSystemName, "npc_def", "system_name");
            TextBoxUtils.initTextBox(txtDisplayName, "npc_def", "display_name");
            TextBoxUtils.initTextBox(txtDisplayDescription, "npc_def", "display_description");

            linkRace.SystemType = EditorSystemType.Race;
            linkShop.SystemType = EditorSystemType.Shop;
            linkFaction.SystemType = EditorSystemType.Faction;
            linkTreasure.SystemType = EditorSystemType.Treasure;

            chkIsShop.Checked = false;
            linkShop.Visible = false;

            chkHasTreasure.Checked = false;
            linkTreasure.Visible = false;

            initStatisticsGrid();
            initAbilitiesGrid();
            initItemsGrid();
            initNodesGrid();
            initConversationsGrid();
        }

        private void initStatisticsGrid()
        {
            {
                DataGridViewColumn col = new DataGridViewColumn();
                DataGridViewTypedLinkCell cell = new DataGridViewTypedLinkCell();
                cell.SystemType = EditorSystemType.Statistic;
                col.Name = "statistic_def_id";
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                col.FillWeight = 100;
                col.HeaderText = "Statistic";
                col.CellTemplate = cell;
                gridStatistics.Columns.Add(col);
            }
            {
                DataGridViewNumericUpDownElements.DataGridViewNumericUpDownColumn col = new DataGridViewNumericUpDownElements.DataGridViewNumericUpDownColumn();
                DataGridViewNumericUpDownElements.DataGridViewNumericUpDownCell cell = new DataGridViewNumericUpDownElements.DataGridViewNumericUpDownCell();
                col.Name = "value";
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                col.FillWeight = 40;
                col.HeaderText = "Stat Value";
                col.CellTemplate = cell;
                col.Maximum = 10000000;
                col.Minimum = 1;
                gridStatistics.Columns.Add(col);
            }
        }

        private void initAbilitiesGrid()
        {
            {
                DataGridViewColumn col = new DataGridViewColumn();
                DataGridViewTypedLinkCell cell = new DataGridViewTypedLinkCell();
                cell.SystemType = EditorSystemType.Ability;
                col.Name = "ability_def_id";
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                col.FillWeight = 100;
                col.HeaderText = "Ability";
                col.CellTemplate = cell;
                gridAbilities.Columns.Add(col);
            }
            {
                DataGridViewCheckBoxColumn col = new DataGridViewCheckBoxColumn();
                DataGridViewCheckBoxCell cell = new DataGridViewCheckBoxCell();
                col.Name = "is_default";
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                col.FillWeight = 25;
                col.HeaderText = "Is Default";
                col.CellTemplate = cell;
                gridAbilities.Columns.Add(col);
            }
        }

        private void initItemsGrid()
        {
            {
                DataGridViewColumn col = new DataGridViewColumn();
                DataGridViewTypedLinkCell cell = new DataGridViewTypedLinkCell();
                cell.SystemType = EditorSystemType.Item;
                col.Name = "item_def_id";
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                col.FillWeight = 100;
                col.HeaderText = "Item";
                col.CellTemplate = cell;
                gridItems.CurrentCellDirtyStateChanged += new EventHandler(gridItems_CurrentCellDirtyStateChanged);
                gridItems.Columns.Add(col);
            }
            {
                DataGridViewColumn col = new DataGridViewColumn();
                DataGridViewTypedLinkCell cell = new DataGridViewTypedLinkCell();
                cell.SystemType = EditorSystemType.Slot;
                col.Name = "slot_def_id";
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                col.FillWeight = 100;
                col.HeaderText = "Slot";
                col.CellTemplate = cell;
                gridItems.Columns.Add(col);
            }
            {
                DataGridViewNumericUpDownElements.DataGridViewNumericUpDownColumn col = new DataGridViewNumericUpDownElements.DataGridViewNumericUpDownColumn();
                DataGridViewNumericUpDownElements.DataGridViewNumericUpDownCell cell = new DataGridViewNumericUpDownElements.DataGridViewNumericUpDownCell();
                col.Name = "quantity";
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                col.FillWeight = 40;
                col.HeaderText = "Quantity";
                col.CellTemplate = cell;
                col.Maximum = 9999;
                col.Minimum = 1;
                cell.Value = 1;
                gridItems.Columns.Add(col);
            }
        }

        private void initConversationsGrid()
        {
            {
                DataGridViewColumn col = new DataGridViewColumn();
                DataGridViewTextBoxCell cell = new DataGridViewTextBoxCell();
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                col.FillWeight = 100;
                col.Name = "keyword";
                col.HeaderText = "Keywords";
                col.CellTemplate = cell;
                gridConversations.Columns.Add(col);
            }
            {
                DataGridViewColumn col = new DataGridViewColumn();
                DataGridViewTextBoxCell cell = new DataGridViewTextBoxCell();
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                col.FillWeight = 250;
                col.Name = "conversation";
                col.HeaderText = "Text";
                col.CellTemplate = cell;
                gridConversations.Columns.Add(col);
            }
            {
                DataGridViewCheckBoxColumn col = new DataGridViewCheckBoxColumn();
                DataGridViewCheckBoxCell cell = new DataGridViewCheckBoxCell();
                col.Name = "is_default";
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                col.FillWeight = 25;
                col.HeaderText = "Is Default";
                col.CellTemplate = cell;
                gridConversations.Columns.Add(col);
            }
            {
                DataGridViewColumn col = new DataGridViewColumn();
                DataGridViewTypedLinkCell cell = new DataGridViewTypedLinkCell();
                cell.SystemType = EditorSystemType.Slot;
                col.Name = "faction_def_id";
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                col.FillWeight = 100;
                col.HeaderText = "Faction";
                col.CellTemplate = cell;
                gridConversations.Columns.Add(col);
            }
            {
                DataGridViewNumericUpDownElements.DataGridViewNumericUpDownColumn col = new DataGridViewNumericUpDownElements.DataGridViewNumericUpDownColumn();
                DataGridViewNumericUpDownElements.DataGridViewNumericUpDownCell cell = new DataGridViewNumericUpDownElements.DataGridViewNumericUpDownCell();
                col.Name = "faction_reputation";
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                col.FillWeight = 60;
                col.HeaderText = "Reputation";
                col.CellTemplate = cell;
                col.Maximum = 9999;
                col.Minimum = 0;
                cell.Value = 0;
                gridConversations.Columns.Add(col);
            }
        }

        void gridItems_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (gridItems.CurrentCell == null)
                return;

            if (gridItems.CurrentCell is DataGridViewTypedLinkCell)
            {
                // Find the slot information
                EditorBrowseInfo itemDefIdBrowseInfo = gridItems.CurrentRow.Cells["item_def_id"].Value as EditorBrowseInfo;
                int itemDefId = itemDefIdBrowseInfo.Id;

                DataTable dt = Database.getData("item_slot_map", "item_def_id", itemDefId, null);
                if (dt == null) return;
                if (dt.Rows.Count == 0) return;

                DataRow dataRow = dt.Rows[0];
                DataGridViewLinkCell cellSlot = gridItems.CurrentRow.Cells["slot_def_id"] as DataGridViewLinkCell;
                cellSlot.Value = EditorFactory.getBrowseInfo(EditorSystemType.Slot, dataRow, "slot_def_id");

                DataGridViewNumericUpDownElements.DataGridViewNumericUpDownCell cellQty = gridItems.CurrentRow.Cells["quantity"] as DataGridViewNumericUpDownElements.DataGridViewNumericUpDownCell;
                cellQty.Value = (int)1;
            }
        }

        private void initNodesGrid()
        {
            {
                DataGridViewComboBoxColumn col = new DataGridViewComboBoxColumn();
                DataGridViewComboBoxCell cell = new DataGridViewComboBoxCell();
                col.Name = "ref_npc_node_type_id";
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                col.FillWeight = 25;
                col.HeaderText = "Node Type";
                col.CellTemplate = cell;
                ComboUtils.fillComboCellWithRefTable(cell, "ref_npc_node_type", "ref_npc_node_type_id", "name");
                col.ValueMember = "Value";
                col.DisplayMember = "Name";
                gridNodes.Columns.Add(col);
            }
            {
                DataGridViewColumn col = new DataGridViewColumn();
                DataGridViewTypedLinkCell cell = new DataGridViewTypedLinkCell();
                cell.SystemType = EditorSystemType.Item;
                col.Name = "item_def_id";
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                col.FillWeight = 100;
                col.HeaderText = "Resource Node";
                col.CellTemplate = cell;
                gridNodes.Columns.Add(col);
            }
        }

        public override void initNewImpl()
        {
            ComboUtils.fillCombo(cboGender, "ref_gender", "name", "ref_gender_id", 0);
        }

        public override void initContentImpl(int aId)
        {
            DataTable dt = Database.getData("npc_def", "npc_def_id", aId, null);
            if (dt == null)
            {
                Program.MainForm.logError("Could not load NPC [" + aId + "]");
                return;
            }
            if (dt.Rows.Count == 0)
            {
                Program.MainForm.logError("Could not load NPC [" + aId + "]");
                return;
            }

            Program.MainForm.logInfo("NPC loaded [" + aId + "]");
            DataRow dataRow = dt.Rows[0];

            txtSystemName.Text = dataRow["system_name"].ToString();
            txtDisplayName.Text = dataRow["display_name"].ToString();
            txtDisplayDescription.Text = dataRow["display_description"].ToString();

            numAccessLevel.Value = (int)dataRow["access_level"];

            ComboUtils.fillCombo(cboGender, "ref_gender", "name", "ref_gender_id", (int)dataRow["ref_gender_id"]);
            EditorFactory.setupLink(linkRace, EditorSystemType.Race, Database.getNullableId(dataRow, "race_def_id"));
            EditorFactory.setupLink(linkShop, EditorSystemType.Shop, Database.getNullableId(dataRow, "shop_def_id"));
            if (linkShop.Text != "")
                chkIsShop.Checked = true;

            EditorFactory.setupLink(linkFaction, EditorSystemType.Faction, Database.getNullableId(dataRow, "faction_def_id"));
            EditorFactory.setupLink(linkTreasure, EditorSystemType.Treasure, Database.getNullableId(dataRow, "treasure_def_id"));
            if (linkTreasure.Text != "")
                chkHasTreasure.Checked = true;
            numLevel.Value = Database.getNullableId(dataRow, "npc_level");

            dt.Dispose();
            ControlName = txtSystemName.Text;

            loadStatisticsGrid(aId);
            loadAbilitiesGrid(aId);
            loadItemsGrid(aId);
            loadNodesGrid(aId);
            loadConversationsGrid(aId);
        }

        private void loadStatisticsGrid(int aId)
        {
            gridStatistics.Rows.Clear();

            DataTable dt = Database.getData("npc_statistic_map", "npc_def_id", aId, null);
            if (dt == null) return;
            foreach(DataRow rowView in dt.Rows)
            {
                int gridIndex = gridStatistics.Rows.Add();
                DataGridViewRow gridRow = gridStatistics.Rows[gridIndex];

                DataGridViewLinkCell cellStat = gridRow.Cells["statistic_def_id"] as DataGridViewLinkCell;
                cellStat.Value = EditorFactory.getBrowseInfo(EditorSystemType.Statistic, rowView, "statistic_def_id");

                DataGridViewNumericUpDownElements.DataGridViewNumericUpDownCell cellValue = gridRow.Cells["value"] as DataGridViewNumericUpDownElements.DataGridViewNumericUpDownCell;
                cellValue.Value = (int)rowView["value"];

                gridRow.Tag = (int)rowView["npc_statistic_map_id"];
            }
            dt.Dispose();
        }

        private void loadAbilitiesGrid(int aId)
        {
            gridAbilities.Rows.Clear();

            DataTable dt = Database.getData("npc_ability_map", "npc_def_id", aId, null);
            if (dt == null) return;
            foreach(DataRow rowView in dt.Rows)
            {
                int gridIndex = gridAbilities.Rows.Add();
                DataGridViewRow gridRow = gridAbilities.Rows[gridIndex];

                DataGridViewLinkCell cellAbility = gridRow.Cells["ability_def_id"] as DataGridViewLinkCell;
                cellAbility.Value = EditorFactory.getBrowseInfo(EditorSystemType.Ability, rowView, "ability_def_id");

                DataGridViewCheckBoxCell cellDefault = gridRow.Cells["is_default"] as DataGridViewCheckBoxCell;
                if (rowView["is_default"] != DBNull.Value)
                    cellDefault.Value = (bool)rowView["is_default"];

                gridRow.Tag = (int)rowView["npc_ability_map_id"];
            }
            dt.Dispose();
        }

        private void loadItemsGrid(int aId)
        {
            gridItems.Rows.Clear();

            DataTable dt = Database.getData("npc_item_map", "npc_def_id", aId, null);
            if (dt == null) return;
            foreach(DataRow rowView in dt.Rows)
            {
                int gridIndex = gridItems.Rows.Add();
                DataGridViewRow gridRow = gridItems.Rows[gridIndex];

                DataGridViewLinkCell cellItem = gridRow.Cells["item_def_id"] as DataGridViewLinkCell;
                cellItem.Value = EditorFactory.getBrowseInfo(EditorSystemType.Item, rowView, "item_def_id");

                DataGridViewLinkCell cellSlot = gridRow.Cells["slot_def_id"] as DataGridViewLinkCell;
                cellSlot.Value = EditorFactory.getBrowseInfo(EditorSystemType.Slot, rowView, "slot_def_id");

                DataGridViewNumericUpDownElements.DataGridViewNumericUpDownCell cellQty = gridRow.Cells["quantity"] as DataGridViewNumericUpDownElements.DataGridViewNumericUpDownCell;
                cellQty.Value = (int)rowView["quantity"];

                gridRow.Tag = (int)rowView["npc_item_map_id"];
            }
            dt.Dispose();
        }

        private void loadNodesGrid(int aId)
        {
            gridNodes.Rows.Clear();

            DataTable dt = Database.getData("npc_node_map", "npc_def_id", aId, null);
            if (dt == null) return;
            foreach(DataRow rowView in dt.Rows)
            {
                int gridIndex = gridNodes.Rows.Add();
                DataGridViewRow gridRow = gridNodes.Rows[gridIndex];

                DataGridViewComboBoxCell cellState = gridRow.Cells["ref_npc_node_type_id"] as DataGridViewComboBoxCell;
                ComboUtils.fillComboCellWithRefTable(cellState, "ref_npc_node_type", "ref_npc_node_type_id", "name", Database.getNullableId(rowView, "ref_npc_node_type_id"));

                DataGridViewLinkCell cellItem = gridRow.Cells["item_def_id"] as DataGridViewLinkCell;
                cellItem.Value = EditorFactory.getBrowseInfo(EditorSystemType.Item, rowView, "item_def_id");

                gridRow.Tag = (int)rowView["npc_node_map_id"];
            }
            dt.Dispose();
        }

        private void loadConversationsGrid(int aId)
        {
            gridConversations.Rows.Clear();

            DataTable dt = Database.getData("npc_conversation_map", "npc_def_id", aId, null);
            if (dt == null) return;
            foreach (DataRow rowView in dt.Rows)
            {
                int gridIndex = gridConversations.Rows.Add();
                DataGridViewRow gridRow = gridConversations.Rows[gridIndex];

                DataGridViewTextBoxCell cellKeyword = gridRow.Cells["keyword"] as DataGridViewTextBoxCell;
                cellKeyword.MaxInputLength = Database.getColumnLength("npc_conversation_map", "keyword");
                cellKeyword.Value = rowView["keyword"].ToString();

                DataGridViewTextBoxCell cellText = gridRow.Cells["conversation"] as DataGridViewTextBoxCell;
                cellText.MaxInputLength = Database.getColumnLength("npc_conversation_map", "conversation");
                cellText.Value = rowView["conversation"].ToString();

                DataGridViewCheckBoxCell cellDefault = gridRow.Cells["is_default"] as DataGridViewCheckBoxCell;
                if (rowView["is_default"] != DBNull.Value)
                    cellDefault.Value = (bool)rowView["is_default"];

                DataGridViewLinkCell cellFaction = gridRow.Cells["faction_def_id"] as DataGridViewLinkCell;
                cellFaction.Value = EditorFactory.getBrowseInfo(EditorSystemType.Faction, rowView, "faction_def_id");

                DataGridViewNumericUpDownElements.DataGridViewNumericUpDownCell cellRep = gridRow.Cells["faction_reputation"] as DataGridViewNumericUpDownElements.DataGridViewNumericUpDownCell;
                cellRep.Value = (int)rowView["faction_reputation"];

                gridRow.Tag = (int)rowView["npc_conversation_map_id"];
            }
            dt.Dispose();
        }

        public override bool saveImpl()
        {
            gridStatistics.EndEdit();
            gridAbilities.EndEdit();
            gridItems.EndEdit();
            gridNodes.EndEdit();
            gridConversations.EndEdit();

            try {
                Database.beginTransaction();

                if (Id == 0)
                {
                    Id = Database.createData("npc_def", "class_id", ClassId, "system_name", txtSystemName.Text);
                    if (Id == 0) throw new Exception("Failed to create new NPC Def");
                }
                else
                    Database.updateData("npc_def", "npc_def_id", Id, "system_name", txtSystemName.Text); 
                Database.updateData("npc_def", "npc_def_id", Id, "display_name", txtDisplayName.Text);
                Database.updateData("npc_def", "npc_def_id", Id, "display_description", txtDisplayDescription.Text);
                Database.updateData("npc_def", "npc_def_id", Id, "access_level", (int)numAccessLevel.Value);
                Database.updateData("npc_def", "npc_def_id", Id, "race_def_id", getContentLinkId(linkRace));
                Database.updateData("npc_def", "npc_def_id", Id, "shop_def_id", getContentLinkId(linkShop));
                Database.updateData("npc_def", "npc_def_id", Id, "faction_def_id", getContentLinkId(linkFaction));
                Database.updateData("npc_def", "npc_def_id", Id, "treasure_def_id", getContentLinkId(linkTreasure));
                Database.updateData("npc_def", "npc_def_id", Id, "ref_gender_id", (cboGender.SelectedItem as TagInfo).Id);
                Database.updateData("npc_def", "npc_def_id", Id, "npc_level", (int)numLevel.Value);

                saveStatisticsGrid(Id);
                saveAbilitiesGrid(Id);
                saveItemsGrid(Id);
                saveNodesGrid(Id);
                saveConversationsGrid(Id);

                Database.commitTransaction();

                initContent(Id);
                return true;
            }
            catch (SqlException ex)
            {
                Database.handleException(ex, "Error saving npc [" + ControlName + "]");
                Database.rollbackTransaction();
                return false;
            }
        }

        private void saveStatisticsGrid(int aDefId)
        {
            Database.deleteData("npc_statistic_map", "npc_def_id", aDefId);
            foreach (DataGridViewRow gridRow in gridStatistics.Rows)
            {
                if (!gridRow.IsNewRow && gridRow.Visible)
                {
                    EditorBrowseInfo statDefIdBrowseInfo = gridRow.Cells["statistic_def_id"].Value as EditorBrowseInfo;
                    if (statDefIdBrowseInfo == null) continue;

                    int rowId = Database.createData("npc_statistic_map", "npc_def_id", aDefId, null, null);
                    if (rowId == 0) throw new Exception("Failed to create new row in npc_statistic_map");

                    Database.updateData("npc_statistic_map", "npc_statistic_map_id", rowId, "statistic_def_id", statDefIdBrowseInfo.Id);
                    Database.updateData("npc_statistic_map", "npc_statistic_map_id", rowId, "value", (int)gridRow.Cells["value"].Value);
                }
            }
            gridStatistics.flushDeletedRows();
        }

        private void saveAbilitiesGrid(int aDefId)
        {
            Database.deleteData("npc_ability_map", "npc_def_id", aDefId);
            foreach (DataGridViewRow gridRow in gridAbilities.Rows)
            {
                if (!gridRow.IsNewRow && gridRow.Visible)
                {
                    EditorBrowseInfo abilityDefIdBrowseInfo = gridRow.Cells["ability_def_id"].Value as EditorBrowseInfo;
                    if (abilityDefIdBrowseInfo == null) continue;

                    int rowId = Database.createData("npc_ability_map", "npc_def_id", aDefId, null, null);
                    if (rowId == 0) throw new Exception("Failed to create new row in npc_ability_map");

                    Database.updateData("npc_ability_map", "npc_ability_map_id", rowId, "ability_def_id", abilityDefIdBrowseInfo.Id);
                    if (gridRow.Cells["is_default"].Value != null)
                        Database.updateData("npc_ability_map", "npc_ability_map_id", rowId, "is_default", (int)gridRow.Cells["is_default"].Value);
                }
            }
            gridAbilities.flushDeletedRows();
        }

        private void saveItemsGrid(int aDefId)
        {
            Database.deleteData("npc_item_map", "npc_def_id", aDefId);
            foreach (DataGridViewRow gridRow in gridItems.Rows)
            {
                if (!gridRow.IsNewRow && gridRow.Visible)
                {
                    EditorBrowseInfo itemDefIdBrowseInfo = gridRow.Cells["item_def_id"].Value as EditorBrowseInfo;
                    if (itemDefIdBrowseInfo == null) continue;

                    EditorBrowseInfo slotDefIdBrowseInfo = gridRow.Cells["slot_def_id"].Value as EditorBrowseInfo;

                    int rowId = Database.createData("npc_item_map", "npc_def_id", aDefId, null, null);
                    if (rowId == 0) throw new Exception("Failed to create new row in npc_item_map");

                    Database.updateData("npc_item_map", "npc_item_map_id", rowId, "item_def_id", itemDefIdBrowseInfo.Id);
                    if (slotDefIdBrowseInfo != null)
                        Database.updateData("npc_item_map", "npc_item_map_id", rowId, "slot_def_id", slotDefIdBrowseInfo.Id);

                    if (gridRow.Cells["quantity"].Value == null)
                        Database.updateData("npc_item_map", "npc_item_map_id", rowId, "quantity", 1);
                    else
                        Database.updateData("npc_item_map", "npc_item_map_id", rowId, "quantity", (int)gridRow.Cells["quantity"].Value);
                }
            }
            gridItems.flushDeletedRows();
        }

        private void saveNodesGrid(int aDefId)
        {
            Database.deleteData("npc_node_map", "npc_def_id", aDefId);
            foreach (DataGridViewRow gridRow in gridNodes.Rows)
            {
                if (!gridRow.IsNewRow && gridRow.Visible)
                {
                    EditorBrowseInfo itemDefIdBrowseInfo = gridRow.Cells["item_def_id"].Value as EditorBrowseInfo;
                    if (itemDefIdBrowseInfo == null) continue;

                    int rowId = Database.createData("npc_node_map", "npc_def_id", aDefId, null, null);
                    if (rowId == 0) throw new Exception("Failed to create new row in npc_node_map");

                    Database.updateData("npc_node_map", "npc_node_map_id", rowId, "ref_npc_node_type_id", (int)gridRow.Cells["ref_npc_node_type_id"].Value);
                    Database.updateData("npc_node_map", "npc_node_map_id", rowId, "item_def_id", itemDefIdBrowseInfo.Id);
                }
            }
            gridNodes.flushDeletedRows();
        }

        private void saveConversationsGrid(int aDefId)
        {
            Database.deleteData("npc_conversation_map", "npc_def_id", aDefId);
            foreach (DataGridViewRow gridRow in gridConversations.Rows)
            {
                if (!gridRow.IsNewRow && gridRow.Visible)
                {
                    if (string.IsNullOrEmpty(gridRow.Cells["keyword"].ToString()) ||
                        string.IsNullOrEmpty(gridRow.Cells["conversation"].ToString()))
                        continue;

                    int rowId = Database.createData("npc_conversation_map", "npc_def_id", aDefId, null, null);
                    if (rowId == 0) throw new Exception("Failed to create new row in npc_conversation_map");

                    Database.updateData("npc_conversation_map", "npc_conversation_map_id", rowId, "keyword", gridRow.Cells["keyword"].ToString());
                    Database.updateData("npc_conversation_map", "npc_conversation_map_id", rowId, "conversation", gridRow.Cells["conversation"].ToString());
                    if (gridRow.Cells["is_default"].Value != null)
                        Database.updateData("npc_conversation_map", "npc_conversation_map_id", rowId, "is_default", (int)gridRow.Cells["is_default"].Value);
                    
                    EditorBrowseInfo factionDefIdBrowseInfo = gridRow.Cells["faction_def_id"].Value as EditorBrowseInfo;
                    Database.updateData("npc_conversation_map", "npc_conversation_map_id", rowId, "faction_def_id", factionDefIdBrowseInfo.Id);
                    Database.updateData("npc_conversation_map", "npc_conversation_map_id", rowId, "faction_reputation", (int)gridRow.Cells["faction_reputation"].Value);
                }
            }
            gridConversations.flushDeletedRows();
        }

        public override bool isSaveValid(bool aGiveFeedback)
        {
            bool valid = true;
            Color errorColor = Color.DarkRed;

            // Validate system name
            if (txtSystemName.Text.Length == 0)
            {
                if (aGiveFeedback)
                {
                    Program.MainForm.setStatusMessage("Missing System Name");
                    txtSystemName.BackColor = errorColor;
                }
                valid = false;
            }
            else
            {
                txtSystemName.BackColor = Color.Empty;
            }

            // Validate display name
            if (txtDisplayName.Text.Length == 0)
            {
                if (aGiveFeedback)
                {
                    Program.MainForm.setStatusMessage("Missing Display Name");
                    txtDisplayName.BackColor = errorColor;
                }
                valid = false;
            }
            else
            {
                txtDisplayName.BackColor = Color.Empty;
            }

            // Validate Description
            if (txtDisplayDescription.Text.Length == 0)
            {
                if (aGiveFeedback)
                {
                    Program.MainForm.setStatusMessage("Missing Display Description");
                    txtDisplayDescription.BackColor = errorColor;
                }
                valid = false;
            }
            else
            {
                txtDisplayDescription.BackColor = Color.Empty;
            }
            return valid;
        }

        private void chkIsShop_CheckedChanged(object sender, EventArgs e)
        {
            if (chkIsShop.Checked)
            {
                linkShop.Visible = true;
            }
            else
            {
                linkShop.Visible = false;
                linkShop.clear();
            }
        }

        private void chkHasTreasure_CheckedChanged(object sender, EventArgs e)
        {
            if (chkHasTreasure.Checked)
            {
                linkTreasure.Visible = true;
            }
            else
            {
                linkTreasure.Visible = false;
                linkTreasure.clear();
            }
        }
    }


    // **************************************************
    // NpcBuilder
    // **************************************************
    public class NpcBuilder : EditorBuilder
    {
        public NpcBuilder()
            : base(EditorSystemType.Npc, "Npc", "Npcs")
        {
            // @TODO: Give unique icons to each system for easier identification
            Icon = Icon.FromHandle(Properties.Resources.stat_16.GetHicon());
        }

        public override BaseEditorControl create(int aClassId)
        {
            return new NpcControl(aClassId);
        }

        public override int populateBrowseNode(TreeNode aParentNode, int aClassId, ContextMenuStrip aMenu, string aFilter)
        {
            return populateBrowseNodeImpl(aParentNode, aClassId, "npc_def", "system_name", "class_id = " + aClassId, "npc_def_id", aMenu, aFilter);
        }

        protected override void deleteImpl(int aId)
        {
            Database.deleteData("npc_conversation_map", "npc_def_id", aId);
            Database.deleteData("npc_node_map", "npc_def_id", aId);
            Database.deleteData("npc_statistic_map", "npc_def_id", aId);
            Database.deleteData("npc_ability_map", "npc_def_id", aId);
            Database.deleteData("npc_item_map", "npc_def_id", aId);
            Database.deleteData("npc_def", "npc_def_id", aId);
        }

        public override void move(int aId, int aNewClassId)
        {
            moveToClass("npc_def", "npc_def_id", aId, aNewClassId);
        }

        public override string idToText(object aId)
        {
            return Database.getData("npc_def", "noc_def_id", (int)aId, "system_name").ToString();
        }

        public override EditorBrowseInfo getBrowseInfo(int aId)
        {
            return getSimpleBrowseInfo("npc_def", aId, "system_name", "npc_def_id");
        }
        public override void cookData()
        {
            Cooker.Instance.cookCategoryTable("npc_def");
        }

    }
}

