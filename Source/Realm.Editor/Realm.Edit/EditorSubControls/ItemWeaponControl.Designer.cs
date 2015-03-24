namespace RealmEdit
{
    partial class ItemWeaponControl
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
            this.cboWeaponSpeed = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.chkIsThrowable = new System.Windows.Forms.CheckBox();
            this.linkEffect = new RealmEdit.AuraLinkLabel();
            this.label14 = new System.Windows.Forms.Label();
            this.cboWeaponType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.cboWeaponType);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cboWeaponSpeed);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.chkIsThrowable);
            this.groupBox1.Controls.Add(this.linkEffect);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(652, 186);
            this.groupBox1.TabIndex = 220;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Weapon:";
            // 
            // cboWeaponSpeed
            // 
            this.cboWeaponSpeed.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboWeaponSpeed.FormattingEnabled = true;
            this.cboWeaponSpeed.Location = new System.Drawing.Point(91, 57);
            this.cboWeaponSpeed.Name = "cboWeaponSpeed";
            this.cboWeaponSpeed.Size = new System.Drawing.Size(124, 21);
            this.cboWeaponSpeed.TabIndex = 226;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 225;
            this.label2.Text = "Speed:";
            // 
            // chkIsThrowable
            // 
            this.chkIsThrowable.AutoSize = true;
            this.chkIsThrowable.Location = new System.Drawing.Point(16, 105);
            this.chkIsThrowable.Name = "chkIsThrowable";
            this.chkIsThrowable.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkIsThrowable.Size = new System.Drawing.Size(87, 17);
            this.chkIsThrowable.TabIndex = 222;
            this.chkIsThrowable.Text = "Is Throwable";
            this.chkIsThrowable.UseVisualStyleBackColor = true;
            // 
            // linkEffect
            // 
            this.linkEffect.AllowDrop = true;
            this.linkEffect.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.linkEffect.Location = new System.Drawing.Point(91, 81);
            this.linkEffect.Name = "linkEffect";
            this.linkEffect.Padding = new System.Windows.Forms.Padding(20, 1, 0, 0);
            this.linkEffect.Size = new System.Drawing.Size(149, 21);
            this.linkEffect.SystemType = RealmEdit.EditorSystemType.Effect;
            this.linkEffect.TabIndex = 221;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(33, 81);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(38, 13);
            this.label14.TabIndex = 220;
            this.label14.Text = "Effect:";
            // 
            // cboWeaponType
            // 
            this.cboWeaponType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboWeaponType.FormattingEnabled = true;
            this.cboWeaponType.Location = new System.Drawing.Point(91, 30);
            this.cboWeaponType.Name = "cboWeaponType";
            this.cboWeaponType.Size = new System.Drawing.Size(124, 21);
            this.cboWeaponType.TabIndex = 228;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 227;
            this.label1.Text = "Type:";
            // 
            // ItemWeaponControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "ItemWeaponControl";
            this.Size = new System.Drawing.Size(662, 197);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cboWeaponSpeed;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkIsThrowable;
        private AuraLinkLabel linkEffect;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cboWeaponType;
        private System.Windows.Forms.Label label1;

    }
}
