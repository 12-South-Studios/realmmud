namespace RealmEdit
{
    partial class ItemDrinkContainerControl
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
            this.linkLiquid = new RealmEdit.AuraLinkLabel();
            this.chkIsCloseable = new System.Windows.Forms.CheckBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.numCharges = new System.Windows.Forms.NumericUpDown();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCharges)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.linkLiquid);
            this.groupBox1.Controls.Add(this.chkIsCloseable);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.numCharges);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(652, 186);
            this.groupBox1.TabIndex = 206;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Drink Container:";
            // 
            // linkLiquid
            // 
            this.linkLiquid.AllowDrop = true;
            this.linkLiquid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.linkLiquid.Location = new System.Drawing.Point(113, 58);
            this.linkLiquid.Name = "linkLiquid";
            this.linkLiquid.Padding = new System.Windows.Forms.Padding(20, 1, 0, 0);
            this.linkLiquid.Size = new System.Drawing.Size(149, 21);
            this.linkLiquid.SystemType = RealmEdit.EditorSystemType.None;
            this.linkLiquid.TabIndex = 212;
            // 
            // chkIsCloseable
            // 
            this.chkIsCloseable.AutoSize = true;
            this.chkIsCloseable.Location = new System.Drawing.Point(113, 91);
            this.chkIsCloseable.Name = "chkIsCloseable";
            this.chkIsCloseable.Size = new System.Drawing.Size(83, 17);
            this.chkIsCloseable.TabIndex = 211;
            this.chkIsCloseable.Text = "Is Closeable";
            this.chkIsCloseable.UseVisualStyleBackColor = true;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(43, 59);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(59, 13);
            this.label14.TabIndex = 209;
            this.label14.Text = "Filled With:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(30, 31);
            this.label5.Name = "label5";
            this.label5.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label5.Size = new System.Drawing.Size(72, 13);
            this.label5.TabIndex = 206;
            this.label5.Text = "Max Charges:";
            // 
            // numCharges
            // 
            this.numCharges.Location = new System.Drawing.Point(113, 31);
            this.numCharges.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.numCharges.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.numCharges.Name = "numCharges";
            this.numCharges.Size = new System.Drawing.Size(98, 20);
            this.numCharges.TabIndex = 205;
            // 
            // ItemDrinkContainerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "ItemDrinkContainerControl";
            this.Size = new System.Drawing.Size(662, 199);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCharges)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkIsCloseable;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numCharges;
        private AuraLinkLabel linkLiquid;
    }
}
