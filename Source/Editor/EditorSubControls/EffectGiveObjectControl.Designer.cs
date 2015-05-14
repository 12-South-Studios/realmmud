namespace RealmEdit
{
    partial class EffectGiveObjectControl
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
            this.linkGive = new RealmEdit.AuraLinkLabel();
            this.lblGive = new System.Windows.Forms.Label();
            this.radGiveItem = new System.Windows.Forms.RadioButton();
            this.radGiveStat = new System.Windows.Forms.RadioButton();
            this.radGiveAbility = new System.Windows.Forms.RadioButton();
            this.radGiveRitual = new System.Windows.Forms.RadioButton();
            this.radGiveQuest = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.radGiveQuest);
            this.groupBox1.Controls.Add(this.radGiveRitual);
            this.groupBox1.Controls.Add(this.linkGive);
            this.groupBox1.Controls.Add(this.lblGive);
            this.groupBox1.Controls.Add(this.radGiveItem);
            this.groupBox1.Controls.Add(this.radGiveStat);
            this.groupBox1.Controls.Add(this.radGiveAbility);
            this.groupBox1.Location = new System.Drawing.Point(7, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.groupBox1.Size = new System.Drawing.Size(652, 186);
            this.groupBox1.TabIndex = 210;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Give Object:";
            // 
            // linkGive
            // 
            this.linkGive.AllowDrop = true;
            this.linkGive.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.linkGive.Location = new System.Drawing.Point(75, 62);
            this.linkGive.Name = "linkGive";
            this.linkGive.Padding = new System.Windows.Forms.Padding(20, 1, 0, 0);
            this.linkGive.Size = new System.Drawing.Size(145, 21);
            this.linkGive.SystemType = RealmEdit.EditorSystemType.None;
            this.linkGive.TabIndex = 210;
            // 
            // lblGive
            // 
            this.lblGive.AutoSize = true;
            this.lblGive.Location = new System.Drawing.Point(12, 62);
            this.lblGive.Name = "lblGive";
            this.lblGive.Size = new System.Drawing.Size(37, 13);
            this.lblGive.TabIndex = 209;
            this.lblGive.Text = "Ability:";
            // 
            // radGiveItem
            // 
            this.radGiveItem.AutoSize = true;
            this.radGiveItem.Location = new System.Drawing.Point(150, 32);
            this.radGiveItem.Name = "radGiveItem";
            this.radGiveItem.Size = new System.Drawing.Size(45, 17);
            this.radGiveItem.TabIndex = 208;
            this.radGiveItem.Text = "Item";
            this.radGiveItem.UseVisualStyleBackColor = true;
            this.radGiveItem.CheckedChanged += new System.EventHandler(this.radAbility_CheckedChanged);
            // 
            // radGiveStat
            // 
            this.radGiveStat.AutoSize = true;
            this.radGiveStat.Location = new System.Drawing.Point(73, 32);
            this.radGiveStat.Name = "radGiveStat";
            this.radGiveStat.Size = new System.Drawing.Size(62, 17);
            this.radGiveStat.TabIndex = 207;
            this.radGiveStat.Text = "Statistic";
            this.radGiveStat.UseVisualStyleBackColor = true;
            this.radGiveStat.CheckedChanged += new System.EventHandler(this.radAbility_CheckedChanged);
            // 
            // radGiveAbility
            // 
            this.radGiveAbility.AutoSize = true;
            this.radGiveAbility.Checked = true;
            this.radGiveAbility.Location = new System.Drawing.Point(15, 32);
            this.radGiveAbility.Name = "radGiveAbility";
            this.radGiveAbility.Size = new System.Drawing.Size(52, 17);
            this.radGiveAbility.TabIndex = 206;
            this.radGiveAbility.TabStop = true;
            this.radGiveAbility.Text = "Ability";
            this.radGiveAbility.UseVisualStyleBackColor = true;
            this.radGiveAbility.CheckedChanged += new System.EventHandler(this.radAbility_CheckedChanged);
            // 
            // radGiveRitual
            // 
            this.radGiveRitual.AutoSize = true;
            this.radGiveRitual.Location = new System.Drawing.Point(260, 32);
            this.radGiveRitual.Name = "radGiveRitual";
            this.radGiveRitual.Size = new System.Drawing.Size(52, 17);
            this.radGiveRitual.TabIndex = 211;
            this.radGiveRitual.Text = "Ritual";
            this.radGiveRitual.UseVisualStyleBackColor = true;
            // 
            // radGiveQuest
            // 
            this.radGiveQuest.AutoSize = true;
            this.radGiveQuest.Location = new System.Drawing.Point(201, 32);
            this.radGiveQuest.Name = "radGiveQuest";
            this.radGiveQuest.Size = new System.Drawing.Size(53, 17);
            this.radGiveQuest.TabIndex = 212;
            this.radGiveQuest.Text = "Quest";
            this.radGiveQuest.UseVisualStyleBackColor = true;
            // 
            // EffectGiveObjectControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "EffectGiveObjectControl";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(662, 197);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private AuraLinkLabel linkGive;
        private System.Windows.Forms.Label lblGive;
        private System.Windows.Forms.RadioButton radGiveItem;
        private System.Windows.Forms.RadioButton radGiveStat;
        private System.Windows.Forms.RadioButton radGiveAbility;
        private System.Windows.Forms.RadioButton radGiveQuest;
        private System.Windows.Forms.RadioButton radGiveRitual;
    }
}
