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
    // ItemControl
    // **************************************************
    public partial class ItemControl : BaseEditorControl
    {
        private ItemArmorControl mArmorControl = new ItemArmorControl();
        private ItemBookControl mBookControl = new ItemBookControl();
        private ItemContainerControl mContainerControl = new ItemContainerControl();
        private ItemCorpseControl mCorpseControl = new ItemCorpseControl();
        private ItemDrinkContainerControl mDrinkContainerControl = new ItemDrinkContainerControl();
        private ItemFoodControl mFoodControl = new ItemFoodControl();
        private ItemFormulaControl mFormulaControl = new ItemFormulaControl();
        private ItemFurnitureControl mFurnitureControl = new ItemFurnitureControl();
        private ItemKeyControl mKeyControl = new ItemKeyControl();
        private ItemLightControl mLightControl = new ItemLightControl();
        private ItemLockControl mLockControl = new ItemLockControl();
        private ItemMachineControl mMachineControl = new ItemMachineControl();
        private ItemMagicalNodeControl mMagicalNodeControl = new ItemMagicalNodeControl();
        private ItemPortalControl mPortalControl = new ItemPortalControl();
        private ItemPotionControl mPotionControl = new ItemPotionControl();
        private ItemQuestControl mQuestControl = new ItemQuestControl();
        private ItemReagantControl mReagantControl = new ItemReagantControl();
        private ItemResourceControl mResourceControl = new ItemResourceControl();
        private ItemResourceNodeControl mResourceNodeControl = new ItemResourceNodeControl();
        private ItemRuneControl mRuneControl = new ItemRuneControl();
        private ItemSimpleControl mSimpleControl = new ItemSimpleControl();
        private ItemToolControl mToolControl = new ItemToolControl();
        private ItemTrapControl mTrapControl = new ItemTrapControl();
        private ItemTreasureControl mTreasureControl = new ItemTreasureControl();
        private ItemVehicleControl mVehicleControl = new ItemVehicleControl();
        private ItemWeaponControl mWeaponControl = new ItemWeaponControl();

        private ItemSubControl mCurrentControl;
        private int mItemType = Globals.ITEM_TYPE_Simple;

        public ItemControl()    // default Ctor needed for editor
        {
            InitializeComponent();
            initControls();
            Id = 0;
        }

        public ItemControl(int aClassId)
            : base(EditorSystemType.Item, aClassId)
        {
            InitializeComponent();
            initControls();
            Id = 0;
        }


        private void initControls()
        {
            TextBoxUtils.initTextBox(txtSystemName, "item_def", "system_name");
            TextBoxUtils.initTextBox(txtDisplayName, "item_def", "display_name");
            TextBoxUtils.initTextBox(txtDisplayDescription, "item_def", "display_description");

            ComboUtils.fillCombo(cboCondition, "ref_condition", "name", "ref_condition_id", 0);
            ComboUtils.fillCombo(cboDifficulty, "ref_difficulty", "name", "ref_difficulty_id", 0);
            ComboUtils.fillCombo(cboMaterialType, "ref_material", "name", "ref_material_id", 0);

            linkSocket.SystemType = EditorSystemType.Slot;
            linkSpotSkill.SystemType = EditorSystemType.Statistic;
            linkTrap.SystemType = EditorSystemType.Item;
            linkUseAbility.SystemType = EditorSystemType.Ability;

            // Hidden Controls
            {
                chkIsHidden.Checked = false;
                lblSpotSkill.Visible = false;
                linkSpotSkill.Visible = false;
                lblDifficulty.Visible = false;
                cboDifficulty.Visible = false;

                chkIsSocketed.Checked = false;
                linkSocket.Visible = false;

                chkIsTrapped.Checked = false;
                linkTrap.Visible = false;

                chkIsRepairable.Checked = false;
                cboCondition.Visible = false;
                lblCondition.Visible = false;

                chkIsUseable.Checked = false;
                lblUseAbility.Visible = false;
                linkUseAbility.Visible = false;
                lblUseFreq.Visible = false;
                numUseFrequency.Visible = false;
            }

            cboItemType.SelectedText = "Simple";
            initSlotsGrid();
            initSkillsGrid();
            initStatModsGrid();
        }

        private void initSlotsGrid()
        {
            {
                DataGridViewColumn col = new DataGridViewColumn();
                DataGridViewTypedLinkCell cell = new DataGridViewTypedLinkCell();
                cell.SystemType = EditorSystemType.Slot;
                col.Name = "slot_def_id";
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                col.FillWeight = 100;
                col.HeaderText = "Slots";
                col.CellTemplate = cell;
                gridSlots.Columns.Add(col);
            }
        }

        private void initSkillsGrid()
        {
            {
                DataGridViewColumn col = new DataGridViewColumn();
                DataGridViewTypedLinkCell cell = new DataGridViewTypedLinkCell();
                cell.SystemType = EditorSystemType.Statistic;
                col.Name = "statistic_def_id";
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                col.FillWeight = 100;
                col.HeaderText = "Skills";
                col.CellTemplate = cell;
                gridSkills.Columns.Add(col);
            }
            {
                DataGridViewNumericUpDownElements.DataGridViewNumericUpDownColumn col = new DataGridViewNumericUpDownElements.DataGridViewNumericUpDownColumn();
                DataGridViewNumericUpDownElements.DataGridViewNumericUpDownCell cell = new DataGridViewNumericUpDownElements.DataGridViewNumericUpDownCell();
                col.Name = "value";
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                col.FillWeight = 40;
                col.HeaderText = "Min Value";
                col.CellTemplate = cell;
                col.Maximum = 10000000;
                col.Minimum = 1;
                gridSkills.Columns.Add(col);
            }
        }

        private void initStatModsGrid()
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
                gridStatMods.Columns.Add(col);
            }
            {
                DataGridViewNumericUpDownElements.DataGridViewNumericUpDownColumn col = new DataGridViewNumericUpDownElements.DataGridViewNumericUpDownColumn();
                DataGridViewNumericUpDownElements.DataGridViewNumericUpDownCell cell = new DataGridViewNumericUpDownElements.DataGridViewNumericUpDownCell();
                col.Name = "value";
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                col.FillWeight = 40;
                col.HeaderText = "Stat Modifier";
                col.CellTemplate = cell;
                col.Maximum = 100;
                col.Minimum = -100;
                gridStatMods.Columns.Add(col);
            }
        }

        public override void initTooltipsImpl()
        {
            setTooltip(numCoinValue, "The base coin value of the item (Recorded in Copper Pieces) " + 
                "(Conversion Rate: 1 CP = 1/10 SP. 1 SP = 1/10 GP. 1 GP = 1/10 PP.  1 PP = 10,000 CP)", true);
            setTooltip(numWeight, "The weight (in pounds) of this item.", false);
            setTooltip(numStackSize, "The number of items that can be placed into a single stack (default is 1).", true);
        }

        public override void initNewImpl()
        {
            ComboUtils.fillCombo(cboSize, "ref_size", "name", "ref_size_id", Globals.SIZE_Medium);
            ComboUtils.fillCombo(cboItemType, "ref_item_type", "name", "ref_item_type_id", Globals.ITEM_TYPE_Simple);
            ComboUtils.fillCombo(cboMaterialType, "ref_material", "name", "ref_material_id", 0);
            ComboUtils.fillCombo(cboDifficulty, "ref_difficulty", "name", "ref_difficulty_id", 0);
            ComboUtils.fillCombo(cboCondition, "ref_condition", "name", "ref_condition_id", 0);

            {
                mArmorControl.initNewImpl();
                mBookControl.initNewImpl();
                mCorpseControl.initNewImpl();
                mContainerControl.initNewImpl();
                mDrinkContainerControl.initNewImpl();
                mFoodControl.initNewImpl();
                mFormulaControl.initNewImpl();
                mFurnitureControl.initNewImpl();
                mKeyControl.initNewImpl();
                mLightControl.initNewImpl();
                mLockControl.initNewImpl();
                mMachineControl.initNewImpl();
                mMagicalNodeControl.initNewImpl();
                mPortalControl.initNewImpl();
                mPotionControl.initNewImpl();
                mQuestControl.initNewImpl();
                mReagantControl.initNewImpl();
                mResourceNodeControl.initNewImpl();
                mResourceControl.initNewImpl();
                mRuneControl.initNewImpl();
                mSimpleControl.initNewImpl();
                mToolControl.initNewImpl();
                mTrapControl.initNewImpl();
                mTreasureControl.initNewImpl();
                mVehicleControl.initNewImpl();
                mWeaponControl.initNewImpl();
            }
        }

        public override void initContentImpl(int aId)
        {
            DataTable dt = Database.getData("item_def", "item_def_id", aId, null);
            if (dt == null)
            {
                Program.MainForm.logError("Could not load Item [" + aId + "]");
                return;
            }
            if (dt.Rows.Count == 0)
            {
                Program.MainForm.logError("Could not load Item [" + aId + "]");
                return;
            }

            Program.MainForm.logInfo("Item loaded [" + aId + "]");
            DataRow dataRow = dt.Rows[0];

            txtSystemName.Text = dataRow["system_name"].ToString();
            txtDisplayName.Text = dataRow["display_name"].ToString();
            txtDisplayDescription.Text = dataRow["display_description"].ToString();

            int flags = Database.getNullableId(dataRow, "flags");
            chkIsTakeable.Checked = ((flags & Globals.ITEM_FLAG_Takeable) != 0) ? true : false;
            chkIsTradeable.Checked = ((flags & Globals.ITEM_FLAG_Tradeable) != 0) ? true : false;
            chkIsRepairable.Checked = ((flags & Globals.ITEM_FLAG_Repairable) != 0) ? true : false;
            chkIsHidden.Checked = ((flags & Globals.ITEM_FLAG_Hidden) != 0) ? true : false;

            numCoinValue.Value = (int)dataRow["coin_value"];
            numWeight.Value = (int)dataRow["weight"];
            numStackSize.Value = (int)dataRow["max_stack_size"];
            ComboUtils.fillCombo(cboCondition, "ref_condition", "name", "ref_condition_id", Database.getNullableId(dataRow, "ref_condition_id"));
            numRequiredLevel.Value = Database.getNullableId(dataRow, "required_level");

            EditorFactory.setupLink(linkUseAbility, EditorSystemType.Ability, Database.getNullableId(dataRow, "use_ability_def_id"));
            if (linkUseAbility.Text != "")
            {
                chkIsUseable.Checked = true;
                numUseFrequency.Value = (int)dataRow["use_ability_frequency"];
            }

            ComboUtils.fillCombo(cboSize, "ref_size", "name", "ref_size_id", (int)dataRow["ref_size_id"]);
            ComboUtils.fillCombo(cboItemType, "ref_item_type", "name", "ref_item_type_id", (int)dataRow["ref_item_type_id"]);
            ComboUtils.fillCombo(cboMaterialType, "ref_material", "name", "ref_material_id", (int)dataRow["ref_material_id"]);

            EditorFactory.setupLink(linkSpotSkill, EditorSystemType.Statistic, Database.getNullableId(dataRow, "spot_statistic_def_id"));
            ComboUtils.fillCombo(cboDifficulty, "ref_difficulty", "name", "ref_difficulty_id", Database.getNullableId(dataRow, "ref_difficulty_id"));

            EditorFactory.setupLink(linkSocket, EditorSystemType.Slot, Database.getNullableId(dataRow, "socket_slot_def_id"));
            if (linkSocket.Text != "")
                chkIsSocketed.Checked = true;

            EditorFactory.setupLink(linkTrap, EditorSystemType.Item, Database.getNullableId(dataRow, "trap_item_def_id"));
            if (linkTrap.Text != "")
                chkIsTrapped.Checked = true;

            dt.Dispose();
            ControlName = txtSystemName.Text;

            // Choose the proper sub-item type, load the data into all controls
            int itemTypeId = (int)dataRow["ref_item_type_id"];
            switchItemType(Globals.ITEM_TYPE_Simple);
            switchItemType(itemTypeId);
            {
                mArmorControl.loadItemData(Id);
                mBookControl.loadItemData(Id);
                mCorpseControl.loadItemData(Id);
                mContainerControl.loadItemData(Id);
                mDrinkContainerControl.loadItemData(Id);
                mFoodControl.loadItemData(Id);
                mFormulaControl.loadItemData(Id);
                mFurnitureControl.loadItemData(Id);
                mKeyControl.loadItemData(Id);
                mLightControl.loadItemData(Id);
                mLockControl.loadItemData(Id);
                mMachineControl.loadItemData(Id);
                mMagicalNodeControl.loadItemData(Id);
                mPortalControl.loadItemData(Id);
                mPotionControl.loadItemData(Id);
                mQuestControl.loadItemData(Id);
                mReagantControl.loadItemData(Id);
                mResourceNodeControl.loadItemData(Id);
                mResourceControl.loadItemData(Id);
                mRuneControl.loadItemData(Id);
                mSimpleControl.loadItemData(Id);
                mToolControl.loadItemData(Id);
                mTrapControl.loadItemData(Id);
                mTreasureControl.loadItemData(Id);
                mVehicleControl.loadItemData(Id);
                mWeaponControl.loadItemData(Id);
            }

            loadSlotsGrid(aId);
            loadSkillsGrid(aId);
            loadStatModGrid(aId);
        }

        private void loadSlotsGrid(int aId)
        {
            gridSlots.Rows.Clear();

            DataTable dt = Database.getData("item_slot_map", "item_def_id", aId, null);
            if (dt == null) return;
            foreach (DataRow rowView in dt.Rows)
            {
                int gridIndex = gridSlots.Rows.Add();
                DataGridViewRow gridRow = gridSlots.Rows[gridIndex];

                DataGridViewLinkCell cell = gridRow.Cells["slot_def_id"] as DataGridViewLinkCell;
                cell.Value = EditorFactory.getBrowseInfo(EditorSystemType.Slot, rowView, "slot_def_id");

                gridRow.Tag = (int)rowView["item_slot_map_id"];
            }
            dt.Dispose();
        }

        private void loadSkillsGrid(int aId)
        {
            gridSkills.Rows.Clear();

            DataTable dt = Database.getData("item_required_skill_map", "item_def_id", aId, null);
            if (dt == null) return;
            foreach (DataRow rowView in dt.Rows)
            {
                int gridIndex = gridSkills.Rows.Add();
                DataGridViewRow gridRow = gridSkills.Rows[gridIndex];

                DataGridViewLinkCell cellSkill = gridRow.Cells["statistic_def_id"] as DataGridViewLinkCell;
                cellSkill.Value = EditorFactory.getBrowseInfo(EditorSystemType.Statistic, rowView, "statistic_def_id");

                DataGridViewNumericUpDownElements.DataGridViewNumericUpDownCell cellValue = gridRow.Cells["value"] as DataGridViewNumericUpDownElements.DataGridViewNumericUpDownCell;
                cellValue.Value = (int)rowView["value"];

                gridRow.Tag = (int)rowView["item_required_skill_map_id"];
            }
            dt.Dispose();
        }

        private void loadStatModGrid(int aId)
        {
            gridStatMods.Rows.Clear();

            DataTable dt = Database.getData("item_statistic_map", "item_def_id", aId, null);
            if (dt == null) return;
            foreach (DataRow rowView in dt.Rows)
            {
                int gridIndex = gridStatMods.Rows.Add();
                DataGridViewRow gridRow = gridStatMods.Rows[gridIndex];

                DataGridViewLinkCell cellStat = gridRow.Cells["statistic_def_id"] as DataGridViewLinkCell;
                cellStat.Value = EditorFactory.getBrowseInfo(EditorSystemType.Statistic, rowView, "statistic_def_id");

                DataGridViewNumericUpDownElements.DataGridViewNumericUpDownCell cellMod = gridRow.Cells["value"] as DataGridViewNumericUpDownElements.DataGridViewNumericUpDownCell;
                cellMod.Value = (int)rowView["value"];

                gridRow.Tag = (int)rowView["item_statistic_map_id"];
            }
            dt.Dispose();
        }

        public override bool saveImpl()
        {
            gridSlots.EndEdit();
            gridSkills.EndEdit();
            gridStatMods.EndEdit();

            try
            {
                Database.beginTransaction();

                if (Id == 0)
                {
                    Id = Database.createData("item_def", "class_id", ClassId, "system_name", txtSystemName.Text);
                    if (Id == 0) throw new Exception("Failed to create new Item Def");
                }
                else
                    Database.updateData("item_def", "item_def_id", Id, "system_name", txtSystemName.Text); 
                mCurrentControl.preSaveItemData(Id);

                Database.updateData("item_def", "item_def_id", Id, "display_name", txtDisplayName.Text);
                Database.updateData("item_def", "item_def_id", Id, "display_description", txtDisplayDescription.Text);
                Database.updateData("item_def", "item_def_id", Id, "coin_value", (int)numCoinValue.Value);
                Database.updateData("item_def", "item_def_id", Id, "weight", (int)numWeight.Value);
                Database.updateData("item_def", "item_def_id", Id, "max_stack_size", (int)numStackSize.Value);
                Database.updateData("item_def", "item_def_id", Id, "required_level", (int)numRequiredLevel.Value);
                Database.updateData("item_def", "item_def_id", Id, "socket_slot_def_id", getContentLinkId(linkSocket));
                Database.updateData("item_def", "item_def_id", Id, "trap_item_def_id", getContentLinkId(linkTrap));
                Database.updateData("item_def", "item_def_id", Id, "ref_material_id", (cboMaterialType.SelectedItem as TagInfo).Id);
                Database.updateData("item_def", "item_def_id", Id, "ref_size_id", (cboSize.SelectedItem as TagInfo).Id);

                int flags = 
                        (chkIsTakeable.Checked ? Globals.ITEM_FLAG_Takeable : 0) |
                        (chkIsTradeable.Checked ? Globals.ITEM_FLAG_Tradeable : 0) |
                        (chkIsRepairable.Checked ? Globals.ITEM_FLAG_Repairable : 0) |
                        (chkIsHidden.Checked ? Globals.ITEM_FLAG_Hidden : 0);
                Database.updateData("item_def", "item_def_id", Id, "flags", flags);

                if (chkIsHidden.Checked)
                {
                    Database.updateData("item_def", "item_def_id", Id, "spot_statistic_def_id", getContentLinkId(linkSpotSkill));
                    Database.updateData("item_def", "item_def_id", Id, "ref_difficulty_id", (cboDifficulty.SelectedItem as TagInfo).Id);
                }

                if (chkIsRepairable.Checked)
                {
                    Database.updateData("item_def", "item_def_id", Id, "ref_condition_id", (cboCondition.SelectedItem as TagInfo).Id);
                }

                if (chkIsUseable.Checked)
                {
                    Database.updateData("item_def", "item_def_id", Id, "use_ability_def_id", getContentLinkId(linkUseAbility));
                    Database.updateData("item_def", "item_def_id", Id, "use_ability_frequency", (int)numUseFrequency.Value);
                }

                Database.updateData("item_def", "item_def_id", Id, "ref_item_type_id", (cboItemType.SelectedItem as TagInfo).Id);

                // Invoke all the pre-clears, and then the save
                {
                    if (mArmorControl != mCurrentControl) mArmorControl.preClearItemData(Id);
                    if (mBookControl != mCurrentControl) mBookControl.preClearItemData(Id);
                    if (mCorpseControl != mCurrentControl) mCorpseControl.preClearItemData(Id);
                    if (mContainerControl != mCurrentControl) mContainerControl.preClearItemData(Id);
                    if (mDrinkContainerControl != mCurrentControl) mDrinkContainerControl.preClearItemData(Id);
                    if (mFoodControl != mCurrentControl) mFoodControl.preClearItemData(Id);
                    if (mFormulaControl != mCurrentControl) mFormulaControl.preClearItemData(Id);
                    if (mFurnitureControl != mCurrentControl) mFurnitureControl.preClearItemData(Id);
                    if (mKeyControl != mCurrentControl) mKeyControl.preClearItemData(Id);
                    if (mLightControl != mCurrentControl) mLightControl.preClearItemData(Id);
                    if (mLockControl != mCurrentControl) mLockControl.preClearItemData(Id);
                    if (mMachineControl != mCurrentControl) mMachineControl.preClearItemData(Id);
                    if (mMagicalNodeControl != mCurrentControl) mMagicalNodeControl.preClearItemData(Id);
                    if (mPortalControl != mCurrentControl) mPortalControl.preClearItemData(Id);
                    if (mPotionControl != mCurrentControl) mPotionControl.preClearItemData(Id);
                    if (mQuestControl != mCurrentControl) mQuestControl.preClearItemData(Id);
                    if (mReagantControl != mCurrentControl) mReagantControl.preClearItemData(Id);
                    if (mResourceNodeControl != mCurrentControl) mResourceNodeControl.preClearItemData(Id);
                    if (mResourceControl != mCurrentControl) mResourceControl.preClearItemData(Id);
                    if (mRuneControl != mCurrentControl) mRuneControl.preClearItemData(Id);
                    if (mSimpleControl != mCurrentControl) mSimpleControl.preClearItemData(Id);
                    if (mToolControl != mCurrentControl) mToolControl.preClearItemData(Id);
                    if (mTrapControl != mCurrentControl) mTrapControl.preClearItemData(Id);
                    if (mTreasureControl != mCurrentControl) mTreasureControl.preClearItemData(Id);
                    if (mVehicleControl != mCurrentControl) mVehicleControl.preClearItemData(Id);
                    if (mWeaponControl != mCurrentControl) mWeaponControl.preClearItemData(Id);
                    mCurrentControl.saveItemData(Id);
                }

                // Invoke all the post saves
                {
                    mArmorControl.postSaveItemData(Id, mArmorControl == mCurrentControl);
                    mBookControl.postSaveItemData(Id, mBookControl == mCurrentControl);
                    mContainerControl.postSaveItemData(Id, mContainerControl == mCurrentControl);
                    mCorpseControl.postSaveItemData(Id, mCorpseControl == mCurrentControl);
                    mDrinkContainerControl.postSaveItemData(Id, mDrinkContainerControl == mCurrentControl);
                    mFoodControl.postSaveItemData(Id, mFoodControl == mCurrentControl);
                    mFormulaControl.postSaveItemData(Id, mFormulaControl == mCurrentControl);
                    mFurnitureControl.postSaveItemData(Id, mFurnitureControl == mCurrentControl);
                    mKeyControl.postSaveItemData(Id, mKeyControl == mCurrentControl);
                    mLightControl.postSaveItemData(Id, mLightControl == mCurrentControl);
                    mLockControl.postSaveItemData(Id, mLockControl == mCurrentControl);
                    mMachineControl.postSaveItemData(Id, mMachineControl == mCurrentControl);
                    mMagicalNodeControl.postSaveItemData(Id, mMagicalNodeControl == mCurrentControl);
                    mPortalControl.postSaveItemData(Id, mPortalControl == mCurrentControl);
                    mPotionControl.postSaveItemData(Id, mPotionControl == mCurrentControl);
                    mQuestControl.postSaveItemData(Id, mQuestControl == mCurrentControl);
                    mReagantControl.postSaveItemData(Id, mReagantControl == mCurrentControl);
                    mResourceNodeControl.postSaveItemData(Id, mResourceNodeControl == mCurrentControl);
                    mResourceControl.postSaveItemData(Id, mResourceControl == mCurrentControl);
                    mRuneControl.postSaveItemData(Id, mRuneControl == mCurrentControl);
                    mSimpleControl.postSaveItemData(Id, mSimpleControl == mCurrentControl);
                    mToolControl.postSaveItemData(Id, mToolControl == mCurrentControl);
                    mTrapControl.postSaveItemData(Id, mTrapControl == mCurrentControl);
                    mTreasureControl.postSaveItemData(Id, mTreasureControl == mCurrentControl);
                    mVehicleControl.postSaveItemData(Id, mVehicleControl == mCurrentControl);
                    mWeaponControl.postSaveItemData(Id, mWeaponControl == mCurrentControl);
                }

                saveSlotsGrid(Id);
                saveSkillsGrid(Id);
                saveStatModsGrid(Id);

                Database.commitTransaction();

                initContent(Id);
                return true;
            }
            catch (SqlException ex)
            {
                Database.handleException(ex, "Error saving item [" + ControlName + "]");
                Database.rollbackTransaction();
                return false;
            }
        }

        private void saveSlotsGrid(int aDefId)
        {
            Database.deleteData("item_slot_map", "item_def_id", aDefId);
            foreach (DataGridViewRow gridRow in gridSlots.Rows)
            {
                if (!gridRow.IsNewRow && gridRow.Visible)
                {
                    EditorBrowseInfo slotDefIdBrowseInfo = gridRow.Cells["slot_def_id"].Value as EditorBrowseInfo;
                    if (slotDefIdBrowseInfo == null) continue;

                    int rowId = Database.createData("item_slot_map", "item_def_id", aDefId, null, null);
                    if (rowId == 0) throw new Exception("Failed to create new row in item_slot_map");

                    Database.updateData("item_slot_map", "item_slot_map_id", rowId, "slot_def_id", slotDefIdBrowseInfo.Id);
                }
            }
            gridSlots.flushDeletedRows();
        }

        private void saveSkillsGrid(int aDefId)
        {
            Database.deleteData("item_required_skill_map", "item_def_id", aDefId);
            foreach (DataGridViewRow gridRow in gridSkills.Rows)
            {
                if (!gridRow.IsNewRow && gridRow.Visible)
                {
                    EditorBrowseInfo skillDefIdBrowseInfo = gridRow.Cells["statistic_def_id"].Value as EditorBrowseInfo;
                    if (skillDefIdBrowseInfo == null) continue;

                    int rowId = Database.createData("item_required_skill_map", "item_def_id", aDefId, null, null);
                    if (rowId == 0) throw new Exception("Failed to create new row in item_required_skill_map");

                    Database.updateData("item_required_skill_map", "item_required_skill_map_id", rowId, "statistic_def_id", skillDefIdBrowseInfo.Id);
                    if (gridRow.Cells["value"].Value == null)
                        Database.updateData("item_required_skill_map", "item_required_skill_map_id", rowId, "value", 1);
                    else
                        Database.updateData("item_required_skill_map", "item_required_skill_map_id", rowId, "value", (int)gridRow.Cells["value"].Value);
                }
            }
            gridSkills.flushDeletedRows();
        }

        private void saveStatModsGrid(int aDefId)
        {
            Database.deleteData("item_statistic_map", "item_def_id", aDefId);
            foreach (DataGridViewRow gridRow in gridStatMods.Rows)
            {
                if (!gridRow.IsNewRow && gridRow.Visible)
                {
                    EditorBrowseInfo statDefIdBrowseInfo = gridRow.Cells["statistic_def_id"].Value as EditorBrowseInfo;
                    if (statDefIdBrowseInfo == null) continue;

                    int rowId = Database.createData("item_statistic_map", "item_def_id", aDefId, null, null);
                    if (rowId == 0) throw new Exception("Failed to create new row in item_statistic_map");

                    Database.updateData("item_statistic_map", "item_statistic_map_id", rowId, "statistic_def_id", statDefIdBrowseInfo.Id);
                    Database.updateData("item_statistic_map", "item_statistic_map_id", rowId, "value", (int)gridRow.Cells["value"].Value);
                }
            }
            gridStatMods.flushDeletedRows();
        }

        public override bool isSaveValid(bool aGiveFeedback)
        {
            bool valid = true;
            Color errorColor = Color.DarkRed;

            // You cannot save an item without choosing a type
            if (null == mCurrentControl)
            {
                valid = false;
                Program.MainForm.setStatusMessage("An item type must be chosen");
                cboItemType.BackColor = errorColor;
            }
            else
            {
                cboItemType.BackColor = Color.Empty;
            }

            if (null != mCurrentControl)
            {
                valid = mCurrentControl.isSaveValid(aGiveFeedback, errorColor);
            }

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

            if (chkIsHidden.Checked)
            {
                if (linkSpotSkill.Text == "")
                {
                    if (aGiveFeedback)
                    {
                        Program.MainForm.setStatusMessage("Missing Spot Skill.");
                        linkSpotSkill.BackColor = errorColor;
                    }
                    valid = false;
                }
                else
                {
                    linkSpotSkill.BackColor = Color.Empty;
                }
            }
            else
            {
                linkSpotSkill.BackColor = Color.Empty;
            }

            if (chkIsUseable.Checked)
            {
                if (linkUseAbility.Text == "")
                {
                    if (aGiveFeedback)
                    {
                        Program.MainForm.setStatusMessage("Missing Ability.");
                        linkUseAbility.BackColor = errorColor;
                    }
                    valid = false;
                }
                else
                {
                    linkUseAbility.BackColor = Color.Empty;
                }
            }
            else
            {
                linkUseAbility.BackColor = Color.Empty;
            }

            if (chkIsHidden.Checked)
            {
                if (cboDifficulty.SelectedItem == null)
                {
                    if (aGiveFeedback)
                    {
                        Program.MainForm.setStatusMessage("Missing Spot Difficulty.");
                        cboDifficulty.BackColor = errorColor;
                    }
                    valid = false;
                }
                else
                {
                    cboCondition.BackColor = Color.Empty;
                }
            }
            else
            {
                cboDifficulty.BackColor = Color.Empty;
            }

            if (chkIsRepairable.Checked)
            {
                if (cboCondition.SelectedItem == null)
                {
                    if (aGiveFeedback)
                    {
                        Program.MainForm.setStatusMessage("Missing Condition.");
                        cboCondition.BackColor = errorColor;
                    }
                    valid = false;
                }
                else
                {
                    cboCondition.BackColor = Color.Empty;
                }
            }
            else
            {
                cboCondition.BackColor = Color.Empty;
            }

            if (chkIsTrapped.Checked)
            {
                if (linkTrap.Text == "")
                {
                    if (aGiveFeedback)
                    {
                        Program.MainForm.setStatusMessage("Missing Trap.");
                        linkTrap.BackColor = errorColor;
                    }
                    valid = false;
                }
                else
                {
                    linkTrap.BackColor = Color.Empty;
                }
            }
            else
            {
                linkTrap.BackColor = Color.Empty;
            }

            if (chkIsSocketed.Checked)
            {
                if (linkSocket.Text == "")
                {
                    if (aGiveFeedback)
                    {
                        Program.MainForm.setStatusMessage("Missing Socket.");
                        linkSocket.BackColor = errorColor;
                    }
                    valid = false;
                }
                else
                {
                    linkSocket.BackColor = Color.Empty;
                }
            }
            else
            {
                linkSocket.BackColor = Color.Empty;
            }

            return valid;
        }

        private void switchItemType(int aNewType)
        {
            if (mCurrentControl != null)
            {
                mCurrentControl.Hide();
                panelItemType.Controls.Remove(mCurrentControl);
            }

            mItemType = aNewType;

            if (mItemType == Globals.ITEM_TYPE_Armor)
            {
                mArmorControl.initNewImpl();
                mCurrentControl = mArmorControl;
                cboItemType.SelectedText = "Armor";
            }
            else if (mItemType == Globals.ITEM_TYPE_Book)
            {
                mBookControl.initNewImpl();
                mCurrentControl = mBookControl;
                cboItemType.SelectedText = "Book";
            }
            else if (mItemType == Globals.ITEM_TYPE_Container)
            {
                mContainerControl.initNewImpl();
                mCurrentControl = mContainerControl;
                cboItemType.SelectedText = "Container";
            }
            else if (mItemType == Globals.ITEM_TYPE_Corpse)
            {
                mCorpseControl.initNewImpl();
                mCurrentControl = mCorpseControl;
                cboItemType.SelectedText = "Corpse";
            }
            else if (mItemType == Globals.ITEM_TYPE_DrinkContainer)
            {
                mDrinkContainerControl.initNewImpl();
                mCurrentControl = mDrinkContainerControl;
                cboItemType.SelectedText = "Drink Container";
            }
            else if (mItemType == Globals.ITEM_TYPE_Food)
            {
                mFoodControl.initNewImpl();
                mCurrentControl = mFoodControl;
                cboItemType.SelectedText = "Food";
            }
            else if (mItemType == Globals.ITEM_TYPE_Formula)
            {
                mFormulaControl.initNewImpl();
                mCurrentControl = mFormulaControl;
                cboItemType.SelectedText = "Formula";
            }
            else if (mItemType == Globals.ITEM_TYPE_Furniture)
            {
                mFurnitureControl.initNewImpl();
                mCurrentControl = mFurnitureControl;
                cboItemType.SelectedText = "Furniture";
            }
            else if (mItemType == Globals.ITEM_TYPE_Key)
            {
                mKeyControl.initNewImpl();
                mCurrentControl = mKeyControl;
                cboItemType.SelectedText = "Key";
            }
            else if (mItemType == Globals.ITEM_TYPE_Light)
            {
                mLightControl.initNewImpl();
                mCurrentControl = mLightControl;
                cboItemType.SelectedText = "Light";
            }
            else if (mItemType == Globals.ITEM_TYPE_Lock)
            {
                mLockControl.initNewImpl();
                mCurrentControl = mLockControl;
                cboItemType.SelectedText = "Lock";
            }
            else if (mItemType == Globals.ITEM_TYPE_Machine)
            {
                mMachineControl.initNewImpl();
                mCurrentControl = mMachineControl;
                cboItemType.SelectedText = "Machine";
            }
            else if (mItemType == Globals.ITEM_TYPE_MagicalNode)
            {
                mMagicalNodeControl.initNewImpl();
                mCurrentControl = mMagicalNodeControl;
                cboItemType.SelectedText = "Magical Node";
            }
            else if (mItemType == Globals.ITEM_TYPE_Portal)
            {
                mPortalControl.initNewImpl();
                mCurrentControl = mPortalControl;
                cboItemType.SelectedText = "Portal";
            }
            else if (mItemType == Globals.ITEM_TYPE_Potion)
            {
                mPotionControl.initNewImpl();
                mCurrentControl = mPotionControl;
                cboItemType.SelectedText = "Potion";
            }
            else if (mItemType == Globals.ITEM_TYPE_QuestItem)
            {
                mQuestControl.initNewImpl();
                mCurrentControl = mQuestControl;
                cboItemType.SelectedText = "Quest Item";
            }
            else if (mItemType == Globals.ITEM_TYPE_Reagant)
            {
                mReagantControl.initNewImpl();
                mCurrentControl = mReagantControl;
                cboItemType.SelectedText = "Reagant";
            }
            else if (mItemType == Globals.ITEM_TYPE_ResourceNode)
            {
                mResourceNodeControl.initNewImpl();
                mCurrentControl = mResourceNodeControl;
                cboItemType.SelectedText = "Resource Node";
            }
            else if (mItemType == Globals.ITEM_TYPE_Resource)
            {
                mResourceControl.initNewImpl();
                mCurrentControl = mResourceControl;
                cboItemType.SelectedText = "Resource";
            }
            else if (mItemType == Globals.ITEM_TYPE_Rune)
            {
                mRuneControl.initNewImpl();
                mCurrentControl = mRuneControl;
                cboItemType.SelectedText = "Rune";
            }
            else if (mItemType == Globals.ITEM_TYPE_Simple)
            {
                mSimpleControl.initNewImpl();
                mCurrentControl = mSimpleControl;
                cboItemType.SelectedText = "Simple";
            }
            else if (mItemType == Globals.ITEM_TYPE_Tool)
            {
                mToolControl.initNewImpl();
                mCurrentControl = mToolControl;
                cboItemType.SelectedText = "Tool";
            }
            else if (mItemType == Globals.ITEM_TYPE_Trap)
            {
                mTrapControl.initNewImpl();
                mCurrentControl = mTrapControl;
                cboItemType.SelectedText = "Trap";
            }
            else if (mItemType == Globals.ITEM_TYPE_Treasure)
            {
                mTreasureControl.initNewImpl();
                mCurrentControl = mTreasureControl;
                cboItemType.SelectedText = "Treasure";
            }
            else if (mItemType == Globals.ITEM_TYPE_Vehicle)
            {
                mVehicleControl.initNewImpl();
                mCurrentControl = mVehicleControl;
                cboItemType.SelectedText = "Vehicle";
            }
            else if (mItemType == Globals.ITEM_TYPE_Weapon)
            {
                mWeaponControl.initNewImpl();
                mCurrentControl = mWeaponControl;
                cboItemType.SelectedText = "Weapon";
            }
            else
            {
                mCurrentControl = null;
                cboItemType.SelectedText = "Simple";
            }

            if (mCurrentControl != null)
            {
                mCurrentControl.Dock = DockStyle.Fill;
                panelItemType.Controls.Add(mCurrentControl);
                mCurrentControl.Show();
            }
        }

        private void onItemTypeChanged(object sender, EventArgs e)
        {
            if (cboItemType.SelectedItem == null)
                return;
            switchItemType((cboItemType.SelectedItem as TagInfo).Id);
        }

        private void chkIsHidden_CheckedChanged(object sender, EventArgs e)
        {
            if (chkIsHidden.Checked)
            {
                lblDifficulty.Visible = true;
                cboDifficulty.Visible = true;
                lblSpotSkill.Visible = true;
                linkSpotSkill.Visible = true;
                //grpHidden.Visible = true;
            }
            else
            {
                lblDifficulty.Visible = false;
                cboDifficulty.Visible = false;
                lblSpotSkill.Visible = false;
                linkSpotSkill.Visible = false;
                //grpHidden.Visible = false;
            }
        }

        private void chkIsSocketed_CheckedChanged(object sender, EventArgs e)
        {
            if (chkIsSocketed.Checked)
            {
                linkSocket.Visible = true;
            }
            else
            {
                linkSocket.Visible = false;
                linkSocket.clear();
            }
        }

        private void chkIsTrapped_CheckedChanged(object sender, EventArgs e)
        {
            if (chkIsTrapped.Checked)
            {
                linkTrap.Visible = true;
            }
            else
            {
                linkTrap.Visible = false;
                linkTrap.clear();
            }
        }

        private void chkIsRepairable_CheckedChanged(object sender, EventArgs e)
        {
            if (chkIsRepairable.Checked)
            {
                cboCondition.Visible = true;
                lblCondition.Visible = true;
            }
            else
            {
                cboCondition.Visible = false;
                lblCondition.Visible = false;
            }
        }

        private void chkIsUseable_CheckedChanged(object sender, EventArgs e)
        {
            if (chkIsUseable.Checked)
            {
                lblUseAbility.Visible = true;
                linkUseAbility.Visible = true;
                lblUseFreq.Visible = true;
                numUseFrequency.Visible = true;
            }
            else
            {
                lblUseAbility.Visible = false;
                linkUseAbility.Visible = false;
                lblUseFreq.Visible = false;
                numUseFrequency.Visible = false;
                linkUseAbility.clear();
            }
        }
    }


    // **************************************************
    // ItemBuilder
    // **************************************************
    public class ItemBuilder : EditorBuilder
    {
        public ItemBuilder()
            : base(EditorSystemType.Item, "Item", "Items")
        {
            // @TODO: Give unique icons to each system for easier identification
            Icon = Icon.FromHandle(Properties.Resources.stat_16.GetHicon());
        }

        public override BaseEditorControl create(int aClassId)
        {
            return new ItemControl(aClassId);
        }

        public override int populateBrowseNode(TreeNode aParentNode, int aClassId, ContextMenuStrip aMenu, string aFilter)
        {
            return populateBrowseNodeImpl(aParentNode, aClassId, "item_def", "system_name", "class_id = " + aClassId, "item_def_id", aMenu, aFilter);
        }

        protected override void deleteImpl(int aId)
        {
            Database.deleteData("item_slot_map", "item_def_id", aId);
            Database.deleteData("item_required_skill_map", "item_def_id", aId);
            Database.deleteData("item_statistic_map", "item_def_id", aId);

            // Delete any residual rows in sub-item map tables
            {
                Database.deleteData("item_armor_stat_map", "item_def_id", aId);
                Database.deleteData("item_armor_map", "item_def_id", aId);

                Database.deleteData("item_book_map", "item_def_id", aId);
                Database.deleteData("item_container_map", "item_def_id", aId);
                Database.deleteData("item_container_map_item_map", "item_def_id", aId);
                Database.deleteData("item_drinkcontainer_map", "item_def_id", aId);
                Database.deleteData("item_food_map", "item_def_id", aId);
                
                Database.deleteData("item_formula_resource_map", "item_def_id", aId);
                Database.deleteData("item_formula_map", "item_def_id", aId);
                
                Database.deleteData("item_furniture_map", "item_def_id", aId);
                Database.deleteData("item_light_map", "item_def_id", aId);
                Database.deleteData("item_lock_map", "item_def_id", aId);
                Database.deleteData("item_machine_map", "item_def_id", aId);
                Database.deleteData("item_magicalnode_map", "item_def_id", aId);
                Database.deleteData("item_portal_map", "item_def_id", aId);
                Database.deleteData("item_potion_map", "item_def_id", aId);
                Database.deleteData("item_resource_node_map", "item_def_id", aId);
                Database.deleteData("item_rune_map", "item_def_id", aId);
                Database.deleteData("item_tool_map", "item_def_id", aId);
                Database.deleteData("item_trap_map", "item_def_id", aId);
                Database.deleteData("item_treasure_map", "item_def_id", aId);
                
                Database.deleteData("item_vehicle_terrain_map", "item_def_id", aId);
                Database.deleteData("item_vehicle_map", "item_def_id", aId);

                Database.deleteData("item_weapon_map", "item_def_id", aId);
            }

            Database.deleteData("item_def", "item_def_id", aId);
        }

        public override void move(int aId, int aNewClassId)
        {
            moveToClass("item_def", "item_def_id", aId, aNewClassId);
        }

        public override string idToText(object aId)
        {
            return Database.getData("item_def", "item_def_id", (int)aId, "system_name").ToString();
        }

        public override EditorBrowseInfo getBrowseInfo(int aId)
        {
            return getSimpleBrowseInfo("item_def", aId, "system_name", "item_def_id");
        }
        public override void cookData()
        {
            Cooker.Instance.cookCategoryTable("item_def");
        }

    }
}

