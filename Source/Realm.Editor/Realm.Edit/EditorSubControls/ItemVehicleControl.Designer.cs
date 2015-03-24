namespace RealmEdit
{
    partial class ItemVehicleControl
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
            this.label2 = new System.Windows.Forms.Label();
            this.numMaxSeating = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.gridTerrain = new RealmEdit.AuraDataGridView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxSeating)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridTerrain)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.numMaxSeating);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.gridTerrain);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(652, 233);
            this.groupBox1.TabIndex = 208;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Vehicle:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 31);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 214;
            this.label2.Text = "Max Seating:";
            // 
            // numMaxSeating
            // 
            this.numMaxSeating.Location = new System.Drawing.Point(96, 29);
            this.numMaxSeating.Maximum = new decimal(new int[] {
            1410065408,
            2,
            0,
            0});
            this.numMaxSeating.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numMaxSeating.Name = "numMaxSeating";
            this.numMaxSeating.Size = new System.Drawing.Size(98, 20);
            this.numMaxSeating.TabIndex = 213;
            this.numMaxSeating.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 13);
            this.label1.TabIndex = 212;
            this.label1.Text = "Dis-allowed Terrain:";
            // 
            // gridTerrain
            // 
            this.gridTerrain.AllowDrop = true;
            this.gridTerrain.AllowRowDeletion = true;
            this.gridTerrain.AllowUserToResizeRows = false;
            this.gridTerrain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridTerrain.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.gridTerrain.Location = new System.Drawing.Point(28, 87);
            this.gridTerrain.Name = "gridTerrain";
            this.gridTerrain.RowHeadersWidth = 20;
            this.gridTerrain.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridTerrain.Size = new System.Drawing.Size(240, 128);
            this.gridTerrain.TabIndex = 211;
            // 
            // ItemVehicleControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "ItemVehicleControl";
            this.Size = new System.Drawing.Size(662, 244);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxSeating)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridTerrain)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private AuraDataGridView gridTerrain;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numMaxSeating;
    }
}
