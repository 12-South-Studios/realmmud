namespace RealmEdit
{
    partial class ItemArmorControl
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gridDefensiveStats = new RealmEdit.AuraDataGridView();
            this.cboArmorType = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.cboArmorClass = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridDefensiveStats)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.cboArmorClass);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.gridDefensiveStats);
            this.groupBox1.Controls.Add(this.cboArmorType);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(652, 233);
            this.groupBox1.TabIndex = 208;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Armor:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 212;
            this.label1.Text = "Defensive Stats:";
            // 
            // gridDefensiveStats
            // 
            this.gridDefensiveStats.AllowDrop = true;
            this.gridDefensiveStats.AllowRowDeletion = true;
            this.gridDefensiveStats.AllowUserToResizeRows = false;
            this.gridDefensiveStats.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridDefensiveStats.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.gridDefensiveStats.Location = new System.Drawing.Point(99, 76);
            this.gridDefensiveStats.Name = "gridDefensiveStats";
            this.gridDefensiveStats.RowHeadersWidth = 20;
            this.gridDefensiveStats.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridDefensiveStats.Size = new System.Drawing.Size(240, 128);
            this.gridDefensiveStats.TabIndex = 211;
            // 
            // cboArmorType
            // 
            this.cboArmorType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboArmorType.FormattingEnabled = true;
            this.cboArmorType.Location = new System.Drawing.Point(99, 19);
            this.cboArmorType.Name = "cboArmorType";
            this.cboArmorType.Size = new System.Drawing.Size(124, 21);
            this.cboArmorType.TabIndex = 210;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(30, 22);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(64, 13);
            this.label14.TabIndex = 209;
            this.label14.Text = "Armor Type:";
            // 
            // cboArmorClass
            // 
            this.cboArmorClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboArmorClass.FormattingEnabled = true;
            this.cboArmorClass.Location = new System.Drawing.Point(99, 46);
            this.cboArmorClass.Name = "cboArmorClass";
            this.cboArmorClass.Size = new System.Drawing.Size(124, 21);
            this.cboArmorClass.TabIndex = 214;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 213;
            this.label2.Text = "Armor Class:";
            // 
            // ItemArmorControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "ItemArmorControl";
            this.Size = new System.Drawing.Size(662, 244);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridDefensiveStats)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cboArmorType;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label1;
        private AuraDataGridView gridDefensiveStats;
        private System.Windows.Forms.ComboBox cboArmorClass;
        private System.Windows.Forms.Label label2;
    }
}
