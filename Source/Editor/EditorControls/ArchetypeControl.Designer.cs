namespace RealmEdit
{
    partial class ArchetypeControl
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabAbilities = new System.Windows.Forms.TabPage();
            this.gridAbilities = new RealmEdit.AuraDataGridView();
            this.tabStatistics = new System.Windows.Forms.TabPage();
            this.gridStatistics = new RealmEdit.AuraDataGridView();
            this.tabControl1.SuspendLayout();
            this.tabAbilities.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridAbilities)).BeginInit();
            this.tabStatistics.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridStatistics)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.label1.Location = new System.Drawing.Point(3, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 13);
            this.label1.TabIndex = 189;
            this.label1.Text = "Display Description";
            // 
            // txtDisplayDescription
            // 
            this.txtDisplayDescription.Location = new System.Drawing.Point(106, 55);
            this.txtDisplayDescription.Multiline = true;
            this.txtDisplayDescription.Name = "txtDisplayDescription";
            this.txtDisplayDescription.Size = new System.Drawing.Size(319, 66);
            this.txtDisplayDescription.TabIndex = 186;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.label2.Location = new System.Drawing.Point(3, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 188;
            this.label2.Text = "Display Name";
            // 
            // txtDisplayName
            // 
            this.txtDisplayName.Location = new System.Drawing.Point(106, 29);
            this.txtDisplayName.Name = "txtDisplayName";
            this.txtDisplayName.Size = new System.Drawing.Size(202, 20);
            this.txtDisplayName.TabIndex = 185;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 187;
            this.label3.Text = "System Name";
            // 
            // txtSystemName
            // 
            this.txtSystemName.Location = new System.Drawing.Point(106, 3);
            this.txtSystemName.Name = "txtSystemName";
            this.txtSystemName.Size = new System.Drawing.Size(202, 20);
            this.txtSystemName.TabIndex = 184;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabAbilities);
            this.tabControl1.Controls.Add(this.tabStatistics);
            this.tabControl1.Location = new System.Drawing.Point(6, 138);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(602, 225);
            this.tabControl1.TabIndex = 198;
            // 
            // tabAbilities
            // 
            this.tabAbilities.Controls.Add(this.gridAbilities);
            this.tabAbilities.Location = new System.Drawing.Point(4, 22);
            this.tabAbilities.Name = "tabAbilities";
            this.tabAbilities.Padding = new System.Windows.Forms.Padding(3);
            this.tabAbilities.Size = new System.Drawing.Size(594, 199);
            this.tabAbilities.TabIndex = 0;
            this.tabAbilities.Text = "Abilities";
            this.tabAbilities.UseVisualStyleBackColor = true;
            // 
            // gridAbilities
            // 
            this.gridAbilities.AllowDrop = true;
            this.gridAbilities.AllowRowDeletion = true;
            this.gridAbilities.AllowUserToResizeRows = false;
            this.gridAbilities.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridAbilities.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridAbilities.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.gridAbilities.Location = new System.Drawing.Point(3, 3);
            this.gridAbilities.Name = "gridAbilities";
            this.gridAbilities.RowHeadersWidth = 20;
            this.gridAbilities.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridAbilities.Size = new System.Drawing.Size(588, 193);
            this.gridAbilities.TabIndex = 197;
            // 
            // tabStatistics
            // 
            this.tabStatistics.Controls.Add(this.gridStatistics);
            this.tabStatistics.Location = new System.Drawing.Point(4, 22);
            this.tabStatistics.Name = "tabStatistics";
            this.tabStatistics.Padding = new System.Windows.Forms.Padding(3);
            this.tabStatistics.Size = new System.Drawing.Size(594, 199);
            this.tabStatistics.TabIndex = 1;
            this.tabStatistics.Text = "Statistics";
            this.tabStatistics.UseVisualStyleBackColor = true;
            // 
            // gridStatistics
            // 
            this.gridStatistics.AllowDrop = true;
            this.gridStatistics.AllowRowDeletion = true;
            this.gridStatistics.AllowUserToResizeRows = false;
            this.gridStatistics.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridStatistics.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridStatistics.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.gridStatistics.Location = new System.Drawing.Point(3, 3);
            this.gridStatistics.Name = "gridStatistics";
            this.gridStatistics.RowHeadersWidth = 20;
            this.gridStatistics.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridStatistics.Size = new System.Drawing.Size(588, 193);
            this.gridStatistics.TabIndex = 198;
            // 
            // ArchetypeControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDisplayDescription);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtDisplayName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtSystemName);
            this.Name = "ArchetypeControl";
            this.Size = new System.Drawing.Size(616, 388);
            this.tabControl1.ResumeLayout(false);
            this.tabAbilities.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridAbilities)).EndInit();
            this.tabStatistics.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridStatistics)).EndInit();
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
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabAbilities;
        private AuraDataGridView gridAbilities;
        private System.Windows.Forms.TabPage tabStatistics;
        private AuraDataGridView gridStatistics;
    }
}
