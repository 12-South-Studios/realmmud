namespace RealmEdit
{
    partial class EffectStatModControl
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
            this.linkStatAffected = new RealmEdit.AuraLinkLabel();
            this.lblMaxValue = new System.Windows.Forms.Label();
            this.lblMinValue = new System.Windows.Forms.Label();
            this.numStatMax = new System.Windows.Forms.NumericUpDown();
            this.numStatMin = new System.Windows.Forms.NumericUpDown();
            this.lblStatAffected = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numStatMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numStatMin)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.linkStatAffected);
            this.groupBox1.Controls.Add(this.lblMaxValue);
            this.groupBox1.Controls.Add(this.lblMinValue);
            this.groupBox1.Controls.Add(this.numStatMax);
            this.groupBox1.Controls.Add(this.numStatMin);
            this.groupBox1.Controls.Add(this.lblStatAffected);
            this.groupBox1.Location = new System.Drawing.Point(5, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(652, 186);
            this.groupBox1.TabIndex = 210;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Statistic Mod:";
            // 
            // linkStatAffected
            // 
            this.linkStatAffected.AllowDrop = true;
            this.linkStatAffected.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.linkStatAffected.Location = new System.Drawing.Point(9, 46);
            this.linkStatAffected.Name = "linkStatAffected";
            this.linkStatAffected.Padding = new System.Windows.Forms.Padding(20, 1, 0, 0);
            this.linkStatAffected.Size = new System.Drawing.Size(206, 21);
            this.linkStatAffected.SystemType = RealmEdit.EditorSystemType.None;
            this.linkStatAffected.TabIndex = 209;
            // 
            // lblMaxValue
            // 
            this.lblMaxValue.AutoSize = true;
            this.lblMaxValue.Location = new System.Drawing.Point(113, 73);
            this.lblMaxValue.Name = "lblMaxValue";
            this.lblMaxValue.Size = new System.Drawing.Size(60, 13);
            this.lblMaxValue.TabIndex = 208;
            this.lblMaxValue.Text = "Max Value:";
            // 
            // lblMinValue
            // 
            this.lblMinValue.AutoSize = true;
            this.lblMinValue.Location = new System.Drawing.Point(6, 73);
            this.lblMinValue.Name = "lblMinValue";
            this.lblMinValue.Size = new System.Drawing.Size(57, 13);
            this.lblMinValue.TabIndex = 207;
            this.lblMinValue.Text = "Min Value:";
            // 
            // numStatMax
            // 
            this.numStatMax.Location = new System.Drawing.Point(116, 88);
            this.numStatMax.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numStatMax.Minimum = new decimal(new int[] {
            9999,
            0,
            0,
            -2147483648});
            this.numStatMax.Name = "numStatMax";
            this.numStatMax.Size = new System.Drawing.Size(99, 20);
            this.numStatMax.TabIndex = 206;
            this.numStatMax.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numStatMin
            // 
            this.numStatMin.Location = new System.Drawing.Point(9, 88);
            this.numStatMin.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numStatMin.Minimum = new decimal(new int[] {
            9999,
            0,
            0,
            -2147483648});
            this.numStatMin.Name = "numStatMin";
            this.numStatMin.Size = new System.Drawing.Size(99, 20);
            this.numStatMin.TabIndex = 205;
            this.numStatMin.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblStatAffected
            // 
            this.lblStatAffected.AutoSize = true;
            this.lblStatAffected.Location = new System.Drawing.Point(6, 28);
            this.lblStatAffected.Name = "lblStatAffected";
            this.lblStatAffected.Size = new System.Drawing.Size(72, 13);
            this.lblStatAffected.TabIndex = 204;
            this.lblStatAffected.Text = "Stat Affected:";
            // 
            // EffectStatModControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "EffectStatModControl";
            this.Size = new System.Drawing.Size(662, 197);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numStatMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numStatMin)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private AuraLinkLabel linkStatAffected;
        private System.Windows.Forms.Label lblMaxValue;
        private System.Windows.Forms.Label lblMinValue;
        private System.Windows.Forms.NumericUpDown numStatMax;
        private System.Windows.Forms.NumericUpDown numStatMin;
        private System.Windows.Forms.Label lblStatAffected;
    }
}
