namespace RealmEdit
{
    partial class ItemLockControl
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
            this.cboDifficulty = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.linkKey = new RealmEdit.AuraLinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.chkIsRelockable = new System.Windows.Forms.CheckBox();
            this.linkPickSkill = new RealmEdit.AuraLinkLabel();
            this.label14 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.cboDifficulty);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.linkKey);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.chkIsRelockable);
            this.groupBox1.Controls.Add(this.linkPickSkill);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(652, 186);
            this.groupBox1.TabIndex = 220;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Lock:";
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
            // linkKey
            // 
            this.linkKey.AllowDrop = true;
            this.linkKey.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.linkKey.Location = new System.Drawing.Point(91, 104);
            this.linkKey.Name = "linkKey";
            this.linkKey.Padding = new System.Windows.Forms.Padding(20, 1, 0, 0);
            this.linkKey.Size = new System.Drawing.Size(149, 21);
            this.linkKey.SystemType = RealmEdit.EditorSystemType.None;
            this.linkKey.TabIndex = 224;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(52, 105);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 13);
            this.label1.TabIndex = 223;
            this.label1.Text = "Key:";
            // 
            // chkIsRelockable
            // 
            this.chkIsRelockable.AutoSize = true;
            this.chkIsRelockable.Location = new System.Drawing.Point(13, 84);
            this.chkIsRelockable.Name = "chkIsRelockable";
            this.chkIsRelockable.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkIsRelockable.Size = new System.Drawing.Size(91, 17);
            this.chkIsRelockable.TabIndex = 222;
            this.chkIsRelockable.Text = "Is Relockable";
            this.chkIsRelockable.UseVisualStyleBackColor = true;
            // 
            // linkPickSkill
            // 
            this.linkPickSkill.AllowDrop = true;
            this.linkPickSkill.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.linkPickSkill.Location = new System.Drawing.Point(91, 27);
            this.linkPickSkill.Name = "linkPickSkill";
            this.linkPickSkill.Padding = new System.Windows.Forms.Padding(20, 1, 0, 0);
            this.linkPickSkill.Size = new System.Drawing.Size(149, 21);
            this.linkPickSkill.SystemType = RealmEdit.EditorSystemType.None;
            this.linkPickSkill.TabIndex = 221;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(27, 28);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(53, 13);
            this.label14.TabIndex = 220;
            this.label14.Text = "Pick Skill:";
            // 
            // ItemLockControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "ItemLockControl";
            this.Size = new System.Drawing.Size(662, 197);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cboDifficulty;
        private System.Windows.Forms.Label label2;
        private AuraLinkLabel linkKey;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkIsRelockable;
        private AuraLinkLabel linkPickSkill;
        private System.Windows.Forms.Label label14;

    }
}
