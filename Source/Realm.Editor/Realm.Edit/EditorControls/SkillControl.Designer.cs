namespace Realm.Edit.EditorControls
{
    partial class SkillControl
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
            this.label2 = new System.Windows.Forms.Label();
            this.txtDisplayName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSystemName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.numMaxValue = new System.Windows.Forms.NumericUpDown();
            this.chkIsMasterable = new System.Windows.Forms.CheckBox();
            this.cboStatistic = new System.Windows.Forms.ComboBox();
            this.linkSkillCategory = new Realm.Edit.CustomControls.AuraLinkLabel();
            this.linkParentSkill = new Realm.Edit.CustomControls.AuraLinkLabel();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxValue)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.label2.Location = new System.Drawing.Point(3, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 198;
            this.label2.Text = "Display Name";
            // 
            // txtDisplayName
            // 
            this.txtDisplayName.Location = new System.Drawing.Point(106, 33);
            this.txtDisplayName.Name = "txtDisplayName";
            this.txtDisplayName.Size = new System.Drawing.Size(202, 20);
            this.txtDisplayName.TabIndex = 196;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 197;
            this.label3.Text = "System Name";
            // 
            // txtSystemName
            // 
            this.txtSystemName.Location = new System.Drawing.Point(106, 7);
            this.txtSystemName.Name = "txtSystemName";
            this.txtSystemName.Size = new System.Drawing.Size(202, 20);
            this.txtSystemName.TabIndex = 195;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.label1.Location = new System.Drawing.Point(3, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 13);
            this.label1.TabIndex = 200;
            this.label1.Text = "Display Description";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(106, 59);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(299, 73);
            this.txtDescription.TabIndex = 199;
            // 
            // numMaxValue
            // 
            this.numMaxValue.Location = new System.Drawing.Point(106, 138);
            this.numMaxValue.Name = "numMaxValue";
            this.numMaxValue.Size = new System.Drawing.Size(61, 20);
            this.numMaxValue.TabIndex = 201;
            // 
            // chkIsMasterable
            // 
            this.chkIsMasterable.AutoSize = true;
            this.chkIsMasterable.Location = new System.Drawing.Point(106, 164);
            this.chkIsMasterable.Name = "chkIsMasterable";
            this.chkIsMasterable.Size = new System.Drawing.Size(89, 17);
            this.chkIsMasterable.TabIndex = 202;
            this.chkIsMasterable.Text = "Is Masterable";
            this.chkIsMasterable.UseVisualStyleBackColor = true;
            // 
            // cboStatistic
            // 
            this.cboStatistic.FormattingEnabled = true;
            this.cboStatistic.Location = new System.Drawing.Point(106, 187);
            this.cboStatistic.Name = "cboStatistic";
            this.cboStatistic.Size = new System.Drawing.Size(121, 21);
            this.cboStatistic.TabIndex = 203;
            // 
            // linkSkillCategory
            // 
            this.linkSkillCategory.AllowDrop = true;
            this.linkSkillCategory.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.linkSkillCategory.Enabled = false;
            this.linkSkillCategory.Location = new System.Drawing.Point(106, 211);
            this.linkSkillCategory.Name = "linkSkillCategory";
            this.linkSkillCategory.Padding = new System.Windows.Forms.Padding(20, 1, 0, 0);
            this.linkSkillCategory.Size = new System.Drawing.Size(124, 21);
            this.linkSkillCategory.SystemType = Realm.Edit.Data.DataSystemType.SkillCategory;
            this.linkSkillCategory.TabIndex = 246;
            // 
            // linkParentSkill
            // 
            this.linkParentSkill.AllowDrop = true;
            this.linkParentSkill.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.linkParentSkill.Enabled = false;
            this.linkParentSkill.Location = new System.Drawing.Point(106, 232);
            this.linkParentSkill.Name = "linkParentSkill";
            this.linkParentSkill.Padding = new System.Windows.Forms.Padding(20, 1, 0, 0);
            this.linkParentSkill.Size = new System.Drawing.Size(124, 21);
            this.linkParentSkill.SystemType = Realm.Edit.Data.DataSystemType.Skill;
            this.linkParentSkill.TabIndex = 247;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 140);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 248;
            this.label4.Text = "Max Value";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 190);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 249;
            this.label5.Text = "Statistic";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 212);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 13);
            this.label6.TabIndex = 250;
            this.label6.Text = "Skill Category";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 233);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 13);
            this.label7.TabIndex = 251;
            this.label7.Text = "Parent Skill";
            // 
            // SkillControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.linkParentSkill);
            this.Controls.Add(this.linkSkillCategory);
            this.Controls.Add(this.cboStatistic);
            this.Controls.Add(this.chkIsMasterable);
            this.Controls.Add(this.numMaxValue);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtDisplayName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtSystemName);
            this.Name = "SkillControl";
            this.Size = new System.Drawing.Size(430, 277);
            ((System.ComponentModel.ISupportInitialize)(this.numMaxValue)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDisplayName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSystemName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.NumericUpDown numMaxValue;
        private System.Windows.Forms.CheckBox chkIsMasterable;
        private System.Windows.Forms.ComboBox cboStatistic;
        private CustomControls.AuraLinkLabel linkSkillCategory;
        private CustomControls.AuraLinkLabel linkParentSkill;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
    }
}
