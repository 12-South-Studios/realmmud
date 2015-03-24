namespace RealmEdit
{
    partial class EffectControl
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
            this.chkIsFriendly = new System.Windows.Forms.CheckBox();
            this.numDuration = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDisplayDescription = new System.Windows.Forms.TextBox();
            this.radInstant = new System.Windows.Forms.RadioButton();
            this.radDuration = new System.Windows.Forms.RadioButton();
            this.panelEffectType = new System.Windows.Forms.Panel();
            this.cboEffectType = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numDuration)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.label2.Location = new System.Drawing.Point(3, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 186;
            this.label2.Text = "Display Name";
            // 
            // txtDisplayName
            // 
            this.txtDisplayName.Location = new System.Drawing.Point(106, 29);
            this.txtDisplayName.Name = "txtDisplayName";
            this.txtDisplayName.Size = new System.Drawing.Size(202, 20);
            this.txtDisplayName.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 185;
            this.label3.Text = "System Name";
            // 
            // txtSystemName
            // 
            this.txtSystemName.Location = new System.Drawing.Point(106, 3);
            this.txtSystemName.Name = "txtSystemName";
            this.txtSystemName.Size = new System.Drawing.Size(202, 20);
            this.txtSystemName.TabIndex = 0;
            // 
            // chkIsFriendly
            // 
            this.chkIsFriendly.AutoSize = true;
            this.chkIsFriendly.Location = new System.Drawing.Point(47, 124);
            this.chkIsFriendly.Name = "chkIsFriendly";
            this.chkIsFriendly.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkIsFriendly.Size = new System.Drawing.Size(73, 17);
            this.chkIsFriendly.TabIndex = 3;
            this.chkIsFriendly.Text = "Is Friendly";
            this.chkIsFriendly.UseVisualStyleBackColor = true;
            // 
            // numDuration
            // 
            this.numDuration.Location = new System.Drawing.Point(308, 124);
            this.numDuration.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numDuration.Name = "numDuration";
            this.numDuration.Size = new System.Drawing.Size(56, 20);
            this.numDuration.TabIndex = 6;
            this.numDuration.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.label1.Location = new System.Drawing.Point(3, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 13);
            this.label1.TabIndex = 195;
            this.label1.Text = "Display Description";
            // 
            // txtDisplayDescription
            // 
            this.txtDisplayDescription.Location = new System.Drawing.Point(106, 52);
            this.txtDisplayDescription.Multiline = true;
            this.txtDisplayDescription.Name = "txtDisplayDescription";
            this.txtDisplayDescription.Size = new System.Drawing.Size(319, 66);
            this.txtDisplayDescription.TabIndex = 2;
            // 
            // radInstant
            // 
            this.radInstant.AutoSize = true;
            this.radInstant.Location = new System.Drawing.Point(156, 124);
            this.radInstant.Name = "radInstant";
            this.radInstant.Size = new System.Drawing.Size(57, 17);
            this.radInstant.TabIndex = 4;
            this.radInstant.Text = "Instant";
            this.radInstant.UseVisualStyleBackColor = true;
            this.radInstant.CheckedChanged += new System.EventHandler(this.radDuration_CheckedChanged);
            // 
            // radDuration
            // 
            this.radDuration.AutoSize = true;
            this.radDuration.Location = new System.Drawing.Point(237, 123);
            this.radDuration.Name = "radDuration";
            this.radDuration.Size = new System.Drawing.Size(65, 17);
            this.radDuration.TabIndex = 5;
            this.radDuration.Text = "Duration";
            this.radDuration.UseVisualStyleBackColor = true;
            this.radDuration.CheckedChanged += new System.EventHandler(this.radDuration_CheckedChanged);
            // 
            // panelEffectType
            // 
            this.panelEffectType.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panelEffectType.Location = new System.Drawing.Point(6, 184);
            this.panelEffectType.Name = "panelEffectType";
            this.panelEffectType.Size = new System.Drawing.Size(677, 264);
            this.panelEffectType.TabIndex = 218;
            // 
            // cboEffectType
            // 
            this.cboEffectType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEffectType.FormattingEnabled = true;
            this.cboEffectType.Location = new System.Drawing.Point(106, 157);
            this.cboEffectType.Name = "cboEffectType";
            this.cboEffectType.Size = new System.Drawing.Size(124, 21);
            this.cboEffectType.TabIndex = 219;
            this.cboEffectType.SelectedIndexChanged += new System.EventHandler(this.onEffectTypeChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(35, 160);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 13);
            this.label8.TabIndex = 220;
            this.label8.Text = "Effect Type:";
            // 
            // EffectControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cboEffectType);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.panelEffectType);
            this.Controls.Add(this.radDuration);
            this.Controls.Add(this.radInstant);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDisplayDescription);
            this.Controls.Add(this.numDuration);
            this.Controls.Add(this.chkIsFriendly);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtDisplayName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtSystemName);
            this.Name = "EffectControl";
            this.Size = new System.Drawing.Size(685, 467);
            ((System.ComponentModel.ISupportInitialize)(this.numDuration)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDisplayName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSystemName;
        private System.Windows.Forms.CheckBox chkIsFriendly;
        private System.Windows.Forms.NumericUpDown numDuration;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDisplayDescription;
        private System.Windows.Forms.RadioButton radInstant;
        private System.Windows.Forms.RadioButton radDuration;
        private System.Windows.Forms.Panel panelEffectType;
        private System.Windows.Forms.ComboBox cboEffectType;
        private System.Windows.Forms.Label label8;
    }
}
