namespace RealmEdit
{
    partial class ItemTrapControl
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
            this.linkEffect = new RealmEdit.AuraLinkLabel();
            this.label4 = new System.Windows.Forms.Label();
            this.lblNotifyRadius = new System.Windows.Forms.Label();
            this.numNotifyRadius = new System.Windows.Forms.NumericUpDown();
            this.chkIsAreaNotifier = new System.Windows.Forms.CheckBox();
            this.cboTargetClass = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboDifficulty = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.linkSpaceEffect = new RealmEdit.AuraLinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.chkIsDestroyedOnUse = new System.Windows.Forms.CheckBox();
            this.linkDisarmSkill = new RealmEdit.AuraLinkLabel();
            this.label14 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numNotifyRadius)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.linkEffect);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.lblNotifyRadius);
            this.groupBox1.Controls.Add(this.numNotifyRadius);
            this.groupBox1.Controls.Add(this.chkIsAreaNotifier);
            this.groupBox1.Controls.Add(this.cboTargetClass);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cboDifficulty);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.linkSpaceEffect);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.chkIsDestroyedOnUse);
            this.groupBox1.Controls.Add(this.linkDisarmSkill);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(652, 186);
            this.groupBox1.TabIndex = 221;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Lock:";
            // 
            // linkEffect
            // 
            this.linkEffect.AllowDrop = true;
            this.linkEffect.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.linkEffect.Location = new System.Drawing.Point(284, 69);
            this.linkEffect.Name = "linkEffect";
            this.linkEffect.Padding = new System.Windows.Forms.Padding(20, 1, 0, 0);
            this.linkEffect.Size = new System.Drawing.Size(149, 21);
            this.linkEffect.SystemType = RealmEdit.EditorSystemType.None;
            this.linkEffect.TabIndex = 233;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(281, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 232;
            this.label4.Text = "Effect:";
            // 
            // lblNotifyRadius
            // 
            this.lblNotifyRadius.AutoSize = true;
            this.lblNotifyRadius.Location = new System.Drawing.Point(7, 159);
            this.lblNotifyRadius.Name = "lblNotifyRadius";
            this.lblNotifyRadius.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblNotifyRadius.Size = new System.Drawing.Size(73, 13);
            this.lblNotifyRadius.TabIndex = 231;
            this.lblNotifyRadius.Text = "Notify Radius:";
            // 
            // numNotifyRadius
            // 
            this.numNotifyRadius.Location = new System.Drawing.Point(91, 157);
            this.numNotifyRadius.Maximum = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.numNotifyRadius.Name = "numNotifyRadius";
            this.numNotifyRadius.Size = new System.Drawing.Size(98, 20);
            this.numNotifyRadius.TabIndex = 230;
            // 
            // chkIsAreaNotifier
            // 
            this.chkIsAreaNotifier.AutoSize = true;
            this.chkIsAreaNotifier.Location = new System.Drawing.Point(91, 134);
            this.chkIsAreaNotifier.Name = "chkIsAreaNotifier";
            this.chkIsAreaNotifier.Size = new System.Drawing.Size(95, 17);
            this.chkIsAreaNotifier.TabIndex = 229;
            this.chkIsAreaNotifier.Text = "Is Area Notifier";
            this.chkIsAreaNotifier.UseVisualStyleBackColor = true;
            // 
            // cboTargetClass
            // 
            this.cboTargetClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTargetClass.FormattingEnabled = true;
            this.cboTargetClass.Location = new System.Drawing.Point(91, 107);
            this.cboTargetClass.Name = "cboTargetClass";
            this.cboTargetClass.Size = new System.Drawing.Size(124, 21);
            this.cboTargetClass.TabIndex = 228;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 227;
            this.label3.Text = "Target Class:";
            // 
            // cboDifficulty
            // 
            this.cboDifficulty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDifficulty.FormattingEnabled = true;
            this.cboDifficulty.Location = new System.Drawing.Point(91, 57);
            this.cboDifficulty.Name = "cboDifficulty";
            this.cboDifficulty.Size = new System.Drawing.Size(124, 21);
            this.cboDifficulty.TabIndex = 226;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 225;
            this.label2.Text = "Difficulty:";
            // 
            // linkSpaceEffect
            // 
            this.linkSpaceEffect.AllowDrop = true;
            this.linkSpaceEffect.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.linkSpaceEffect.Location = new System.Drawing.Point(284, 27);
            this.linkSpaceEffect.Name = "linkSpaceEffect";
            this.linkSpaceEffect.Padding = new System.Windows.Forms.Padding(20, 1, 0, 0);
            this.linkSpaceEffect.Size = new System.Drawing.Size(149, 21);
            this.linkSpaceEffect.SystemType = RealmEdit.EditorSystemType.None;
            this.linkSpaceEffect.TabIndex = 224;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(281, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 223;
            this.label1.Text = "Space Effect:";
            // 
            // chkIsDestroyedOnUse
            // 
            this.chkIsDestroyedOnUse.AutoSize = true;
            this.chkIsDestroyedOnUse.Location = new System.Drawing.Point(91, 84);
            this.chkIsDestroyedOnUse.Name = "chkIsDestroyedOnUse";
            this.chkIsDestroyedOnUse.Size = new System.Drawing.Size(124, 17);
            this.chkIsDestroyedOnUse.TabIndex = 222;
            this.chkIsDestroyedOnUse.Text = "Is Destroyed On Use";
            this.chkIsDestroyedOnUse.UseVisualStyleBackColor = true;
            // 
            // linkDisarmSkill
            // 
            this.linkDisarmSkill.AllowDrop = true;
            this.linkDisarmSkill.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.linkDisarmSkill.Location = new System.Drawing.Point(91, 27);
            this.linkDisarmSkill.Name = "linkDisarmSkill";
            this.linkDisarmSkill.Padding = new System.Windows.Forms.Padding(20, 1, 0, 0);
            this.linkDisarmSkill.Size = new System.Drawing.Size(149, 21);
            this.linkDisarmSkill.SystemType = RealmEdit.EditorSystemType.None;
            this.linkDisarmSkill.TabIndex = 221;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(16, 28);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(64, 13);
            this.label14.TabIndex = 220;
            this.label14.Text = "Disarm Skill:";
            // 
            // ItemTrapControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "ItemTrapControl";
            this.Size = new System.Drawing.Size(661, 200);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numNotifyRadius)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cboDifficulty;
        private System.Windows.Forms.Label label2;
        private AuraLinkLabel linkSpaceEffect;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkIsDestroyedOnUse;
        private AuraLinkLabel linkDisarmSkill;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.CheckBox chkIsAreaNotifier;
        private System.Windows.Forms.ComboBox cboTargetClass;
        private System.Windows.Forms.Label label3;
        private AuraLinkLabel linkEffect;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblNotifyRadius;
        private System.Windows.Forms.NumericUpDown numNotifyRadius;
    }
}
