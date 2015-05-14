namespace RealmEdit
{
    partial class EffectHealthChangeControl
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
            this.cboDamage = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.rdoSteal = new System.Windows.Forms.RadioButton();
            this.label8 = new System.Windows.Forms.Label();
            this.numHealthBonus = new System.Windows.Forms.NumericUpDown();
            this.linkOnResist = new RealmEdit.AuraLinkLabel();
            this.label6 = new System.Windows.Forms.Label();
            this.linkOnFail = new RealmEdit.AuraLinkLabel();
            this.label5 = new System.Windows.Forms.Label();
            this.linkResistStat = new RealmEdit.AuraLinkLabel();
            this.label4 = new System.Windows.Forms.Label();
            this.rdoResurrect = new System.Windows.Forms.RadioButton();
            this.rdoHeal = new System.Windows.Forms.RadioButton();
            this.rdoDamage = new System.Windows.Forms.RadioButton();
            this.label7 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.numHealthMax = new System.Windows.Forms.NumericUpDown();
            this.numHealthMin = new System.Windows.Forms.NumericUpDown();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numHealthBonus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHealthMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHealthMin)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.cboDamage);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.rdoSteal);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.numHealthBonus);
            this.groupBox1.Controls.Add(this.linkOnResist);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.linkOnFail);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.linkResistStat);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.rdoResurrect);
            this.groupBox1.Controls.Add(this.rdoHeal);
            this.groupBox1.Controls.Add(this.rdoDamage);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.numHealthMax);
            this.groupBox1.Controls.Add(this.numHealthMin);
            this.groupBox1.Location = new System.Drawing.Point(7, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(652, 186);
            this.groupBox1.TabIndex = 209;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Health Change:";
            // 
            // cboDamage
            // 
            this.cboDamage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDamage.FormattingEnabled = true;
            this.cboDamage.Location = new System.Drawing.Point(245, 39);
            this.cboDamage.Name = "cboDamage";
            this.cboDamage.Size = new System.Drawing.Size(124, 21);
            this.cboDamage.TabIndex = 233;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(242, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 234;
            this.label1.Text = "Damage Type:";
            // 
            // rdoSteal
            // 
            this.rdoSteal.AutoSize = true;
            this.rdoSteal.Location = new System.Drawing.Point(230, 65);
            this.rdoSteal.Name = "rdoSteal";
            this.rdoSteal.Size = new System.Drawing.Size(49, 17);
            this.rdoSteal.TabIndex = 227;
            this.rdoSteal.Text = "Steal";
            this.rdoSteal.UseVisualStyleBackColor = true;

            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(163, 22);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 13);
            this.label8.TabIndex = 226;
            this.label8.Text = "Bonus Value:";
            // 
            // numHealthBonus
            // 
            this.numHealthBonus.Location = new System.Drawing.Point(166, 39);
            this.numHealthBonus.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numHealthBonus.Name = "numHealthBonus";
            this.numHealthBonus.Size = new System.Drawing.Size(57, 20);
            this.numHealthBonus.TabIndex = 225;
            this.numHealthBonus.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // linkOnResist
            // 
            this.linkOnResist.AllowDrop = true;
            this.linkOnResist.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.linkOnResist.Location = new System.Drawing.Point(304, 128);
            this.linkOnResist.Name = "linkOnResist";
            this.linkOnResist.Padding = new System.Windows.Forms.Padding(20, 1, 0, 0);
            this.linkOnResist.Size = new System.Drawing.Size(145, 21);
            this.linkOnResist.SystemType = RealmEdit.EditorSystemType.None;
            this.linkOnResist.TabIndex = 224;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(242, 128);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 13);
            this.label6.TabIndex = 223;
            this.label6.Text = "On Resist:";
            // 
            // linkOnFail
            // 
            this.linkOnFail.AllowDrop = true;
            this.linkOnFail.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.linkOnFail.Location = new System.Drawing.Point(304, 107);
            this.linkOnFail.Name = "linkOnFail";
            this.linkOnFail.Padding = new System.Windows.Forms.Padding(20, 1, 0, 0);
            this.linkOnFail.Size = new System.Drawing.Size(145, 21);
            this.linkOnFail.SystemType = RealmEdit.EditorSystemType.None;
            this.linkOnFail.TabIndex = 222;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(255, 108);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 221;
            this.label5.Text = "On Fail:";
            // 
            // linkResistStat
            // 
            this.linkResistStat.AllowDrop = true;
            this.linkResistStat.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.linkResistStat.Location = new System.Drawing.Point(78, 107);
            this.linkResistStat.Name = "linkResistStat";
            this.linkResistStat.Padding = new System.Windows.Forms.Padding(20, 1, 0, 0);
            this.linkResistStat.Size = new System.Drawing.Size(145, 21);
            this.linkResistStat.SystemType = RealmEdit.EditorSystemType.None;
            this.linkResistStat.TabIndex = 220;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 108);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 219;
            this.label4.Text = "Resist Stat:";
            // 
            // rdoResurrect
            // 
            this.rdoResurrect.AutoSize = true;
            this.rdoResurrect.Location = new System.Drawing.Point(153, 65);
            this.rdoResurrect.Name = "rdoResurrect";
            this.rdoResurrect.Size = new System.Drawing.Size(71, 17);
            this.rdoResurrect.TabIndex = 218;
            this.rdoResurrect.Text = "Resurrect";
            this.rdoResurrect.UseVisualStyleBackColor = true;
            // 
            // rdoHeal
            // 
            this.rdoHeal.AutoSize = true;
            this.rdoHeal.Location = new System.Drawing.Point(94, 65);
            this.rdoHeal.Name = "rdoHeal";
            this.rdoHeal.Size = new System.Drawing.Size(47, 17);
            this.rdoHeal.TabIndex = 217;
            this.rdoHeal.Text = "Heal";
            this.rdoHeal.UseVisualStyleBackColor = true;
            // 
            // rdoDamage
            // 
            this.rdoDamage.AutoSize = true;
            this.rdoDamage.Checked = true;
            this.rdoDamage.Location = new System.Drawing.Point(19, 65);
            this.rdoDamage.Name = "rdoDamage";
            this.rdoDamage.Size = new System.Drawing.Size(65, 17);
            this.rdoDamage.TabIndex = 216;
            this.rdoDamage.TabStop = true;
            this.rdoDamage.Text = "Damage";
            this.rdoDamage.UseVisualStyleBackColor = true;
            this.rdoDamage.CheckedChanged += new System.EventHandler(this.rdoDamage_CheckedChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(91, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 13);
            this.label7.TabIndex = 215;
            this.label7.Text = "Max Value:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(16, 23);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(57, 13);
            this.label11.TabIndex = 214;
            this.label11.Text = "Min Value:";
            // 
            // numHealthMax
            // 
            this.numHealthMax.Location = new System.Drawing.Point(94, 39);
            this.numHealthMax.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numHealthMax.Name = "numHealthMax";
            this.numHealthMax.Size = new System.Drawing.Size(57, 20);
            this.numHealthMax.TabIndex = 213;
            this.numHealthMax.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numHealthMin
            // 
            this.numHealthMin.Location = new System.Drawing.Point(19, 39);
            this.numHealthMin.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numHealthMin.Name = "numHealthMin";
            this.numHealthMin.Size = new System.Drawing.Size(65, 20);
            this.numHealthMin.TabIndex = 212;
            this.numHealthMin.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // EffectHealthChangeControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "EffectHealthChangeControl";
            this.Size = new System.Drawing.Size(662, 197);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numHealthBonus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHealthMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHealthMin)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown numHealthBonus;
        private AuraLinkLabel linkOnResist;
        private System.Windows.Forms.Label label6;
        private AuraLinkLabel linkOnFail;
        private System.Windows.Forms.Label label5;
        private AuraLinkLabel linkResistStat;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton rdoResurrect;
        private System.Windows.Forms.RadioButton rdoHeal;
        private System.Windows.Forms.RadioButton rdoDamage;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown numHealthMax;
        private System.Windows.Forms.NumericUpDown numHealthMin;
        private System.Windows.Forms.RadioButton rdoSteal;
        private System.Windows.Forms.ComboBox cboDamage;
        private System.Windows.Forms.Label label1;

    }
}
