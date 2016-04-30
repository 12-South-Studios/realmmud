using System.Windows.Forms;

namespace Realm.Edit
{
    public partial class GameConstants : Form
    {
       /* static private readonly Dictionary<int, GameConstant> Constants = new Dictionary<int, GameConstant>();
        private readonly IGameConstantDal _gameConstantDal;

        public GameConstants(IGameConstantDal gameConstantDal)
        {
            InitializeComponent();
            _gameConstantDal = gameConstantDal;
        }

        #region Helper Methods
        public static int GetConstant(int constantId, int defaultValue)
        {
            if (Constants == null || !Constants.ContainsKey(constantId)) return defaultValue;
            return Constants[constantId].IntValue.GetValueOrDefault(defaultValue);
        }
        public static float GetConstant(int constantId, float defaultValue)
        {
            if (Constants == null || !Constants.ContainsKey(constantId)) return defaultValue;
            return Constants[constantId].FloatValue.GetValueOrDefault(defaultValue);
        }
        public static string GetConstant(int constantId, string defaultValue)
        {
            if (Constants == null || !Constants.ContainsKey(constantId)) return defaultValue;
            return !string.IsNullOrEmpty(Constants[constantId].StringValue) 
                ? defaultValue 
                : Constants[constantId].StringValue;
        }
        public static bool GetConstant(int constantId, bool defaultValue)
        {
            if (Constants == null || !Constants.ContainsKey(constantId)) return defaultValue;
            return Constants[constantId].BoolValue.GetValueOrDefault(defaultValue);
        }

        public static void SetConstant(int constantId, int value)
        {
            if (Constants == null || !Constants.ContainsKey(constantId)) return;
            Constants[constantId].IntValue = value;
        }
        public static void SetConstant(int constantId, float value)
        {
            if (Constants == null || !Constants.ContainsKey(constantId)) return;
            Constants[constantId].FloatValue = value;
        }
        public static void SetConstant(int constantId, string value)
        {
            if (Constants == null || !Constants.ContainsKey(constantId)) return;
            Constants[constantId].StringValue = value;
        }
        public static void SetConstant(int constantId, bool value)
        {
            if (Constants == null || !Constants.ContainsKey(constantId)) return;
            Constants[constantId].BoolValue = value;
        }
        #endregion

        private void LoadGameConstants()
        {
            var constantList = _gameConstantDal.GetGameRefConstants();

            pbStatus.Minimum = 0;
            pbStatus.Value = 0;
            pbStatus.Maximum = constantList.Count();

            foreach (var refconstant in constantList)
            {
                var constant = _gameConstantDal.GetGameConstant(refconstant.Id);
                Constants.Add(constant.Id, constant);
                pbStatus.Value++;
            }
        }
        private void SaveGameConstants()
        {
            pbStatus.Minimum = 0;
            pbStatus.Value = 0;
            pbStatus.Maximum = Constants.Count;

            using (var scope = new TransactionScope())
            {
                foreach (var constant in Constants.Values)
                {
                    _gameConstantDal.UpdateGameConstant((short)constant.Id, constant.IntValue, constant.FloatValue, 
                        constant.StringValue, constant.BoolValue);
                    pbStatus.Value++;
                }

                scope.Complete();
            }
        }*/

        /*private void GameConstantsShown(object sender, EventArgs e)
        {
            LoadGameConstants();

            numericUpDownSegmentLength.Value = GetConstant(Globals.Globals.GameConstant_TimeSegment, 500);
            numericUpDownAIBrainTickFrequency.Value = GetConstant(Globals.Globals.GameConstant_AiProcessFrequency, 200);
            numericUpDownAIBucketCount.Value = GetConstant(Globals.Globals.GameConstant_AiBuckets, 10);

            // Gameplay Constants
            /*numericUpDownStatisticTPCost.Value = loadIntConstant(Globals.GAME_CONSTANT_GAMEPLAY_STATISTIC_TP_COST, 5);
            numericUpDownSkillTPCost.Value = loadIntConstant(Globals.GAME_CONSTANT_GAMEPLAY_SKILL_TP_COST, 1);
            numericUpDownStatisticMaxValue.Value = loadIntConstant(Globals.GAME_CONSTANT_GAMEPLAY_STATISTIC_MAX_VALUE, 30);
            numericUpDownSkillMaxValue.Value = loadIntConstant(Globals.GAME_CONSTANT_GAMEPLAY_SKILL_MAX_VALUE, 100);
            numericUpDownHealthRegenRate.Value = loadIntConstant(Globals.GAME_CONSTANT_GAMEPLAY_HEALTH_REGEN, 10);
            numericUpDownHealthRegenCombatRate.Value = loadIntConstant(Globals.GAME_CONSTANT_GAMEPLAY_HEALTH_REGEN_COMBAT, 1);
            numericUpDownHealthRegenRestingRate.Value = loadIntConstant(Globals.GAME_CONSTANT_GAMEPLAY_HEALTH_REGEN_REST, 25);
            numericUpDownStaminaRegenRate.Value = loadIntConstant(Globals.GAME_CONSTANT_GAMEPLAY_STAMINA_REGEN, 10);
            numericUpDownStaminaRegenCombatRate.Value = loadIntConstant(Globals.GAME_CONSTANT_GAMEPLAY_STAMINA_REGEN_COMBAT, 1);
            numericUpDownStaminaRegenRestingRate.Value = loadIntConstant(Globals.GAME_CONSTANT_GAMEPLAY_STAMINA_REGEN_REST, 25);
            numericUpDownManaRegenRate.Value = loadIntConstant(Globals.GAME_CONSTANT_GAMEPLAY_MANA_REGEN, 10);
            numericUpDownManaRegenCombatRate.Value = loadIntConstant(Globals.GAME_CONSTANT_GAMEPLAY_MANA_REGEN_COMBAT, 1);
            numericUpDownManaRegenRestingRate.Value = loadIntConstant(Globals.GAME_CONSTANT_GAMEPLAY_MANA_REGEN_REST, 25);
            numericUpDownSegmentLength.Value = loadIntConstant(Globals.GAME_CONSTANT_GAMEPLAY_SEGMENT_LENGTH, 500);  // milliseconds
            numericUpDownSegmentPerDay.Value = loadIntConstant(Globals.GAME_CONSTANT_GAMEPLAY_SEGMENT_PER_DAY, 14400);
            numericUpDownWalkingStaminaCost.Value = loadIntConstant(Globals.GAME_CONSTANT_GAMEPLAY_WALK_STAMINA_COST, 1);
            numericUpDownSwimmingStaminaCost.Value = loadIntConstant(Globals.GAME_CONSTANT_GAMEPLAY_SWIM_STAMINA_COST, 3);
            numericUpDownFlyingStaminaCost.Value = loadIntConstant(Globals.GAME_CONSTANT_GAMEPLAY_FLY_STAMINA_COST, 2);
            numericUpDownCrawlingStaminaCost.Value = loadIntConstant(Globals.GAME_CONSTANT_GAMEPLAY_CRAWL_STAMINA_COST, 2);
            numericUpDownClimbingStaminaCost.Value = loadIntConstant(Globals.GAME_CONSTANT_GAMEPLAY_CLIMB_STAMINA_COST, 3);
            numericUpDownJumpingStaminaCost.Value = loadIntConstant(Globals.GAME_CONSTANT_GAMEPLAY_JUMP_STAMINA_COST, 3);

            // AI Constants
            numericUpDownAIBucketCount.Value = loadIntConstant(Globals.GAME_CONSTANT_AI_BUCKET_COUNT, 10);
            numericUpDownAIBrainTickFrequency.Value = loadIntConstant(Globals.GAME_CONSTANT_AI_BRAIN_TICK, 200);

            // Character Constants
            numericUpDownCharacterMaxLevels.Value = loadIntConstant(Globals.GAME_CONSTANT_CHARACTER_MAX_LEVEL, 10);
            numericUpDownCharacterMaxSlots.Value = loadIntConstant(Globals.GAME_CONSTANT_CHARACTER_PLAYER_MAX_SLOTS, 2);
            numericUpDownCharacterMaxInventoryStacks.Value = loadIntConstant(Globals.GAME_CONSTANT_CHARACTER_INVENTORY_MAX_STACKS, 25);
            numericUpDownCharacterStartSkillCount.Value = loadIntConstant(Globals.GAME_CONSTANT_CHARACTER_DEFAULT_START_SKILLS, 5);
            numericUpDownCharacterStartAbilityCount.Value = loadIntConstant(Globals.GAME_CONSTANT_CHARACTER_DEFAULT_START_ABILITIES, 2);
            numericUpDownCharacterTPGain.Value = loadIntConstant(Globals.GAME_CONSTANT_CHARACTER_TP_GAIN_LEVEL, 5);
            numericUpDownCharacterMaxLetterLength.Value = loadIntConstant(Globals.GAME_CONSTANT_CHARACTER_LETTER_MAX_LENGTH, 1024);
            numericUpDownCharacterMaxLetterAge.Value = loadIntConstant(Globals.GAME_CONSTANT_CHARACTER_LETTER_MAX_AGE, 2592000); // 30 days
            numericUpDownCharacterMaxAuctionListings.Value = loadIntConstant(Globals.GAME_CONSTANT_CHARACTER_AUCTION_MAX_LISTING, 5);
            numericUpDownCharacterAuctionLength.Value = loadIntConstant(Globals.GAME_CONSTANT_CHARACTER_AUCTION_DEFAULT_DURATION, 604800);   // 7 days
            EditorFactory.setupLink(linkDefaultSpace, EditorSystemType.Space, loadIntConstant(Globals.GAME_CONSTANT_CHARACTER_DEFAULT_SPACE, 0));            
        }

        private void ButtonOkClick(object sender, EventArgs e)
        {
            SetConstant(Globals.Globals.GameConstant_TimeSegment, (int)numericUpDownSegmentLength.Value);
            SetConstant(Globals.Globals.GameConstant_AiProcessFrequency, (int)numericUpDownAIBrainTickFrequency.Value);
            SetConstant(Globals.Globals.GameConstant_AiBuckets, (int)numericUpDownAIBucketCount.Value);

            // Gameplay Constants
            /*insertGameConstant(Globals.GAME_CONSTANT_GAMEPLAY_STATISTIC_TP_COST, (int)numericUpDownStatisticTPCost.Value, 0.0f);
            insertGameConstant(Globals.GAME_CONSTANT_GAMEPLAY_SKILL_TP_COST, (int)numericUpDownSkillTPCost.Value, 0.0f);
            insertGameConstant(Globals.GAME_CONSTANT_GAMEPLAY_STATISTIC_MAX_VALUE, (int)numericUpDownStatisticMaxValue.Value, 0.0f);
            insertGameConstant(Globals.GAME_CONSTANT_GAMEPLAY_SKILL_MAX_VALUE, (int)numericUpDownSkillMaxValue.Value, 0.0f);
            insertGameConstant(Globals.GAME_CONSTANT_GAMEPLAY_HEALTH_REGEN, (int)numericUpDownHealthRegenRate.Value, 0.0f);
            insertGameConstant(Globals.GAME_CONSTANT_GAMEPLAY_HEALTH_REGEN_COMBAT, (int)numericUpDownHealthRegenCombatRate.Value, 0.0f);
            insertGameConstant(Globals.GAME_CONSTANT_GAMEPLAY_HEALTH_REGEN_REST, (int)numericUpDownHealthRegenRestingRate.Value, 0.0f);
            insertGameConstant(Globals.GAME_CONSTANT_GAMEPLAY_MANA_REGEN, (int)numericUpDownManaRegenRate.Value, 0.0f);
            insertGameConstant(Globals.GAME_CONSTANT_GAMEPLAY_MANA_REGEN_COMBAT, (int)numericUpDownManaRegenCombatRate.Value, 0.0f);
            insertGameConstant(Globals.GAME_CONSTANT_GAMEPLAY_MANA_REGEN_REST, (int)numericUpDownManaRegenRestingRate.Value, 0.0f);
            insertGameConstant(Globals.GAME_CONSTANT_GAMEPLAY_STAMINA_REGEN, (int)numericUpDownStaminaRegenRate.Value, 0.0f);
            insertGameConstant(Globals.GAME_CONSTANT_GAMEPLAY_STAMINA_REGEN_COMBAT, (int)numericUpDownStaminaRegenCombatRate.Value, 0.0f);
            insertGameConstant(Globals.GAME_CONSTANT_GAMEPLAY_STAMINA_REGEN_REST, (int)numericUpDownStaminaRegenRestingRate.Value, 0.0f);
            insertGameConstant(Globals.GAME_CONSTANT_GAMEPLAY_SEGMENT_LENGTH, (int)numericUpDownSegmentLength.Value, 0.0f);
            insertGameConstant(Globals.GAME_CONSTANT_GAMEPLAY_SEGMENT_PER_DAY, (int)numericUpDownSegmentPerDay.Value, 0.0f);
            insertGameConstant(Globals.GAME_CONSTANT_GAMEPLAY_WALK_STAMINA_COST, (int)numericUpDownWalkingStaminaCost.Value, 0.0f);
            insertGameConstant(Globals.GAME_CONSTANT_GAMEPLAY_SWIM_STAMINA_COST, (int)numericUpDownSwimmingStaminaCost.Value, 0.0f);
            insertGameConstant(Globals.GAME_CONSTANT_GAMEPLAY_JUMP_STAMINA_COST, (int)numericUpDownJumpingStaminaCost.Value, 0.0f);
            insertGameConstant(Globals.GAME_CONSTANT_GAMEPLAY_FLY_STAMINA_COST, (int)numericUpDownFlyingStaminaCost.Value, 0.0f);
            insertGameConstant(Globals.GAME_CONSTANT_GAMEPLAY_CRAWL_STAMINA_COST, (int)numericUpDownCrawlingStaminaCost.Value, 0.0f);
            insertGameConstant(Globals.GAME_CONSTANT_GAMEPLAY_CLIMB_STAMINA_COST, (int)numericUpDownClimbingStaminaCost.Value, 0.0f);

            // AI Constants
            insertGameConstant(Globals.GAME_CONSTANT_AI_BUCKET_COUNT, (int)numericUpDownAIBucketCount.Value, 0.0f);
            insertGameConstant(Globals.GAME_CONSTANT_AI_BRAIN_TICK, (int)numericUpDownAIBrainTickFrequency.Value, 0.0f);

            // Character Constants
            insertGameConstant(Globals.GAME_CONSTANT_CHARACTER_MAX_LEVEL, (int)numericUpDownCharacterMaxLevels.Value, 0.0f);
            insertGameConstant(Globals.GAME_CONSTANT_CHARACTER_PLAYER_MAX_SLOTS, (int)numericUpDownCharacterMaxSlots.Value, 0.0f);
            insertGameConstant(Globals.GAME_CONSTANT_CHARACTER_INVENTORY_MAX_STACKS, (int)numericUpDownCharacterMaxInventoryStacks.Value, 0.0f);
            insertGameConstant(Globals.GAME_CONSTANT_CHARACTER_LETTER_MAX_AGE, (int)numericUpDownCharacterMaxLetterAge.Value, 0.0f);
            insertGameConstant(Globals.GAME_CONSTANT_CHARACTER_LETTER_MAX_LENGTH, (int)numericUpDownCharacterMaxLetterLength.Value, 0.0f);
            insertGameConstant(Globals.GAME_CONSTANT_CHARACTER_AUCTION_DEFAULT_DURATION, (int)numericUpDownCharacterAuctionLength.Value, 0.0f);
            insertGameConstant(Globals.GAME_CONSTANT_CHARACTER_AUCTION_MAX_LISTING, (int)numericUpDownCharacterMaxAuctionListings.Value, 0.0f);
            insertGameConstant(Globals.GAME_CONSTANT_CHARACTER_DEFAULT_START_ABILITIES, (int)numericUpDownCharacterStartAbilityCount.Value, 0.0f);
            insertGameConstant(Globals.GAME_CONSTANT_CHARACTER_DEFAULT_START_SKILLS, (int)numericUpDownCharacterStartSkillCount.Value, 0.0f);
            insertGameConstant(Globals.GAME_CONSTANT_CHARACTER_TP_GAIN_LEVEL, (int)numericUpDownCharacterTPGain.Value, 0.0f);

            EditorBrowseInfo browseInfo = (linkDefaultSpace.Tag as EditorBrowseInfo);
            insertGameConstant(Globals.GAME_CONSTANT_CHARACTER_DEFAULT_SPACE, browseInfo.Id, (float)0.0f);

            Database.beginTransaction();
            saveGameConstants();
            saveStringConstants();
            saveMonths();
            Database.commitTransaction();

            SaveGameConstants();
            Close();
        }
        private void ButtonCancelClick(object sender, EventArgs e)
        {
            Close();
        }

         
        /*private void loadMonthList()
        {
            lsvMonths.Items.Clear();

            //DataTable dt = Database.executeSPQuery("tool_refMonthsGet", null);
            DataTable dt = Database.getData("ref_month", null, null, null);
            foreach(DataRow dataRow in dt.Rows)
            {
                GameMonth month = new GameMonth(
                    (int)dataRow["ref_month_id"],
                    dataRow["name"].ToString(),
                    (int)dataRow["number_days"],
                    (int)dataRow["flags"], 
                    (int)dataRow["order"]);

                ListViewItem lvi = new ListViewItem(month.Order.ToString());
                lvi.Tag = month;

                ListViewItem.ListViewSubItem lvsi = new ListViewItem.ListViewSubItem();
                lvsi.Text = month.Name;
                lvi.SubItems.Add(lvsi);

                lvsi = new ListViewItem.ListViewSubItem();
                lvsi.Text = month.NumberDays.ToString();
                lvi.SubItems.Add(lvsi);

                lvsi = new ListViewItem.ListViewSubItem();
                lvsi.Text = month.Flags.ToString();
                lvi.SubItems.Add(lvsi);

                lsvMonths.Items.Add(lvi);
            }
            dt.Dispose();

            lsvMonths.Refresh();
        }*/

        /*private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtMonthName.Text == "") return;

            int flags = (chkIsShrouding.Checked ? Globals.MONTH_FLAG_Shrouding : 0) |
                (chkIsWinter.Checked ? Globals.MONTH_FLAG_Winter : 0) |
                (chkIsSummer.Checked ? Globals.MONTH_FLAG_Summer : 0);

            GameMonth month = new GameMonth(
                0,
                txtMonthName.Text,
                Convert.ToInt32(numNumberDays.Value),
                flags,
                getNextMonthOrder());

            ListViewItem lvi = new ListViewItem(month.Order.ToString());
            lvi.Tag = month;

            ListViewItem.ListViewSubItem lvsi = new ListViewItem.ListViewSubItem();
            lvsi.Text = month.Name;
            lvi.SubItems.Add(lvsi);

            lvsi = new ListViewItem.ListViewSubItem();
            lvsi.Text = month.NumberDays.ToString();
            lvi.SubItems.Add(lvsi);

            lvsi = new ListViewItem.ListViewSubItem();
            lvsi.Text = month.Flags.ToString();
            lvi.SubItems.Add(lvsi);

            lsvMonths.Items.Add(lvi);
            lsvMonths.Refresh();
            clearMonthFields();
        }

        private void clearMonthFields()
        {
            txtMonthName.Text = "";
            chkIsShrouding.Checked = false;
            chkIsWinter.Checked = false;
            chkIsSummer.Checked = false;
            numNumberDays.Value = 1;
        }

        private int getNextMonthOrder()
        {
            int order = 0;
            foreach (ListViewItem lvi in lsvMonths.Items)
            {
                if (lvi == null) continue;
                order = Convert.ToInt32(lvi.Text);
            }

            return ++order;
        }*/
 

       /* private void saveMonths()
        {
            //Database.executeSPNonQuery("tool_refMonthsDelete", null);
            Database.deleteData("ref_month", null, null);

            pbStatus.Minimum = 0;
            pbStatus.Value = 0;
            pbStatus.Maximum = lsvMonths.Items.Count;

            foreach (ListViewItem lvi in lsvMonths.Items)
            {
                if (lvi == null) continue;
                GameMonth month = (GameMonth)lvi.Tag;

                SqlParameter param1 = Database.createParameter("@name", month.Name, DbType.String);
                SqlParameter param2 = Database.createParameter("@flags", month.Flags, DbType.Int32);
                SqlParameter param3 = Database.createParameter("@days", month.NumberDays, DbType.Int32);
                SqlParameter param4 = Database.createParameter("@order", month.Order, DbType.Int32);
                Database.executeSPNonQuery("tool_monthSet", Database.createParameterList(param1, param2, param3, param4));
                pbStatus.Value++;
            }
        }

        private void chkIsShrouding_CheckedChanged(object sender, EventArgs e)
        {
            if (chkIsShrouding.Checked)
            {
                chkIsWinter.Enabled = true;
                chkIsSummer.Enabled = true;
            }
            else
            {
                chkIsWinter.Enabled = false;
                chkIsSummer.Enabled = false;
            }
        }

        private void chkIsWinter_CheckedChanged(object sender, EventArgs e)
        {
            if (chkIsWinter.Checked)
            {
                chkIsSummer.Checked = false;
            }
        }

        private void chkIsSummer_CheckedChanged(object sender, EventArgs e)
        {
            if (chkIsSummer.Checked)
            {
                chkIsWinter.Checked = false;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection selectedItems = lsvMonths.SelectedItems;
            if (selectedItems.Count == 0) return;

            ListViewItem lvi = selectedItems[0];
            lsvMonths.Items.Remove(lvi);
            lsvMonths.Refresh();
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection selectedItems = lsvMonths.SelectedItems;
            if (selectedItems.Count == 0) return;

            // Get the current list item
            ListViewItem lvi = selectedItems[0];
            int index = lvi.Index;
            if (index == 0) return; // if its the top row, can't move it up

            lsvMonths.Items.RemoveAt(index);    // remove it
            lsvMonths.Items.Insert(index - 1, lvi); // add it one higher
            lvi.Selected = true;

            renumberMonthOrder();
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection selectedItems = lsvMonths.SelectedItems;
            if (selectedItems.Count == 0) return;

            // Get the current list item
            ListViewItem lvi = selectedItems[0];
            int index = lvi.Index;
            if (index >= (lsvMonths.Items.Count - 1)) return; // if its the bottom row, can't move it down

            // Get the lower list item
            ListViewItem lvi2 = lsvMonths.Items[index + 1];
            int oldIndex = lvi2.Index;

            lsvMonths.Items.RemoveAt(oldIndex);  // Remove the row below the one I want to move
            lsvMonths.Items.Insert(index, lvi2); // Insert it where the row I want to move is (pushing my row down)
            lvi.Selected = true;

            renumberMonthOrder();
        }

        private void renumberMonthOrder()
        {
            int order = 1;
            foreach (ListViewItem lvi in lsvMonths.Items)
            {
                if (lvi == null) continue;
                GameMonth month = (GameMonth)lvi.Tag;
                month.Order = order;
                lvi.Text = order.ToString();
                order++;
            }
        }*/

        /*private GameMonth getSelectedMonth()
        {
            ListView.SelectedListViewItemCollection selectedItems = lsvMonths.SelectedItems;
            if (selectedItems.Count == 0) return null;
            return (GameMonth)selectedItems[0].Tag;
        }

        private void lsvMonths_SelectedIndexChanged(object sender, EventArgs e)
        {
            GameMonth month = getSelectedMonth();
            if (month == null) return;

            txtMonthName.Text = month.Name;
            numNumberDays.Value = month.NumberDays;
            chkIsShrouding.Checked = ((month.Flags & Globals.MONTH_FLAG_Shrouding) != 0) ? true : false;
            chkIsSummer.Checked = ((month.Flags & Globals.MONTH_FLAG_Summer) != 0) ? true : false;
            chkIsWinter.Checked = ((month.Flags & Globals.MONTH_FLAG_Winter) != 0) ? true : false;
        }*/

        /*private void btnUpdate_Click(object sender, EventArgs e)
        {
            GameMonth month = getSelectedMonth();
            if (month == null) return;

            month.Name = txtMonthName.Text;
            ListView.SelectedListViewItemCollection selectedItems = lsvMonths.SelectedItems;
            ListViewItem lvi = selectedItems[0];
            ListViewItem.ListViewSubItem lvsi = lvi.SubItems[1];
            lvsi.Text = txtMonthName.Text;

            month.NumberDays = Convert.ToInt32(numNumberDays.Value);
            month.Flags = 
                (chkIsShrouding.Checked ? Globals.MONTH_FLAG_Shrouding : 0) | 
                (chkIsSummer.Checked ? Globals.MONTH_FLAG_Summer : 0) | 
                (chkIsWinter.Checked ? Globals.MONTH_FLAG_Winter : 0);
        }
    }

    /*class GameMonth
    {
        private int mId;
        private string mName;
        private int mNumberDays;
        private int mFlags;
        private int mOrder;

        public GameMonth(int aId, string aName, int aDays, int aFlags, int aOrder)
        {
            mId = aId;
            mName = aName;
            mNumberDays = aDays;
            mFlags = aFlags;
            mOrder = aOrder;
        }

        public int ID { get { return mId; } }
        public string Name 
        { 
            get { return mName; }
            set { mName = value; }
        }
        public int NumberDays 
        { 
            get { return mNumberDays; }
            set { mNumberDays = value; }
        }
        public int Flags 
        { 
            get { return mFlags; }
            set { mFlags = value; }
        }
        public int Order 
        { 
            get { return mOrder; }
            set { mOrder = value; }
        }

        public override string ToString()
        {
            return mName;
        }*/
    }
}
