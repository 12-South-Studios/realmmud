namespace RealmEdit
{
    partial class SpaceControl
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtDisplayName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSystemName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboTerrain = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.linkAccessLevel = new RealmEdit.AuraLinkLabel();
            this.label5 = new System.Windows.Forms.Label();
            this.tabItems = new System.Windows.Forms.TabPage();
            this.gridItems = new RealmEdit.AuraDataGridView();
            this.tabNpcs = new System.Windows.Forms.TabPage();
            this.gridNpcs = new RealmEdit.AuraDataGridView();
            this.tabExits = new System.Windows.Forms.TabPage();
            this.gridExits = new RealmEdit.AuraDataGridView();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabEffects = new System.Windows.Forms.TabPage();
            this.gridEffects = new RealmEdit.AuraDataGridView();
            this.chkNoMob = new System.Windows.Forms.CheckBox();
            this.chkNoRecall = new System.Windows.Forms.CheckBox();
            this.chkNoSummon = new System.Windows.Forms.CheckBox();
            this.chkNoCombat = new System.Windows.Forms.CheckBox();
            this.chkNoMagic = new System.Windows.Forms.CheckBox();
            this.chkIsShrine = new System.Windows.Forms.CheckBox();
            this.tabItems.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridItems)).BeginInit();
            this.tabNpcs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridNpcs)).BeginInit();
            this.tabExits.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridExits)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabEffects.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridEffects)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 13);
            this.label1.TabIndex = 41;
            this.label1.Text = "Display Description:";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(4, 61);
            this.txtDescription.MaxLength = 8192;
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescription.Size = new System.Drawing.Size(513, 202);
            this.txtDescription.TabIndex = 2;
            // 
            // txtDisplayName
            // 
            this.txtDisplayName.Location = new System.Drawing.Point(293, 16);
            this.txtDisplayName.MaxLength = 250;
            this.txtDisplayName.Name = "txtDisplayName";
            this.txtDisplayName.Size = new System.Drawing.Size(283, 20);
            this.txtDisplayName.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(290, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 38;
            this.label3.Text = "Display Name:";
            // 
            // txtSystemName
            // 
            this.txtSystemName.Location = new System.Drawing.Point(4, 16);
            this.txtSystemName.MaxLength = 50;
            this.txtSystemName.Name = "txtSystemName";
            this.txtSystemName.Size = new System.Drawing.Size(283, 20);
            this.txtSystemName.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 36;
            this.label2.Text = "System Name:";
            // 
            // cboTerrain
            // 
            this.cboTerrain.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTerrain.FormattingEnabled = true;
            this.cboTerrain.Location = new System.Drawing.Point(529, 61);
            this.cboTerrain.Name = "cboTerrain";
            this.cboTerrain.Size = new System.Drawing.Size(156, 21);
            this.cboTerrain.TabIndex = 3;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(526, 45);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(43, 13);
            this.label14.TabIndex = 108;
            this.label14.Text = "Terrain:";
            // 
            // linkAccessLevel
            // 
            this.linkAccessLevel.AllowDrop = true;
            this.linkAccessLevel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.linkAccessLevel.Location = new System.Drawing.Point(529, 107);
            this.linkAccessLevel.Name = "linkAccessLevel";
            this.linkAccessLevel.Padding = new System.Windows.Forms.Padding(20, 1, 0, 0);
            this.linkAccessLevel.Size = new System.Drawing.Size(156, 21);
            this.linkAccessLevel.SystemType = RealmEdit.EditorSystemType.None;
            this.linkAccessLevel.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(529, 90);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 13);
            this.label5.TabIndex = 113;
            this.label5.Text = "Access Level:";
            // 
            // tabItems
            // 
            this.tabItems.Controls.Add(this.gridItems);
            this.tabItems.Location = new System.Drawing.Point(4, 22);
            this.tabItems.Name = "tabItems";
            this.tabItems.Size = new System.Drawing.Size(678, 186);
            this.tabItems.TabIndex = 2;
            this.tabItems.Text = "Items";
            this.tabItems.UseVisualStyleBackColor = true;
            // 
            // gridItems
            // 
            this.gridItems.AllowDrop = true;
            this.gridItems.AllowRowDeletion = true;
            this.gridItems.AllowUserToResizeRows = false;
            this.gridItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridItems.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.gridItems.Location = new System.Drawing.Point(0, 0);
            this.gridItems.Name = "gridItems";
            this.gridItems.RowHeadersWidth = 20;
            this.gridItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridItems.Size = new System.Drawing.Size(678, 186);
            this.gridItems.TabIndex = 0;
            this.gridItems.DefaultValuesNeeded += new System.Windows.Forms.DataGridViewRowEventHandler(this.gridItems_DefaultValuesNeeded);
            // 
            // tabNpcs
            // 
            this.tabNpcs.Controls.Add(this.gridNpcs);
            this.tabNpcs.Location = new System.Drawing.Point(4, 22);
            this.tabNpcs.Name = "tabNpcs";
            this.tabNpcs.Padding = new System.Windows.Forms.Padding(3);
            this.tabNpcs.Size = new System.Drawing.Size(678, 186);
            this.tabNpcs.TabIndex = 1;
            this.tabNpcs.Text = "Npcs";
            this.tabNpcs.UseVisualStyleBackColor = true;
            // 
            // gridNpcs
            // 
            this.gridNpcs.AllowDrop = true;
            this.gridNpcs.AllowRowDeletion = true;
            this.gridNpcs.AllowUserToResizeRows = false;
            this.gridNpcs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridNpcs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridNpcs.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.gridNpcs.Location = new System.Drawing.Point(3, 3);
            this.gridNpcs.Name = "gridNpcs";
            this.gridNpcs.RowHeadersWidth = 20;
            this.gridNpcs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridNpcs.Size = new System.Drawing.Size(672, 180);
            this.gridNpcs.TabIndex = 115;
            // 
            // tabExits
            // 
            this.tabExits.Controls.Add(this.gridExits);
            this.tabExits.Location = new System.Drawing.Point(4, 22);
            this.tabExits.Name = "tabExits";
            this.tabExits.Padding = new System.Windows.Forms.Padding(3);
            this.tabExits.Size = new System.Drawing.Size(678, 186);
            this.tabExits.TabIndex = 0;
            this.tabExits.Text = "Exits";
            this.tabExits.UseVisualStyleBackColor = true;
            // 
            // gridExits
            // 
            this.gridExits.AllowDrop = true;
            this.gridExits.AllowRowDeletion = true;
            this.gridExits.AllowUserToResizeRows = false;
            this.gridExits.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridExits.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridExits.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.gridExits.Location = new System.Drawing.Point(3, 3);
            this.gridExits.Name = "gridExits";
            this.gridExits.RowHeadersWidth = 20;
            this.gridExits.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridExits.Size = new System.Drawing.Size(672, 180);
            this.gridExits.TabIndex = 112;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabExits);
            this.tabControl1.Controls.Add(this.tabNpcs);
            this.tabControl1.Controls.Add(this.tabItems);
            this.tabControl1.Controls.Add(this.tabEffects);
            this.tabControl1.Location = new System.Drawing.Point(6, 269);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(686, 212);
            this.tabControl1.TabIndex = 116;
            // 
            // tabEffects
            // 
            this.tabEffects.Controls.Add(this.gridEffects);
            this.tabEffects.Location = new System.Drawing.Point(4, 22);
            this.tabEffects.Name = "tabEffects";
            this.tabEffects.Padding = new System.Windows.Forms.Padding(3);
            this.tabEffects.Size = new System.Drawing.Size(678, 186);
            this.tabEffects.TabIndex = 3;
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
            this.gridEffects.Size = new System.Drawing.Size(672, 180);
            this.gridEffects.TabIndex = 113;
            // 
            // chkNoMob
            // 
            this.chkNoMob.AutoSize = true;
            this.chkNoMob.Location = new System.Drawing.Point(529, 131);
            this.chkNoMob.Name = "chkNoMob";
            this.chkNoMob.Size = new System.Drawing.Size(64, 17);
            this.chkNoMob.TabIndex = 249;
            this.chkNoMob.Text = "No Mob";
            this.chkNoMob.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkNoMob.UseVisualStyleBackColor = true;
            // 
            // chkNoRecall
            // 
            this.chkNoRecall.AutoSize = true;
            this.chkNoRecall.Location = new System.Drawing.Point(529, 154);
            this.chkNoRecall.Name = "chkNoRecall";
            this.chkNoRecall.Size = new System.Drawing.Size(73, 17);
            this.chkNoRecall.TabIndex = 250;
            this.chkNoRecall.Text = "No Recall";
            this.chkNoRecall.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkNoRecall.UseVisualStyleBackColor = true;
            // 
            // chkNoSummon
            // 
            this.chkNoSummon.AutoSize = true;
            this.chkNoSummon.Location = new System.Drawing.Point(529, 177);
            this.chkNoSummon.Name = "chkNoSummon";
            this.chkNoSummon.Size = new System.Drawing.Size(84, 17);
            this.chkNoSummon.TabIndex = 251;
            this.chkNoSummon.Text = "No Summon";
            this.chkNoSummon.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkNoSummon.UseVisualStyleBackColor = true;
            // 
            // chkNoCombat
            // 
            this.chkNoCombat.AutoSize = true;
            this.chkNoCombat.Location = new System.Drawing.Point(529, 200);
            this.chkNoCombat.Name = "chkNoCombat";
            this.chkNoCombat.Size = new System.Drawing.Size(79, 17);
            this.chkNoCombat.TabIndex = 252;
            this.chkNoCombat.Text = "No Combat";
            this.chkNoCombat.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkNoCombat.UseVisualStyleBackColor = true;
            // 
            // chkNoMagic
            // 
            this.chkNoMagic.AutoSize = true;
            this.chkNoMagic.Location = new System.Drawing.Point(529, 223);
            this.chkNoMagic.Name = "chkNoMagic";
            this.chkNoMagic.Size = new System.Drawing.Size(72, 17);
            this.chkNoMagic.TabIndex = 253;
            this.chkNoMagic.Text = "No Magic";
            this.chkNoMagic.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkNoMagic.UseVisualStyleBackColor = true;
            // 
            // chkIsShrine
            // 
            this.chkIsShrine.AutoSize = true;
            this.chkIsShrine.Location = new System.Drawing.Point(529, 246);
            this.chkIsShrine.Name = "chkIsShrine";
            this.chkIsShrine.Size = new System.Drawing.Size(67, 17);
            this.chkIsShrine.TabIndex = 254;
            this.chkIsShrine.Text = "Is Shrine";
            this.chkIsShrine.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkIsShrine.UseVisualStyleBackColor = true;
            // 
            // SpaceControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.chkIsShrine);
            this.Controls.Add(this.chkNoMagic);
            this.Controls.Add(this.chkNoCombat);
            this.Controls.Add(this.chkNoSummon);
            this.Controls.Add(this.chkNoRecall);
            this.Controls.Add(this.chkNoMob);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.linkAccessLevel);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cboTerrain);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.txtDisplayName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtSystemName);
            this.Controls.Add(this.label2);
            this.Name = "SpaceControl";
            this.Size = new System.Drawing.Size(701, 491);
            this.tabItems.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridItems)).EndInit();
            this.tabNpcs.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridNpcs)).EndInit();
            this.tabExits.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridExits)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabEffects.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridEffects)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.TextBox txtDisplayName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSystemName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboTerrain;
        private System.Windows.Forms.Label label14;
        private AuraLinkLabel linkAccessLevel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TabPage tabItems;
        private AuraDataGridView gridItems;
        private System.Windows.Forms.TabPage tabNpcs;
        private AuraDataGridView gridNpcs;
        private System.Windows.Forms.TabPage tabExits;
        private AuraDataGridView gridExits;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabEffects;
        private AuraDataGridView gridEffects;
        private System.Windows.Forms.CheckBox chkNoMob;
        private System.Windows.Forms.CheckBox chkNoRecall;
        private System.Windows.Forms.CheckBox chkNoSummon;
        private System.Windows.Forms.CheckBox chkNoCombat;
        private System.Windows.Forms.CheckBox chkNoMagic;
        private System.Windows.Forms.CheckBox chkIsShrine;
    }
}
