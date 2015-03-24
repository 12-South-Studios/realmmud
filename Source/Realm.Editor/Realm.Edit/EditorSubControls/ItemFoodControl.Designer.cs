namespace RealmEdit
{
    partial class ItemFoodControl
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
            this.label3 = new System.Windows.Forms.Label();
            this.txtDecayDescription = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.numDecayTime = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.numGoodTime = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.numCharges = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.numHungerPoints = new System.Windows.Forms.NumericUpDown();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDecayTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numGoodTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCharges)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHungerPoints)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtDecayDescription);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.numDecayTime);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.numGoodTime);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.numCharges);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.numHungerPoints);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(652, 186);
            this.groupBox1.TabIndex = 206;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Food:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.label3.Location = new System.Drawing.Point(260, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 13);
            this.label3.TabIndex = 214;
            this.label3.Text = "Decay Description:";
            // 
            // txtDecayDescription
            // 
            this.txtDecayDescription.Location = new System.Drawing.Point(363, 59);
            this.txtDecayDescription.Multiline = true;
            this.txtDecayDescription.Name = "txtDecayDescription";
            this.txtDecayDescription.Size = new System.Drawing.Size(283, 66);
            this.txtDecayDescription.TabIndex = 213;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(279, 31);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 212;
            this.label2.Text = "Decay Time(s):";
            // 
            // numDecayTime
            // 
            this.numDecayTime.Location = new System.Drawing.Point(363, 31);
            this.numDecayTime.Maximum = new decimal(new int[] {
            1410065408,
            2,
            0,
            0});
            this.numDecayTime.Name = "numDecayTime";
            this.numDecayTime.Size = new System.Drawing.Size(98, 20);
            this.numDecayTime.TabIndex = 211;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 83);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 210;
            this.label1.Text = "Good Time (s):";
            // 
            // numGoodTime
            // 
            this.numGoodTime.Location = new System.Drawing.Point(113, 83);
            this.numGoodTime.Maximum = new decimal(new int[] {
            1410065408,
            2,
            0,
            0});
            this.numGoodTime.Name = "numGoodTime";
            this.numGoodTime.Size = new System.Drawing.Size(98, 20);
            this.numGoodTime.TabIndex = 209;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(58, 57);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 208;
            this.label4.Text = "Charges:";
            // 
            // numCharges
            // 
            this.numCharges.Location = new System.Drawing.Point(113, 57);
            this.numCharges.Maximum = new decimal(new int[] {
            1410065408,
            2,
            0,
            0});
            this.numCharges.Name = "numCharges";
            this.numCharges.Size = new System.Drawing.Size(98, 20);
            this.numCharges.TabIndex = 207;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(30, 31);
            this.label5.Name = "label5";
            this.label5.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label5.Size = new System.Drawing.Size(77, 13);
            this.label5.TabIndex = 206;
            this.label5.Text = "Hunger Points:";
            // 
            // numHungerPoints
            // 
            this.numHungerPoints.Location = new System.Drawing.Point(113, 31);
            this.numHungerPoints.Maximum = new decimal(new int[] {
            1410065408,
            2,
            0,
            0});
            this.numHungerPoints.Name = "numHungerPoints";
            this.numHungerPoints.Size = new System.Drawing.Size(98, 20);
            this.numHungerPoints.TabIndex = 205;
            // 
            // ItemFoodControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "ItemFoodControl";
            this.Size = new System.Drawing.Size(660, 194);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDecayTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numGoodTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCharges)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHungerPoints)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numDecayTime;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numGoodTime;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numCharges;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numHungerPoints;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDecayDescription;
    }
}
