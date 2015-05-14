using Realm.Edit.CustomControls;

namespace Realm.Edit.EditorControls
{
    partial class AbilityControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AbilityControl));
            this.label1 = new System.Windows.Forms.Label();
            this.txtDisplayDescription = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDisplayName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSystemName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.numStaminaCost = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.numManaCost = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.numRechargeRate = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.numericUpDownPostDelay = new System.Windows.Forms.NumericUpDown();
            this.label13 = new System.Windows.Forms.Label();
            this.numericUpDownPreDelay = new System.Windows.Forms.NumericUpDown();
            this.label16 = new System.Windows.Forms.Label();
            this.linkTerrain = new Realm.Edit.CustomControls.AuraLinkLabel();
            this.lblTerrain = new System.Windows.Forms.Label();
            this.lstAbilityTags = new System.Windows.Forms.CheckedListBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabEffects = new System.Windows.Forms.TabPage();
            this.gridEffects = new Realm.Edit.CustomControls.AuraDataGridView();
            this.tabPrereqs = new System.Windows.Forms.TabPage();
            this.gridPrerequisites = new Realm.Edit.CustomControls.AuraDataGridView();
            this.tabReagants = new System.Windows.Forms.TabPage();
            this.gridReagants = new Realm.Edit.CustomControls.AuraDataGridView();
            this.linkInterruptResist = new Realm.Edit.CustomControls.AuraLinkLabel();
            this.lblInterruptResist = new System.Windows.Forms.Label();
            this.linkInterruptEffect = new Realm.Edit.CustomControls.AuraLinkLabel();
            this.chkNotInterruptible = new System.Windows.Forms.CheckBox();
            this.llblInterruptEffect = new System.Windows.Forms.Label();
            this.cboOffensiveStat = new System.Windows.Forms.ComboBox();
            this.cboDefensiveStat = new System.Windows.Forms.ComboBox();
            this.chkTerrainRequired = new System.Windows.Forms.CheckBox();
            this.chkWeaponRequired = new System.Windows.Forms.CheckBox();
            this.chkAutoAttack = new System.Windows.Forms.CheckBox();
            this.chkImplementRequired = new System.Windows.Forms.CheckBox();
            this.chkVerbalRequired = new System.Windows.Forms.CheckBox();
            this.chkSightRequired = new System.Windows.Forms.CheckBox();
            this.chkPassive = new System.Windows.Forms.CheckBox();
            this.chkNoCombatUse = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.numStaminaCost)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numManaCost)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRechargeRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPostDelay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPreDelay)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabEffects.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridEffects)).BeginInit();
            this.tabPrereqs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridPrerequisites)).BeginInit();
            this.tabReagants.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridReagants)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.label1.Location = new System.Drawing.Point(3, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 13);
            this.label1.TabIndex = 189;
            this.label1.Text = "Display Description";
            // 
            // txtDisplayDescription
            // 
            this.txtDisplayDescription.Location = new System.Drawing.Point(106, 60);
            this.txtDisplayDescription.Multiline = true;
            this.txtDisplayDescription.Name = "txtDisplayDescription";
            this.txtDisplayDescription.Size = new System.Drawing.Size(247, 101);
            this.txtDisplayDescription.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.label2.Location = new System.Drawing.Point(3, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 188;
            this.label2.Text = "Display Name";
            // 
            // txtDisplayName
            // 
            this.txtDisplayName.Location = new System.Drawing.Point(106, 34);
            this.txtDisplayName.Name = "txtDisplayName";
            this.txtDisplayName.Size = new System.Drawing.Size(202, 20);
            this.txtDisplayName.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 187;
            this.label3.Text = "System Name";
            // 
            // txtSystemName
            // 
            this.txtSystemName.Location = new System.Drawing.Point(106, 8);
            this.txtSystemName.Name = "txtSystemName";
            this.txtSystemName.Size = new System.Drawing.Size(202, 20);
            this.txtSystemName.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(382, 144);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 13);
            this.label6.TabIndex = 203;
            this.label6.Text = "Offensive Stat:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(379, 168);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(80, 13);
            this.label9.TabIndex = 209;
            this.label9.Text = "Defensive Stat:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(387, 96);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label4.Size = new System.Drawing.Size(72, 13);
            this.label4.TabIndex = 226;
            this.label4.Text = "Stamina Cost:";
            // 
            // numStaminaCost
            // 
            this.numStaminaCost.Location = new System.Drawing.Point(469, 94);
            this.numStaminaCost.Maximum = new decimal(new int[] {
            1410065408,
            2,
            0,
            0});
            this.numStaminaCost.Name = "numStaminaCost";
            this.numStaminaCost.Size = new System.Drawing.Size(98, 20);
            this.numStaminaCost.TabIndex = 225;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(398, 122);
            this.label11.Name = "label11";
            this.label11.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label11.Size = new System.Drawing.Size(61, 13);
            this.label11.TabIndex = 228;
            this.label11.Text = "Mana Cost:";
            // 
            // numManaCost
            // 
            this.numManaCost.Location = new System.Drawing.Point(469, 120);
            this.numManaCost.Maximum = new decimal(new int[] {
            1410065408,
            2,
            0,
            0});
            this.numManaCost.Name = "numManaCost";
            this.numManaCost.Size = new System.Drawing.Size(98, 20);
            this.numManaCost.TabIndex = 227;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(361, 18);
            this.label12.Name = "label12";
            this.label12.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label12.Size = new System.Drawing.Size(97, 13);
            this.label12.TabIndex = 230;
            this.label12.Text = "Recharge Rate (s):";
            // 
            // numRechargeRate
            // 
            this.numRechargeRate.Location = new System.Drawing.Point(469, 16);
            this.numRechargeRate.Maximum = new decimal(new int[] {
            1410065408,
            2,
            0,
            0});
            this.numRechargeRate.Name = "numRechargeRate";
            this.numRechargeRate.Size = new System.Drawing.Size(98, 20);
            this.numRechargeRate.TabIndex = 229;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(398, 70);
            this.label8.Name = "label8";
            this.label8.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label8.Size = new System.Drawing.Size(61, 13);
            this.label8.TabIndex = 234;
            this.label8.Text = "Post-Delay:";
            // 
            // numericUpDownPostDelay
            // 
            this.numericUpDownPostDelay.DecimalPlaces = 2;
            this.numericUpDownPostDelay.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDownPostDelay.Location = new System.Drawing.Point(470, 68);
            this.numericUpDownPostDelay.Maximum = new decimal(new int[] {
            1410065408,
            2,
            0,
            0});
            this.numericUpDownPostDelay.Name = "numericUpDownPostDelay";
            this.numericUpDownPostDelay.Size = new System.Drawing.Size(98, 20);
            this.numericUpDownPostDelay.TabIndex = 233;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(403, 44);
            this.label13.Name = "label13";
            this.label13.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label13.Size = new System.Drawing.Size(56, 13);
            this.label13.TabIndex = 236;
            this.label13.Text = "Pre-Delay:";
            // 
            // numericUpDownPreDelay
            // 
            this.numericUpDownPreDelay.DecimalPlaces = 2;
            this.numericUpDownPreDelay.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDownPreDelay.Location = new System.Drawing.Point(469, 42);
            this.numericUpDownPreDelay.Maximum = new decimal(new int[] {
            1410065408,
            2,
            0,
            0});
            this.numericUpDownPreDelay.Name = "numericUpDownPreDelay";
            this.numericUpDownPreDelay.Size = new System.Drawing.Size(98, 20);
            this.numericUpDownPreDelay.TabIndex = 235;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(604, 15);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(64, 13);
            this.label16.TabIndex = 240;
            this.label16.Text = "Ability Tags:";
            // 
            // linkTerrain
            // 
            this.linkTerrain.AllowDrop = true;
            this.linkTerrain.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.linkTerrain.Enabled = false;
            this.linkTerrain.Location = new System.Drawing.Point(469, 212);
            this.linkTerrain.Name = "linkTerrain";
            this.linkTerrain.Padding = new System.Windows.Forms.Padding(20, 1, 0, 0);
            this.linkTerrain.Size = new System.Drawing.Size(124, 21);
            this.linkTerrain.SystemType = Realm.DAL.Enumerations.SystemTypes.Terrain;
            this.linkTerrain.TabIndex = 241;
            // 
            // lblTerrain
            // 
            this.lblTerrain.AutoSize = true;
            this.lblTerrain.Location = new System.Drawing.Point(467, 197);
            this.lblTerrain.Name = "lblTerrain";
            this.lblTerrain.Size = new System.Drawing.Size(118, 13);
            this.lblTerrain.TabIndex = 242;
            this.lblTerrain.Text = "Terrain (for Geomancy):";
            // 
            // lstAbilityTags
            // 
            this.lstAbilityTags.FormattingEnabled = true;
            this.lstAbilityTags.Location = new System.Drawing.Point(604, 32);
            this.lstAbilityTags.Name = "lstAbilityTags";
            this.lstAbilityTags.Size = new System.Drawing.Size(120, 109);
            this.lstAbilityTags.TabIndex = 243;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabEffects);
            this.tabControl1.Controls.Add(this.tabPrereqs);
            this.tabControl1.Controls.Add(this.tabReagants);
            this.tabControl1.Location = new System.Drawing.Point(3, 289);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(721, 228);
            this.tabControl1.TabIndex = 244;
            // 
            // tabEffects
            // 
            this.tabEffects.Controls.Add(this.gridEffects);
            this.tabEffects.Location = new System.Drawing.Point(4, 22);
            this.tabEffects.Name = "tabEffects";
            this.tabEffects.Padding = new System.Windows.Forms.Padding(3);
            this.tabEffects.Size = new System.Drawing.Size(713, 202);
            this.tabEffects.TabIndex = 0;
            this.tabEffects.Text = "Effects";
            this.tabEffects.UseVisualStyleBackColor = true;
            // 
            // gridEffects
            // 
            this.gridEffects.AllowDrop = true;
            this.gridEffects.AllowRowDeletion = true;
            this.gridEffects.AllowUserToResizeRows = false;
            this.gridEffects.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridEffects.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridEffects.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.gridEffects.Location = new System.Drawing.Point(3, 3);
            this.gridEffects.Name = "gridEffects";
            this.gridEffects.RowHeadersWidth = 20;
            this.gridEffects.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridEffects.Size = new System.Drawing.Size(707, 196);
            this.gridEffects.TabIndex = 206;
            //this.gridEffects.ValidateRow = ((Realm.Edit.CustomControls.ValidateRowDelegate)(resources.GetObject("gridEffects.ValidateRow")));
            // 
            // tabPrereqs
            // 
            this.tabPrereqs.Controls.Add(this.gridPrerequisites);
            this.tabPrereqs.Location = new System.Drawing.Point(4, 22);
            this.tabPrereqs.Name = "tabPrereqs";
            this.tabPrereqs.Padding = new System.Windows.Forms.Padding(3);
            this.tabPrereqs.Size = new System.Drawing.Size(713, 202);
            this.tabPrereqs.TabIndex = 1;
            this.tabPrereqs.Text = "Prerequisites";
            this.tabPrereqs.UseVisualStyleBackColor = true;
            // 
            // gridPrerequisites
            // 
            this.gridPrerequisites.AllowDrop = true;
            this.gridPrerequisites.AllowRowDeletion = true;
            this.gridPrerequisites.AllowUserToResizeRows = false;
            this.gridPrerequisites.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridPrerequisites.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridPrerequisites.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.gridPrerequisites.Location = new System.Drawing.Point(3, 3);
            this.gridPrerequisites.Name = "gridPrerequisites";
            this.gridPrerequisites.RowHeadersWidth = 20;
            this.gridPrerequisites.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridPrerequisites.Size = new System.Drawing.Size(707, 196);
            this.gridPrerequisites.TabIndex = 208;
            //this.gridPrerequisites.ValidateRow = ((Realm.Edit.CustomControls.ValidateRowDelegate)(resources.GetObject("gridPrerequisites.ValidateRow")));
            // 
            // tabReagants
            // 
            this.tabReagants.Controls.Add(this.gridReagants);
            this.tabReagants.Location = new System.Drawing.Point(4, 22);
            this.tabReagants.Name = "tabReagants";
            this.tabReagants.Size = new System.Drawing.Size(713, 202);
            this.tabReagants.TabIndex = 2;
            this.tabReagants.Text = "Reagants";
            this.tabReagants.UseVisualStyleBackColor = true;
            // 
            // gridReagants
            // 
            this.gridReagants.AllowDrop = true;
            this.gridReagants.AllowRowDeletion = true;
            this.gridReagants.AllowUserToResizeRows = false;
            this.gridReagants.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridReagants.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridReagants.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.gridReagants.Location = new System.Drawing.Point(0, 0);
            this.gridReagants.Name = "gridReagants";
            this.gridReagants.RowHeadersWidth = 20;
            this.gridReagants.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridReagants.Size = new System.Drawing.Size(713, 202);
            this.gridReagants.TabIndex = 208;
            //this.gridReagants.ValidateRow = ((Realm.Edit.CustomControls.ValidateRowDelegate)(resources.GetObject("gridReagants.ValidateRow")));
            // 
            // linkInterruptResist
            // 
            this.linkInterruptResist.AllowDrop = true;
            this.linkInterruptResist.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.linkInterruptResist.Enabled = false;
            this.linkInterruptResist.Location = new System.Drawing.Point(469, 265);
            this.linkInterruptResist.Name = "linkInterruptResist";
            this.linkInterruptResist.Padding = new System.Windows.Forms.Padding(20, 1, 0, 0);
            this.linkInterruptResist.Size = new System.Drawing.Size(124, 21);
            this.linkInterruptResist.SystemType = Realm.DAL.Enumerations.SystemTypes.None;
            this.linkInterruptResist.TabIndex = 245;
            // 
            // lblInterruptResist
            // 
            this.lblInterruptResist.AutoSize = true;
            this.lblInterruptResist.Location = new System.Drawing.Point(467, 246);
            this.lblInterruptResist.Name = "lblInterruptResist";
            this.lblInterruptResist.Size = new System.Drawing.Size(109, 13);
            this.lblInterruptResist.TabIndex = 246;
            this.lblInterruptResist.Text = "Interrupt (Resist) Skill:";
            // 
            // linkInterruptEffect
            // 
            this.linkInterruptEffect.AllowDrop = true;
            this.linkInterruptEffect.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.linkInterruptEffect.Enabled = false;
            this.linkInterruptEffect.Location = new System.Drawing.Point(600, 265);
            this.linkInterruptEffect.Name = "linkInterruptEffect";
            this.linkInterruptEffect.Padding = new System.Windows.Forms.Padding(20, 1, 0, 0);
            this.linkInterruptEffect.Size = new System.Drawing.Size(124, 21);
            this.linkInterruptEffect.SystemType = Realm.DAL.Enumerations.SystemTypes.Effect;
            this.linkInterruptEffect.TabIndex = 247;
            // 
            // chkNotInterruptible
            // 
            this.chkNotInterruptible.AutoSize = true;
            this.chkNotInterruptible.Location = new System.Drawing.Point(356, 246);
            this.chkNotInterruptible.Name = "chkNotInterruptible";
            this.chkNotInterruptible.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkNotInterruptible.Size = new System.Drawing.Size(105, 17);
            this.chkNotInterruptible.TabIndex = 249;
            this.chkNotInterruptible.Text = "Not Interruptable";
            this.chkNotInterruptible.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkNotInterruptible.UseVisualStyleBackColor = true;
            this.chkNotInterruptible.CheckedChanged += new System.EventHandler(this.ChkNotInterruptibleCheckedChanged);
            // 
            // llblInterruptEffect
            // 
            this.llblInterruptEffect.AutoSize = true;
            this.llblInterruptEffect.Location = new System.Drawing.Point(601, 246);
            this.llblInterruptEffect.Name = "llblInterruptEffect";
            this.llblInterruptEffect.Size = new System.Drawing.Size(94, 13);
            this.llblInterruptEffect.TabIndex = 250;
            this.llblInterruptEffect.Text = "Interruption Effect:";
            // 
            // cboOffensiveStat
            // 
            this.cboOffensiveStat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboOffensiveStat.FormattingEnabled = true;
            this.cboOffensiveStat.Location = new System.Drawing.Point(469, 146);
            this.cboOffensiveStat.Name = "cboOffensiveStat";
            this.cboOffensiveStat.Size = new System.Drawing.Size(124, 21);
            this.cboOffensiveStat.TabIndex = 251;
            // 
            // cboDefensiveStat
            // 
            this.cboDefensiveStat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDefensiveStat.FormattingEnabled = true;
            this.cboDefensiveStat.Location = new System.Drawing.Point(469, 173);
            this.cboDefensiveStat.Name = "cboDefensiveStat";
            this.cboDefensiveStat.Size = new System.Drawing.Size(124, 21);
            this.cboDefensiveStat.TabIndex = 252;
            // 
            // chkTerrainRequired
            // 
            this.chkTerrainRequired.AutoSize = true;
            this.chkTerrainRequired.Location = new System.Drawing.Point(353, 197);
            this.chkTerrainRequired.Name = "chkTerrainRequired";
            this.chkTerrainRequired.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkTerrainRequired.Size = new System.Drawing.Size(105, 17);
            this.chkTerrainRequired.TabIndex = 253;
            this.chkTerrainRequired.Text = "Terrain Required";
            this.chkTerrainRequired.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkTerrainRequired.UseVisualStyleBackColor = true;
            this.chkTerrainRequired.CheckedChanged += new System.EventHandler(this.ChkTerrainRequiredCheckedChanged);
            // 
            // chkWeaponRequired
            // 
            this.chkWeaponRequired.AutoSize = true;
            this.chkWeaponRequired.Location = new System.Drawing.Point(137, 173);
            this.chkWeaponRequired.Name = "chkWeaponRequired";
            this.chkWeaponRequired.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkWeaponRequired.Size = new System.Drawing.Size(113, 17);
            this.chkWeaponRequired.TabIndex = 254;
            this.chkWeaponRequired.Text = "Weapon Required";
            this.chkWeaponRequired.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkWeaponRequired.UseVisualStyleBackColor = true;
            // 
            // chkAutoAttack
            // 
            this.chkAutoAttack.AutoSize = true;
            this.chkAutoAttack.Location = new System.Drawing.Point(25, 175);
            this.chkAutoAttack.Name = "chkAutoAttack";
            this.chkAutoAttack.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkAutoAttack.Size = new System.Drawing.Size(82, 17);
            this.chkAutoAttack.TabIndex = 255;
            this.chkAutoAttack.Text = "Auto-Attack";
            this.chkAutoAttack.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkAutoAttack.UseVisualStyleBackColor = true;
            // 
            // chkImplementRequired
            // 
            this.chkImplementRequired.AutoSize = true;
            this.chkImplementRequired.Location = new System.Drawing.Point(130, 200);
            this.chkImplementRequired.Name = "chkImplementRequired";
            this.chkImplementRequired.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkImplementRequired.Size = new System.Drawing.Size(120, 17);
            this.chkImplementRequired.TabIndex = 256;
            this.chkImplementRequired.Text = "Implement Required";
            this.chkImplementRequired.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkImplementRequired.UseVisualStyleBackColor = true;
            // 
            // chkVerbalRequired
            // 
            this.chkVerbalRequired.AutoSize = true;
            this.chkVerbalRequired.Location = new System.Drawing.Point(148, 223);
            this.chkVerbalRequired.Name = "chkVerbalRequired";
            this.chkVerbalRequired.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkVerbalRequired.Size = new System.Drawing.Size(102, 17);
            this.chkVerbalRequired.TabIndex = 257;
            this.chkVerbalRequired.Text = "Verbal Required";
            this.chkVerbalRequired.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkVerbalRequired.UseVisualStyleBackColor = true;
            // 
            // chkSightRequired
            // 
            this.chkSightRequired.AutoSize = true;
            this.chkSightRequired.Location = new System.Drawing.Point(154, 246);
            this.chkSightRequired.Name = "chkSightRequired";
            this.chkSightRequired.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkSightRequired.Size = new System.Drawing.Size(96, 17);
            this.chkSightRequired.TabIndex = 258;
            this.chkSightRequired.Text = "Sight Required";
            this.chkSightRequired.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkSightRequired.UseVisualStyleBackColor = true;
            // 
            // chkPassive
            // 
            this.chkPassive.AutoSize = true;
            this.chkPassive.Location = new System.Drawing.Point(44, 200);
            this.chkPassive.Name = "chkPassive";
            this.chkPassive.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkPassive.Size = new System.Drawing.Size(63, 17);
            this.chkPassive.TabIndex = 259;
            this.chkPassive.Text = "Passive";
            this.chkPassive.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkPassive.UseVisualStyleBackColor = true;
            // 
            // chkNoCombatUse
            // 
            this.chkNoCombatUse.AutoSize = true;
            this.chkNoCombatUse.Location = new System.Drawing.Point(6, 223);
            this.chkNoCombatUse.Name = "chkNoCombatUse";
            this.chkNoCombatUse.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkNoCombatUse.Size = new System.Drawing.Size(101, 17);
            this.chkNoCombatUse.TabIndex = 260;
            this.chkNoCombatUse.Text = "No Combat Use";
            this.chkNoCombatUse.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkNoCombatUse.UseVisualStyleBackColor = true;
            // 
            // AbilityControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.chkNoCombatUse);
            this.Controls.Add(this.chkPassive);
            this.Controls.Add(this.chkSightRequired);
            this.Controls.Add(this.chkVerbalRequired);
            this.Controls.Add(this.chkImplementRequired);
            this.Controls.Add(this.chkAutoAttack);
            this.Controls.Add(this.chkWeaponRequired);
            this.Controls.Add(this.chkTerrainRequired);
            this.Controls.Add(this.cboDefensiveStat);
            this.Controls.Add(this.cboOffensiveStat);
            this.Controls.Add(this.llblInterruptEffect);
            this.Controls.Add(this.chkNotInterruptible);
            this.Controls.Add(this.linkInterruptEffect);
            this.Controls.Add(this.linkInterruptResist);
            this.Controls.Add(this.lblInterruptResist);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.lstAbilityTags);
            this.Controls.Add(this.linkTerrain);
            this.Controls.Add(this.lblTerrain);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.numericUpDownPreDelay);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.numericUpDownPostDelay);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.numRechargeRate);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.numManaCost);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.numStaminaCost);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDisplayDescription);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtDisplayName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtSystemName);
            this.Name = "AbilityControl";
            this.Size = new System.Drawing.Size(730, 524);
            ((System.ComponentModel.ISupportInitialize)(this.numStaminaCost)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numManaCost)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRechargeRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPostDelay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPreDelay)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabEffects.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridEffects)).EndInit();
            this.tabPrereqs.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridPrerequisites)).EndInit();
            this.tabReagants.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridReagants)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDisplayDescription;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDisplayName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSystemName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numStaminaCost;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown numManaCost;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.NumericUpDown numRechargeRate;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown numericUpDownPostDelay;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.NumericUpDown numericUpDownPreDelay;
        private System.Windows.Forms.Label label16;
        private AuraLinkLabel linkTerrain;
        private System.Windows.Forms.Label lblTerrain;
        private System.Windows.Forms.CheckedListBox lstAbilityTags;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabEffects;
        private System.Windows.Forms.TabPage tabPrereqs;
        private AuraDataGridView gridPrerequisites;
        private System.Windows.Forms.TabPage tabReagants;
        private AuraDataGridView gridReagants;
        private AuraDataGridView gridEffects;
        private AuraLinkLabel linkInterruptResist;
        private System.Windows.Forms.Label lblInterruptResist;
        private AuraLinkLabel linkInterruptEffect;
        private System.Windows.Forms.CheckBox chkNotInterruptible;
        private System.Windows.Forms.Label llblInterruptEffect;
        private System.Windows.Forms.ComboBox cboOffensiveStat;
        private System.Windows.Forms.ComboBox cboDefensiveStat;
        private System.Windows.Forms.CheckBox chkTerrainRequired;
        private System.Windows.Forms.CheckBox chkWeaponRequired;
        private System.Windows.Forms.CheckBox chkAutoAttack;
        private System.Windows.Forms.CheckBox chkImplementRequired;
        private System.Windows.Forms.CheckBox chkVerbalRequired;
        private System.Windows.Forms.CheckBox chkSightRequired;
        private System.Windows.Forms.CheckBox chkPassive;
        private System.Windows.Forms.CheckBox chkNoCombatUse;
    }
}
