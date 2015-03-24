namespace RealmEdit
{
    partial class StatisticControl
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
            this.txtDisplayDescription = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDisplayName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSystemName = new System.Windows.Forms.TextBox();
            this.cboStatType = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.gridAmalgamStats = new RealmEdit.AuraDataGridView();
            this.lblAmalgam = new System.Windows.Forms.Label();
            this.lstStatTags = new System.Windows.Forms.CheckedListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.chkIsSkill = new System.Windows.Forms.CheckBox();
            this.gridRequiredStats = new RealmEdit.AuraDataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.numMinLevel = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.gridAmalgamStats)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridRequiredStats)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinLevel)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.label1.Location = new System.Drawing.Point(3, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 13);
            this.label1.TabIndex = 195;
            this.label1.Text = "Display Description";
            // 
            // txtDisplayDescription
            // 
            this.txtDisplayDescription.Location = new System.Drawing.Point(106, 58);
            this.txtDisplayDescription.Multiline = true;
            this.txtDisplayDescription.Name = "txtDisplayDescription";
            this.txtDisplayDescription.Size = new System.Drawing.Size(319, 66);
            this.txtDisplayDescription.TabIndex = 192;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.label2.Location = new System.Drawing.Point(3, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 194;
            this.label2.Text = "Display Name";
            // 
            // txtDisplayName
            // 
            this.txtDisplayName.Location = new System.Drawing.Point(106, 32);
            this.txtDisplayName.Name = "txtDisplayName";
            this.txtDisplayName.Size = new System.Drawing.Size(202, 20);
            this.txtDisplayName.TabIndex = 191;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 193;
            this.label3.Text = "System Name";
            // 
            // txtSystemName
            // 
            this.txtSystemName.Location = new System.Drawing.Point(106, 6);
            this.txtSystemName.Name = "txtSystemName";
            this.txtSystemName.Size = new System.Drawing.Size(202, 20);
            this.txtSystemName.TabIndex = 190;
            // 
            // cboStatType
            // 
            this.cboStatType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStatType.FormattingEnabled = true;
            this.cboStatType.Location = new System.Drawing.Point(106, 135);
            this.cboStatType.Name = "cboStatType";
            this.cboStatType.Size = new System.Drawing.Size(156, 21);
            this.cboStatType.TabIndex = 199;
            this.cboStatType.SelectedIndexChanged += new System.EventHandler(this.cboStatType_SelectedIndexChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(44, 135);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(56, 13);
            this.label14.TabIndex = 198;
            this.label14.Text = "Stat Type:";
            // 
            // gridAmalgamStats
            // 
            this.gridAmalgamStats.AllowDrop = true;
            this.gridAmalgamStats.AllowRowDeletion = true;
            this.gridAmalgamStats.AllowUserToResizeRows = false;
            this.gridAmalgamStats.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridAmalgamStats.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.gridAmalgamStats.Location = new System.Drawing.Point(6, 310);
            this.gridAmalgamStats.Name = "gridAmalgamStats";
            this.gridAmalgamStats.RowHeadersWidth = 20;
            this.gridAmalgamStats.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridAmalgamStats.Size = new System.Drawing.Size(275, 124);
            this.gridAmalgamStats.TabIndex = 201;
            // 
            // lblAmalgam
            // 
            this.lblAmalgam.AutoSize = true;
            this.lblAmalgam.Location = new System.Drawing.Point(4, 294);
            this.lblAmalgam.Name = "lblAmalgam";
            this.lblAmalgam.Size = new System.Drawing.Size(98, 13);
            this.lblAmalgam.TabIndex = 200;
            this.lblAmalgam.Text = "Amalgam Statistics:";
            // 
            // lstStatTags
            // 
            this.lstStatTags.FormattingEnabled = true;
            this.lstStatTags.Location = new System.Drawing.Point(106, 162);
            this.lstStatTags.Name = "lstStatTags";
            this.lstStatTags.Size = new System.Drawing.Size(163, 94);
            this.lstStatTags.TabIndex = 206;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 159);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 13);
            this.label4.TabIndex = 205;
            this.label4.Text = "Statistic Tags:";
            // 
            // chkIsSkill
            // 
            this.chkIsSkill.AutoSize = true;
            this.chkIsSkill.Location = new System.Drawing.Point(287, 139);
            this.chkIsSkill.Name = "chkIsSkill";
            this.chkIsSkill.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkIsSkill.Size = new System.Drawing.Size(56, 17);
            this.chkIsSkill.TabIndex = 207;
            this.chkIsSkill.Text = "Is Skill";
            this.chkIsSkill.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkIsSkill.UseVisualStyleBackColor = true;
            // 
            // gridRequiredStats
            // 
            this.gridRequiredStats.AllowDrop = true;
            this.gridRequiredStats.AllowRowDeletion = true;
            this.gridRequiredStats.AllowUserToResizeRows = false;
            this.gridRequiredStats.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridRequiredStats.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.gridRequiredStats.Location = new System.Drawing.Point(287, 310);
            this.gridRequiredStats.Name = "gridRequiredStats";
            this.gridRequiredStats.RowHeadersWidth = 20;
            this.gridRequiredStats.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridRequiredStats.Size = new System.Drawing.Size(274, 124);
            this.gridRequiredStats.TabIndex = 209;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(284, 294);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 13);
            this.label5.TabIndex = 208;
            this.label5.Text = "Required Statistics:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(359, 138);
            this.label6.Name = "label6";
            this.label6.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label6.Size = new System.Drawing.Size(113, 13);
            this.label6.TabIndex = 232;
            this.label6.Text = "Minimum Level to Buy:";
            // 
            // numMinLevel
            // 
            this.numMinLevel.Location = new System.Drawing.Point(362, 154);
            this.numMinLevel.Maximum = new decimal(new int[] {
            1410065408,
            2,
            0,
            0});
            this.numMinLevel.Name = "numMinLevel";
            this.numMinLevel.Size = new System.Drawing.Size(98, 20);
            this.numMinLevel.TabIndex = 231;
            // 
            // StatisticControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label6);
            this.Controls.Add(this.numMinLevel);
            this.Controls.Add(this.gridRequiredStats);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.chkIsSkill);
            this.Controls.Add(this.lstStatTags);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.gridAmalgamStats);
            this.Controls.Add(this.lblAmalgam);
            this.Controls.Add(this.cboStatType);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDisplayDescription);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtDisplayName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtSystemName);
            this.Name = "StatisticControl";
            this.Size = new System.Drawing.Size(573, 448);
            ((System.ComponentModel.ISupportInitialize)(this.gridAmalgamStats)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridRequiredStats)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinLevel)).EndInit();
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
        private System.Windows.Forms.ComboBox cboStatType;
        private System.Windows.Forms.Label label14;
        private AuraDataGridView gridAmalgamStats;
        private System.Windows.Forms.Label lblAmalgam;
        private System.Windows.Forms.CheckedListBox lstStatTags;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkIsSkill;
        private AuraDataGridView gridRequiredStats;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numMinLevel;
    }
}
