namespace RealmEdit
{
    partial class SpawnControl
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
            this.txtSystemName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabNpcs = new System.Windows.Forms.TabPage();
            this.gridNpcs = new RealmEdit.AuraDataGridView();
            this.tabItems = new System.Windows.Forms.TabPage();
            this.gridItems = new RealmEdit.AuraDataGridView();
            this.tabPlaces = new System.Windows.Forms.TabPage();
            this.gridAccess = new RealmEdit.AuraDataGridView();
            this.gridSpaces = new RealmEdit.AuraDataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.numMaxQty = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.numMinQty = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.numPctChance = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.numRespawnPeriod = new System.Windows.Forms.NumericUpDown();
            this.cboSpawnType = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabNpcs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridNpcs)).BeginInit();
            this.tabItems.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridItems)).BeginInit();
            this.tabPlaces.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridAccess)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridSpaces)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxQty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinQty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPctChance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRespawnPeriod)).BeginInit();
            this.SuspendLayout();
            // 
            // txtSystemName
            // 
            this.txtSystemName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSystemName.Location = new System.Drawing.Point(3, 20);
            this.txtSystemName.Name = "txtSystemName";
            this.txtSystemName.Size = new System.Drawing.Size(237, 20);
            this.txtSystemName.TabIndex = 39;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(2, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 38;
            this.label2.Text = "System Name:";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabNpcs);
            this.tabControl1.Controls.Add(this.tabItems);
            this.tabControl1.Controls.Add(this.tabPlaces);
            this.tabControl1.Location = new System.Drawing.Point(0, 192);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(581, 219);
            this.tabControl1.TabIndex = 40;
            // 
            // tabNpcs
            // 
            this.tabNpcs.Controls.Add(this.gridNpcs);
            this.tabNpcs.Location = new System.Drawing.Point(4, 22);
            this.tabNpcs.Name = "tabNpcs";
            this.tabNpcs.Padding = new System.Windows.Forms.Padding(3);
            this.tabNpcs.Size = new System.Drawing.Size(573, 193);
            this.tabNpcs.TabIndex = 0;
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
            this.gridNpcs.Size = new System.Drawing.Size(567, 187);
            this.gridNpcs.TabIndex = 0;
            // 
            // tabItems
            // 
            this.tabItems.Controls.Add(this.gridItems);
            this.tabItems.Location = new System.Drawing.Point(4, 22);
            this.tabItems.Name = "tabItems";
            this.tabItems.Size = new System.Drawing.Size(573, 193);
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
            this.gridItems.Size = new System.Drawing.Size(573, 193);
            this.gridItems.TabIndex = 2;
            // 
            // tabPlaces
            // 
            this.tabPlaces.Controls.Add(this.gridAccess);
            this.tabPlaces.Controls.Add(this.gridSpaces);
            this.tabPlaces.Location = new System.Drawing.Point(4, 22);
            this.tabPlaces.Name = "tabPlaces";
            this.tabPlaces.Padding = new System.Windows.Forms.Padding(3);
            this.tabPlaces.Size = new System.Drawing.Size(573, 193);
            this.tabPlaces.TabIndex = 1;
            this.tabPlaces.Text = "Places";
            this.tabPlaces.UseVisualStyleBackColor = true;
            // 
            // gridAccess
            // 
            this.gridAccess.AllowDrop = true;
            this.gridAccess.AllowRowDeletion = true;
            this.gridAccess.AllowUserToResizeRows = false;
            this.gridAccess.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridAccess.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridAccess.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.gridAccess.Location = new System.Drawing.Point(3, 3);
            this.gridAccess.Name = "gridAccess";
            this.gridAccess.RowHeadersWidth = 20;
            this.gridAccess.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridAccess.Size = new System.Drawing.Size(567, 187);
            this.gridAccess.TabIndex = 212;
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
            this.gridSpaces.Size = new System.Drawing.Size(567, 187);
            this.gridSpaces.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(49, 74);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label4.Size = new System.Drawing.Size(75, 13);
            this.label4.TabIndex = 205;
            this.label4.Text = "Max. Quantity:";
            // 
            // numMaxQty
            // 
            this.numMaxQty.Location = new System.Drawing.Point(131, 72);
            this.numMaxQty.Maximum = new decimal(new int[] {
            1410065408,
            2,
            0,
            0});
            this.numMaxQty.Name = "numMaxQty";
            this.numMaxQty.Size = new System.Drawing.Size(98, 20);
            this.numMaxQty.TabIndex = 204;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(52, 48);
            this.label5.Name = "label5";
            this.label5.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label5.Size = new System.Drawing.Size(72, 13);
            this.label5.TabIndex = 203;
            this.label5.Text = "Min. Quantity:";
            // 
            // numMinQty
            // 
            this.numMinQty.Location = new System.Drawing.Point(131, 46);
            this.numMinQty.Maximum = new decimal(new int[] {
            1410065408,
            2,
            0,
            0});
            this.numMinQty.Name = "numMinQty";
            this.numMinQty.Size = new System.Drawing.Size(98, 20);
            this.numMinQty.TabIndex = 202;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(66, 98);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 207;
            this.label1.Text = "% Chance:";
            // 
            // numPctChance
            // 
            this.numPctChance.Location = new System.Drawing.Point(131, 98);
            this.numPctChance.Maximum = new decimal(new int[] {
            1410065408,
            2,
            0,
            0});
            this.numPctChance.Name = "numPctChance";
            this.numPctChance.Size = new System.Drawing.Size(98, 20);
            this.numPctChance.TabIndex = 206;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 124);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label3.Size = new System.Drawing.Size(119, 13);
            this.label3.TabIndex = 209;
            this.label3.Text = "Respawn Period (secs):";
            // 
            // numRespawnPeriod
            // 
            this.numRespawnPeriod.Location = new System.Drawing.Point(131, 124);
            this.numRespawnPeriod.Maximum = new decimal(new int[] {
            1410065408,
            2,
            0,
            0});
            this.numRespawnPeriod.Name = "numRespawnPeriod";
            this.numRespawnPeriod.Size = new System.Drawing.Size(98, 20);
            this.numRespawnPeriod.TabIndex = 208;
            // 
            // cboSpawnType
            // 
            this.cboSpawnType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSpawnType.FormattingEnabled = true;
            this.cboSpawnType.Location = new System.Drawing.Point(131, 150);
            this.cboSpawnType.Name = "cboSpawnType";
            this.cboSpawnType.Size = new System.Drawing.Size(124, 21);
            this.cboSpawnType.TabIndex = 211;
            this.cboSpawnType.SelectedIndexChanged += new System.EventHandler(this.cboSpawnType_SelectedIndexChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(49, 150);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(70, 13);
            this.label14.TabIndex = 210;
            this.label14.Text = "Spawn Type:";
            // 
            // SpawnControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cboSpawnType);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numRespawnPeriod);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numPctChance);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.numMaxQty);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.numMinQty);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.txtSystemName);
            this.Controls.Add(this.label2);
            this.Name = "SpawnControl";
            this.Size = new System.Drawing.Size(584, 422);
            this.tabControl1.ResumeLayout(false);
            this.tabNpcs.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridNpcs)).EndInit();
            this.tabItems.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridItems)).EndInit();
            this.tabPlaces.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridAccess)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridSpaces)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxQty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinQty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPctChance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRespawnPeriod)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSystemName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabNpcs;
        private System.Windows.Forms.TabPage tabPlaces;
        private AuraDataGridView gridNpcs;
        private AuraDataGridView gridSpaces;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numMaxQty;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numMinQty;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numPctChance;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numRespawnPeriod;
        private System.Windows.Forms.ComboBox cboSpawnType;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TabPage tabItems;
        private AuraDataGridView gridItems;
        private AuraDataGridView gridAccess;
    }
}
