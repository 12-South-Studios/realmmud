namespace RealmEdit
{
    partial class ItemMagicalNodeControl
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
            this.cboElementType = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.numAuraTime = new System.Windows.Forms.NumericUpDown();
            this.linkAuraEffect = new RealmEdit.AuraLinkLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAuraTime)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.linkAuraEffect);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.numAuraTime);
            this.groupBox1.Controls.Add(this.cboElementType);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(652, 186);
            this.groupBox1.TabIndex = 208;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Machine:";
            // 
            // cboElementType
            // 
            this.cboElementType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboElementType.FormattingEnabled = true;
            this.cboElementType.Location = new System.Drawing.Point(99, 19);
            this.cboElementType.Name = "cboElementType";
            this.cboElementType.Size = new System.Drawing.Size(124, 21);
            this.cboElementType.TabIndex = 210;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(15, 22);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(75, 13);
            this.label14.TabIndex = 209;
            this.label14.Text = "Element Type:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 67);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 212;
            this.label1.Text = "Aura Refresh (s):";
            // 
            // numAuraTime
            // 
            this.numAuraTime.Location = new System.Drawing.Point(99, 67);
            this.numAuraTime.Maximum = new decimal(new int[] {
            1410065408,
            2,
            0,
            0});
            this.numAuraTime.Name = "numAuraTime";
            this.numAuraTime.Size = new System.Drawing.Size(98, 20);
            this.numAuraTime.TabIndex = 211;
            // 
            // linkAuraEffect
            // 
            this.linkAuraEffect.AllowDrop = true;
            this.linkAuraEffect.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.linkAuraEffect.Location = new System.Drawing.Point(99, 43);
            this.linkAuraEffect.Name = "linkAuraEffect";
            this.linkAuraEffect.Padding = new System.Windows.Forms.Padding(20, 1, 0, 0);
            this.linkAuraEffect.Size = new System.Drawing.Size(149, 21);
            this.linkAuraEffect.SystemType = RealmEdit.EditorSystemType.Effect;
            this.linkAuraEffect.TabIndex = 214;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 213;
            this.label2.Text = "Aura Effect:";
            // 
            // ItemMagicalNodeControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "ItemMagicalNodeControl";
            this.Size = new System.Drawing.Size(662, 197);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAuraTime)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cboElementType;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numAuraTime;
        private AuraLinkLabel linkAuraEffect;
        private System.Windows.Forms.Label label2;
    }
}
