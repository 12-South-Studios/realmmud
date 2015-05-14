namespace RealmEdit
{
    partial class SpaceEffectControl
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
            this.lstMovementTypes = new System.Windows.Forms.CheckedListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.groupEffect = new System.Windows.Forms.GroupBox();
            this.linkEffect = new RealmEdit.AuraLinkLabel();
            this.chkOnTurn = new System.Windows.Forms.CheckBox();
            this.chkOnEnter = new System.Windows.Forms.CheckBox();
            this.numSummoningQty = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.txtDisplayName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.numDuration = new System.Windows.Forms.NumericUpDown();
            this.rdoDuration = new System.Windows.Forms.RadioButton();
            this.rdoDurationInstant = new System.Windows.Forms.RadioButton();
            this.txtSystemName = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.linkSummoningNpc = new RealmEdit.AuraLinkLabel();
            this.groupEffect.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSummoningQty)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDuration)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstMovementTypes
            // 
            this.lstMovementTypes.FormattingEnabled = true;
            this.lstMovementTypes.Location = new System.Drawing.Point(10, 83);
            this.lstMovementTypes.Name = "lstMovementTypes";
            this.lstMovementTypes.Size = new System.Drawing.Size(199, 64);
            this.lstMovementTypes.TabIndex = 73;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 75;
            this.label2.Text = "System Name:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(185, 19);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(49, 13);
            this.label12.TabIndex = 62;
            this.label12.Text = "Quantity:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 67);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(92, 13);
            this.label8.TabIndex = 72;
            this.label8.Text = "Movement Types:";
            // 
            // groupEffect
            // 
            this.groupEffect.Controls.Add(this.linkEffect);
            this.groupEffect.Controls.Add(this.lstMovementTypes);
            this.groupEffect.Controls.Add(this.label8);
            this.groupEffect.Controls.Add(this.chkOnTurn);
            this.groupEffect.Controls.Add(this.chkOnEnter);
            this.groupEffect.Location = new System.Drawing.Point(262, 54);
            this.groupEffect.Name = "groupEffect";
            this.groupEffect.Size = new System.Drawing.Size(219, 160);
            this.groupEffect.TabIndex = 81;
            this.groupEffect.TabStop = false;
            this.groupEffect.Text = "Apply Effect";
            // 
            // linkEffect
            // 
            this.linkEffect.AllowDrop = true;
            this.linkEffect.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.linkEffect.Location = new System.Drawing.Point(6, 17);
            this.linkEffect.Name = "linkEffect";
            this.linkEffect.Padding = new System.Windows.Forms.Padding(20, 1, 0, 0);
            this.linkEffect.Size = new System.Drawing.Size(203, 21);
            this.linkEffect.SystemType = RealmEdit.EditorSystemType.None;
            this.linkEffect.TabIndex = 203;
            // 
            // chkOnTurn
            // 
            this.chkOnTurn.AutoSize = true;
            this.chkOnTurn.Location = new System.Drawing.Point(114, 43);
            this.chkOnTurn.Name = "chkOnTurn";
            this.chkOnTurn.Size = new System.Drawing.Size(95, 17);
            this.chkOnTurn.TabIndex = 71;
            this.chkOnTurn.Text = "On Turn Begin";
            this.chkOnTurn.UseVisualStyleBackColor = true;
            this.chkOnTurn.CheckedChanged += new System.EventHandler(this.chkOnTurn_CheckedChanged);
            // 
            // chkOnEnter
            // 
            this.chkOnEnter.AutoSize = true;
            this.chkOnEnter.Location = new System.Drawing.Point(10, 43);
            this.chkOnEnter.Name = "chkOnEnter";
            this.chkOnEnter.Size = new System.Drawing.Size(90, 17);
            this.chkOnEnter.TabIndex = 70;
            this.chkOnEnter.Text = "On Unit Enter";
            this.chkOnEnter.UseVisualStyleBackColor = true;
            this.chkOnEnter.CheckedChanged += new System.EventHandler(this.chkOnEnter_CheckedChanged);
            // 
            // numSummoningQty
            // 
            this.numSummoningQty.Location = new System.Drawing.Point(188, 35);
            this.numSummoningQty.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numSummoningQty.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numSummoningQty.Name = "numSummoningQty";
            this.numSummoningQty.Size = new System.Drawing.Size(54, 20);
            this.numSummoningQty.TabIndex = 61;
            this.numSummoningQty.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(5, 18);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(30, 13);
            this.label11.TabIndex = 60;
            this.label11.Text = "Npc:";
            // 
            // txtDisplayName
            // 
            this.txtDisplayName.Location = new System.Drawing.Point(262, 16);
            this.txtDisplayName.Name = "txtDisplayName";
            this.txtDisplayName.Size = new System.Drawing.Size(382, 20);
            this.txtDisplayName.TabIndex = 85;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(258, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 13);
            this.label4.TabIndex = 84;
            this.label4.Text = "Display Name:";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.numDuration);
            this.groupBox4.Controls.Add(this.rdoDuration);
            this.groupBox4.Controls.Add(this.rdoDurationInstant);
            this.groupBox4.Location = new System.Drawing.Point(4, 54);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(252, 84);
            this.groupBox4.TabIndex = 80;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Duration";
            // 
            // numDuration
            // 
            this.numDuration.Location = new System.Drawing.Point(85, 44);
            this.numDuration.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numDuration.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numDuration.Name = "numDuration";
            this.numDuration.Size = new System.Drawing.Size(53, 20);
            this.numDuration.TabIndex = 64;
            this.numDuration.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // rdoDuration
            // 
            this.rdoDuration.AutoSize = true;
            this.rdoDuration.Location = new System.Drawing.Point(12, 48);
            this.rdoDuration.Name = "rdoDuration";
            this.rdoDuration.Size = new System.Drawing.Size(67, 17);
            this.rdoDuration.TabIndex = 2;
            this.rdoDuration.TabStop = true;
            this.rdoDuration.Text = "Seconds";
            this.rdoDuration.UseVisualStyleBackColor = true;
            this.rdoDuration.CheckedChanged += new System.EventHandler(this.rdoDuration_CheckedChanged);
            // 
            // rdoDurationInstant
            // 
            this.rdoDurationInstant.AutoSize = true;
            this.rdoDurationInstant.Location = new System.Drawing.Point(12, 21);
            this.rdoDurationInstant.Name = "rdoDurationInstant";
            this.rdoDurationInstant.Size = new System.Drawing.Size(57, 17);
            this.rdoDurationInstant.TabIndex = 1;
            this.rdoDurationInstant.TabStop = true;
            this.rdoDurationInstant.Text = "Instant";
            this.rdoDurationInstant.UseVisualStyleBackColor = true;
            this.rdoDurationInstant.CheckedChanged += new System.EventHandler(this.rdoDuration_CheckedChanged);
            // 
            // txtSystemName
            // 
            this.txtSystemName.Location = new System.Drawing.Point(4, 16);
            this.txtSystemName.Name = "txtSystemName";
            this.txtSystemName.Size = new System.Drawing.Size(252, 20);
            this.txtSystemName.TabIndex = 76;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.linkSummoningNpc);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.numSummoningQty);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Location = new System.Drawing.Point(6, 144);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(252, 70);
            this.groupBox1.TabIndex = 79;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Summoning";
            // 
            // linkSummoningNpc
            // 
            this.linkSummoningNpc.AllowDrop = true;
            this.linkSummoningNpc.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.linkSummoningNpc.Location = new System.Drawing.Point(10, 34);
            this.linkSummoningNpc.Name = "linkSummoningNpc";
            this.linkSummoningNpc.Padding = new System.Windows.Forms.Padding(20, 1, 0, 0);
            this.linkSummoningNpc.Size = new System.Drawing.Size(154, 21);
            this.linkSummoningNpc.SystemType = RealmEdit.EditorSystemType.None;
            this.linkSummoningNpc.TabIndex = 203;
            // 
            // SpaceEffectControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupEffect);
            this.Controls.Add(this.txtDisplayName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.txtSystemName);
            this.Controls.Add(this.groupBox1);
            this.Name = "SpaceEffectControl";
            this.Size = new System.Drawing.Size(658, 287);
            this.groupEffect.ResumeLayout(false);
            this.groupEffect.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSummoningQty)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDuration)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox lstMovementTypes;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupEffect;
        private System.Windows.Forms.CheckBox chkOnTurn;
        private System.Windows.Forms.CheckBox chkOnEnter;
        private System.Windows.Forms.NumericUpDown numSummoningQty;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtDisplayName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.NumericUpDown numDuration;
        private System.Windows.Forms.RadioButton rdoDuration;
        private System.Windows.Forms.RadioButton rdoDurationInstant;
        private System.Windows.Forms.TextBox txtSystemName;
        private System.Windows.Forms.GroupBox groupBox1;
        private AuraLinkLabel linkEffect;
        private AuraLinkLabel linkSummoningNpc;
    }
}
