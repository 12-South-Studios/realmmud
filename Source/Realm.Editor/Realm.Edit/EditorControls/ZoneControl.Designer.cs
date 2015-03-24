namespace RealmEdit
{
    partial class ZoneControl
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
            this.txtAuthor = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabSpaces = new System.Windows.Forms.TabPage();
            this.gridSpaces = new RealmEdit.AuraDataGridView();
            this.tabAccess = new System.Windows.Forms.TabPage();
            this.gridAccessLevels = new RealmEdit.AuraDataGridView();
            this.tabSpawns = new System.Windows.Forms.TabPage();
            this.gridSpawns = new RealmEdit.AuraDataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.numReset = new System.Windows.Forms.NumericUpDown();
            this.chkSystemZone = new System.Windows.Forms.CheckBox();
            this.tabControl1.SuspendLayout();
            this.tabSpaces.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridSpaces)).BeginInit();
            this.tabAccess.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridAccessLevels)).BeginInit();
            this.tabSpawns.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridSpawns)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numReset)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 13);
            this.label1.TabIndex = 33;
            this.label1.Text = "Display Description:";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(3, 96);
            this.txtDescription.MaxLength = 250;
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(610, 48);
            this.txtDescription.TabIndex = 32;
            // 
            // txtDisplayName
            // 
            this.txtDisplayName.Location = new System.Drawing.Point(3, 57);
            this.txtDisplayName.Name = "txtDisplayName";
            this.txtDisplayName.Size = new System.Drawing.Size(302, 20);
            this.txtDisplayName.TabIndex = 31;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(-164, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 30;
            this.label3.Text = "Display Name:";
            // 
            // txtSystemName
            // 
            this.txtSystemName.Location = new System.Drawing.Point(4, 16);
            this.txtSystemName.Name = "txtSystemName";
            this.txtSystemName.Size = new System.Drawing.Size(302, 20);
            this.txtSystemName.TabIndex = 29;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 28;
            this.label2.Text = "System Name:";
            // 
            // txtAuthor
            // 
            this.txtAuthor.Location = new System.Drawing.Point(4, 163);
            this.txtAuthor.Name = "txtAuthor";
            this.txtAuthor.Size = new System.Drawing.Size(302, 20);
            this.txtAuthor.TabIndex = 35;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 147);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 13);
            this.label5.TabIndex = 34;
            this.label5.Text = "Author:";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabSpaces);
            this.tabControl1.Controls.Add(this.tabAccess);
            this.tabControl1.Controls.Add(this.tabSpawns);
            this.tabControl1.Location = new System.Drawing.Point(6, 189);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(607, 215);
            this.tabControl1.TabIndex = 116;
            // 
            // tabSpaces
            // 
            this.tabSpaces.Controls.Add(this.gridSpaces);
            this.tabSpaces.Location = new System.Drawing.Point(4, 22);
            this.tabSpaces.Name = "tabSpaces";
            this.tabSpaces.Padding = new System.Windows.Forms.Padding(3);
            this.tabSpaces.Size = new System.Drawing.Size(599, 189);
            this.tabSpaces.TabIndex = 0;
            this.tabSpaces.Text = "Spaces";
            this.tabSpaces.UseVisualStyleBackColor = true;
            // 
            // gridSpaces
            // 
            this.gridSpaces.AllowDrop = true;
            this.gridSpaces.AllowRowDeletion = true;
            this.gridSpaces.AllowUserToResizeRows = false;
            this.gridSpaces.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridSpaces.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridSpaces.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.gridSpaces.Location = new System.Drawing.Point(3, 3);
            this.gridSpaces.Name = "gridSpaces";
            this.gridSpaces.RowHeadersWidth = 20;
            this.gridSpaces.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridSpaces.Size = new System.Drawing.Size(593, 183);
            this.gridSpaces.TabIndex = 114;
            // 
            // tabAccess
            // 
            this.tabAccess.Controls.Add(this.gridAccessLevels);
            this.tabAccess.Location = new System.Drawing.Point(4, 22);
            this.tabAccess.Name = "tabAccess";
            this.tabAccess.Padding = new System.Windows.Forms.Padding(3);
            this.tabAccess.Size = new System.Drawing.Size(599, 189);
            this.tabAccess.TabIndex = 1;
            this.tabAccess.Text = "Access Levels";
            this.tabAccess.UseVisualStyleBackColor = true;
            // 
            // gridAccessLevels
            // 
            this.gridAccessLevels.AllowDrop = true;
            this.gridAccessLevels.AllowRowDeletion = true;
            this.gridAccessLevels.AllowUserToResizeRows = false;
            this.gridAccessLevels.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridAccessLevels.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridAccessLevels.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.gridAccessLevels.Location = new System.Drawing.Point(3, 3);
            this.gridAccessLevels.Name = "gridAccessLevels";
            this.gridAccessLevels.RowHeadersWidth = 20;
            this.gridAccessLevels.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridAccessLevels.Size = new System.Drawing.Size(593, 183);
            this.gridAccessLevels.TabIndex = 116;
            // 
            // tabSpawns
            // 
            this.tabSpawns.Controls.Add(this.gridSpawns);
            this.tabSpawns.Location = new System.Drawing.Point(4, 22);
            this.tabSpawns.Name = "tabSpawns";
            this.tabSpawns.Size = new System.Drawing.Size(599, 189);
            this.tabSpawns.TabIndex = 2;
            this.tabSpawns.Text = "Spawns";
            this.tabSpawns.UseVisualStyleBackColor = true;
            // 
            // gridSpawns
            // 
            this.gridSpawns.AllowDrop = true;
            this.gridSpawns.AllowRowDeletion = true;
            this.gridSpawns.AllowUserToResizeRows = false;
            this.gridSpawns.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridSpawns.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridSpawns.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.gridSpawns.Location = new System.Drawing.Point(0, 0);
            this.gridSpawns.Name = "gridSpawns";
            this.gridSpawns.RowHeadersWidth = 20;
            this.gridSpawns.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridSpawns.Size = new System.Drawing.Size(599, 189);
            this.gridSpawns.TabIndex = 117;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 41);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 13);
            this.label6.TabIndex = 117;
            this.label6.Text = "Display Name:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(336, 16);
            this.label7.Name = "label7";
            this.label7.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label7.Size = new System.Drawing.Size(95, 13);
            this.label7.TabIndex = 197;
            this.label7.Text = "Reset Rate (secs):";
            // 
            // numReset
            // 
            this.numReset.Location = new System.Drawing.Point(437, 17);
            this.numReset.Maximum = new decimal(new int[] {
            1410065408,
            2,
            0,
            0});
            this.numReset.Name = "numReset";
            this.numReset.Size = new System.Drawing.Size(67, 20);
            this.numReset.TabIndex = 196;
            // 
            // chkSystemZone
            // 
            this.chkSystemZone.AutoSize = true;
            this.chkSystemZone.Location = new System.Drawing.Point(339, 57);
            this.chkSystemZone.Name = "chkSystemZone";
            this.chkSystemZone.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkSystemZone.Size = new System.Drawing.Size(88, 17);
            this.chkSystemZone.TabIndex = 198;
            this.chkSystemZone.Text = "System Zone";
            this.chkSystemZone.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkSystemZone.UseVisualStyleBackColor = true;
            // 
            // ZoneControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.chkSystemZone);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.numReset);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.txtAuthor);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.txtDisplayName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtSystemName);
            this.Controls.Add(this.label2);
            this.Name = "ZoneControl";
            this.Size = new System.Drawing.Size(623, 417);
            this.tabControl1.ResumeLayout(false);
            this.tabSpaces.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridSpaces)).EndInit();
            this.tabAccess.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridAccessLevels)).EndInit();
            this.tabSpawns.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridSpawns)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numReset)).EndInit();
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
        private System.Windows.Forms.TextBox txtAuthor;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabSpaces;
        private AuraDataGridView gridSpaces;
        private System.Windows.Forms.TabPage tabAccess;
        private AuraDataGridView gridAccessLevels;
        private System.Windows.Forms.TabPage tabSpawns;
        private AuraDataGridView gridSpawns;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown numReset;
        private System.Windows.Forms.CheckBox chkSystemZone;
    }
}
