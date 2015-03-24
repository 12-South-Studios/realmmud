namespace RealmEdit
{
    partial class ItemLightControl
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
            this.linkLiquidFuel = new RealmEdit.AuraLinkLabel();
            this.lblLiquidFuel = new System.Windows.Forms.Label();
            this.lblMaxCharges = new System.Windows.Forms.Label();
            this.numMaxCharges = new System.Windows.Forms.NumericUpDown();
            this.lblBurnRate = new System.Windows.Forms.Label();
            this.numBurnRate = new System.Windows.Forms.NumericUpDown();
            this.cboFuelType = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.lblBurnTime = new System.Windows.Forms.Label();
            this.numBurnTime = new System.Windows.Forms.NumericUpDown();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxCharges)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBurnRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBurnTime)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.linkLiquidFuel);
            this.groupBox1.Controls.Add(this.lblLiquidFuel);
            this.groupBox1.Controls.Add(this.lblMaxCharges);
            this.groupBox1.Controls.Add(this.numMaxCharges);
            this.groupBox1.Controls.Add(this.lblBurnRate);
            this.groupBox1.Controls.Add(this.numBurnRate);
            this.groupBox1.Controls.Add(this.cboFuelType);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.lblBurnTime);
            this.groupBox1.Controls.Add(this.numBurnTime);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(652, 186);
            this.groupBox1.TabIndex = 206;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Light:";
            // 
            // linkLiquidFuel
            // 
            this.linkLiquidFuel.AllowDrop = true;
            this.linkLiquidFuel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.linkLiquidFuel.Location = new System.Drawing.Point(99, 51);
            this.linkLiquidFuel.Name = "linkLiquidFuel";
            this.linkLiquidFuel.Padding = new System.Windows.Forms.Padding(20, 1, 0, 0);
            this.linkLiquidFuel.Size = new System.Drawing.Size(149, 21);
            this.linkLiquidFuel.SystemType = RealmEdit.EditorSystemType.None;
            this.linkLiquidFuel.TabIndex = 215;
            // 
            // lblLiquidFuel
            // 
            this.lblLiquidFuel.AutoSize = true;
            this.lblLiquidFuel.Location = new System.Drawing.Point(26, 54);
            this.lblLiquidFuel.Name = "lblLiquidFuel";
            this.lblLiquidFuel.Size = new System.Drawing.Size(61, 13);
            this.lblLiquidFuel.TabIndex = 216;
            this.lblLiquidFuel.Text = "Liquid Fuel:";
            // 
            // lblMaxCharges
            // 
            this.lblMaxCharges.AutoSize = true;
            this.lblMaxCharges.Location = new System.Drawing.Point(15, 104);
            this.lblMaxCharges.Name = "lblMaxCharges";
            this.lblMaxCharges.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblMaxCharges.Size = new System.Drawing.Size(72, 13);
            this.lblMaxCharges.TabIndex = 214;
            this.lblMaxCharges.Text = "Max Charges:";
            // 
            // numMaxCharges
            // 
            this.numMaxCharges.Location = new System.Drawing.Point(99, 104);
            this.numMaxCharges.Maximum = new decimal(new int[] {
            1410065408,
            2,
            0,
            0});
            this.numMaxCharges.Name = "numMaxCharges";
            this.numMaxCharges.Size = new System.Drawing.Size(98, 20);
            this.numMaxCharges.TabIndex = 213;
            // 
            // lblBurnRate
            // 
            this.lblBurnRate.AutoSize = true;
            this.lblBurnRate.Location = new System.Drawing.Point(29, 78);
            this.lblBurnRate.Name = "lblBurnRate";
            this.lblBurnRate.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblBurnRate.Size = new System.Drawing.Size(58, 13);
            this.lblBurnRate.TabIndex = 212;
            this.lblBurnRate.Text = "Burn Rate:";
            // 
            // numBurnRate
            // 
            this.numBurnRate.Location = new System.Drawing.Point(99, 78);
            this.numBurnRate.Maximum = new decimal(new int[] {
            1410065408,
            2,
            0,
            0});
            this.numBurnRate.Name = "numBurnRate";
            this.numBurnRate.Size = new System.Drawing.Size(98, 20);
            this.numBurnRate.TabIndex = 211;
            // 
            // cboFuelType
            // 
            this.cboFuelType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFuelType.FormattingEnabled = true;
            this.cboFuelType.Location = new System.Drawing.Point(99, 19);
            this.cboFuelType.Name = "cboFuelType";
            this.cboFuelType.Size = new System.Drawing.Size(124, 21);
            this.cboFuelType.TabIndex = 210;
            this.cboFuelType.SelectedValueChanged += new System.EventHandler(this.cboFuelType_Changed);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(30, 22);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(57, 13);
            this.label14.TabIndex = 209;
            this.label14.Text = "Fuel Type:";
            // 
            // lblBurnTime
            // 
            this.lblBurnTime.AutoSize = true;
            this.lblBurnTime.Location = new System.Drawing.Point(29, 52);
            this.lblBurnTime.Name = "lblBurnTime";
            this.lblBurnTime.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblBurnTime.Size = new System.Drawing.Size(58, 13);
            this.lblBurnTime.TabIndex = 208;
            this.lblBurnTime.Text = "Burn Time:";
            // 
            // numBurnTime
            // 
            this.numBurnTime.Location = new System.Drawing.Point(99, 52);
            this.numBurnTime.Maximum = new decimal(new int[] {
            1410065408,
            2,
            0,
            0});
            this.numBurnTime.Name = "numBurnTime";
            this.numBurnTime.Size = new System.Drawing.Size(98, 20);
            this.numBurnTime.TabIndex = 207;
            // 
            // ItemLightControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "ItemLightControl";
            this.Size = new System.Drawing.Size(666, 198);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxCharges)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBurnRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBurnTime)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblBurnRate;
        private System.Windows.Forms.NumericUpDown numBurnRate;
        private System.Windows.Forms.ComboBox cboFuelType;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lblBurnTime;
        private System.Windows.Forms.NumericUpDown numBurnTime;
        private System.Windows.Forms.Label lblMaxCharges;
        private System.Windows.Forms.NumericUpDown numMaxCharges;
        private AuraLinkLabel linkLiquidFuel;
        private System.Windows.Forms.Label lblLiquidFuel;
    }
}
