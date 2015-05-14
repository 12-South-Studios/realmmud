namespace RealmEdit
{
    partial class ShopControl
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
            this.label3 = new System.Windows.Forms.Label();
            this.txtSystemName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.numSell = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.numBuy = new System.Windows.Forms.NumericUpDown();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabItems = new System.Windows.Forms.TabPage();
            this.gridItems = new RealmEdit.AuraDataGridView();
            this.tabAbilities = new System.Windows.Forms.TabPage();
            this.gridAbilities = new RealmEdit.AuraDataGridView();
            this.tabItemTypes = new System.Windows.Forms.TabPage();
            this.gridItemTypes = new RealmEdit.AuraDataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.numSell)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBuy)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabItems.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridItems)).BeginInit();
            this.tabAbilities.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridAbilities)).BeginInit();
            this.tabItemTypes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridItemTypes)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 189;
            this.label3.Text = "System Name";
            // 
            // txtSystemName
            // 
            this.txtSystemName.Location = new System.Drawing.Point(106, 7);
            this.txtSystemName.Name = "txtSystemName";
            this.txtSystemName.Size = new System.Drawing.Size(202, 20);
            this.txtSystemName.TabIndex = 188;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 57);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label4.Size = new System.Drawing.Size(91, 13);
            this.label4.TabIndex = 201;
            this.label4.Text = "Sell Markup (Pct):";
            // 
            // numSell
            // 
            this.numSell.Location = new System.Drawing.Point(106, 59);
            this.numSell.Maximum = new decimal(new int[] {
            1410065408,
            2,
            0,
            0});
            this.numSell.Name = "numSell";
            this.numSell.Size = new System.Drawing.Size(98, 20);
            this.numSell.TabIndex = 200;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 31);
            this.label5.Name = "label5";
            this.label5.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label5.Size = new System.Drawing.Size(92, 13);
            this.label5.TabIndex = 199;
            this.label5.Text = "Buy Markup (Pct):";
            // 
            // numBuy
            // 
            this.numBuy.Location = new System.Drawing.Point(106, 33);
            this.numBuy.Maximum = new decimal(new int[] {
            1410065408,
            2,
            0,
            0});
            this.numBuy.Name = "numBuy";
            this.numBuy.Size = new System.Drawing.Size(98, 20);
            this.numBuy.TabIndex = 198;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabItems);
            this.tabControl1.Controls.Add(this.tabAbilities);
            this.tabControl1.Controls.Add(this.tabItemTypes);
            this.tabControl1.Location = new System.Drawing.Point(3, 101);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(551, 190);
            this.tabControl1.TabIndex = 221;
            // 
            // tabItems
            // 
            this.tabItems.Controls.Add(this.gridItems);
            this.tabItems.Location = new System.Drawing.Point(4, 22);
            this.tabItems.Name = "tabItems";
            this.tabItems.Padding = new System.Windows.Forms.Padding(3);
            this.tabItems.Size = new System.Drawing.Size(543, 164);
            this.tabItems.TabIndex = 0;
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
            this.gridItems.Location = new System.Drawing.Point(3, 3);
            this.gridItems.Name = "gridItems";
            this.gridItems.RowHeadersWidth = 20;
            this.gridItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridItems.Size = new System.Drawing.Size(537, 158);
            this.gridItems.TabIndex = 221;
            // 
            // tabAbilities
            // 
            this.tabAbilities.Controls.Add(this.gridAbilities);
            this.tabAbilities.Location = new System.Drawing.Point(4, 22);
            this.tabAbilities.Name = "tabAbilities";
            this.tabAbilities.Padding = new System.Windows.Forms.Padding(3);
            this.tabAbilities.Size = new System.Drawing.Size(361, 164);
            this.tabAbilities.TabIndex = 1;
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
            this.gridAbilities.Size = new System.Drawing.Size(355, 158);
            this.gridAbilities.TabIndex = 222;
            // 
            // tabItemTypes
            // 
            this.tabItemTypes.Controls.Add(this.gridItemTypes);
            this.tabItemTypes.Location = new System.Drawing.Point(4, 22);
            this.tabItemTypes.Name = "tabItemTypes";
            this.tabItemTypes.Size = new System.Drawing.Size(361, 164);
            this.tabItemTypes.TabIndex = 2;
            this.tabItemTypes.Text = "Item Types";
            this.tabItemTypes.UseVisualStyleBackColor = true;
            // 
            // gridItemTypes
            // 
            this.gridItemTypes.AllowDrop = true;
            this.gridItemTypes.AllowRowDeletion = true;
            this.gridItemTypes.AllowUserToResizeRows = false;
            this.gridItemTypes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridItemTypes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridItemTypes.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.gridItemTypes.Location = new System.Drawing.Point(0, 0);
            this.gridItemTypes.Name = "gridItemTypes";
            this.gridItemTypes.RowHeadersWidth = 20;
            this.gridItemTypes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridItemTypes.Size = new System.Drawing.Size(361, 164);
            this.gridItemTypes.TabIndex = 222;
            // 
            // ShopControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.numSell);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.numBuy);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtSystemName);
            this.Name = "ShopControl";
            this.Size = new System.Drawing.Size(557, 301);
            ((System.ComponentModel.ISupportInitialize)(this.numSell)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBuy)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabItems.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridItems)).EndInit();
            this.tabAbilities.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridAbilities)).EndInit();
            this.tabItemTypes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridItemTypes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSystemName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numSell;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numBuy;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabItems;
        private System.Windows.Forms.TabPage tabAbilities;
        private AuraDataGridView gridItems;
        private AuraDataGridView gridAbilities;
        private System.Windows.Forms.TabPage tabItemTypes;
        private AuraDataGridView gridItemTypes;
    }
}
