namespace RealmEdit
{
    partial class SlotControl
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
            this.label12 = new System.Windows.Forms.Label();
            this.numValue = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDisplayDescription = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDisplayName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSystemName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cboSlotType = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.numValue)).BeginInit();
            this.SuspendLayout();
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(28, 138);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(58, 13);
            this.label12.TabIndex = 211;
            this.label12.Text = "Slot Value:";
            // 
            // numValue
            // 
            this.numValue.Location = new System.Drawing.Point(106, 138);
            this.numValue.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.numValue.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numValue.Name = "numValue";
            this.numValue.Size = new System.Drawing.Size(129, 20);
            this.numValue.TabIndex = 210;
            this.numValue.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.label1.Location = new System.Drawing.Point(3, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 13);
            this.label1.TabIndex = 209;
            this.label1.Text = "Display Description";
            // 
            // txtDisplayDescription
            // 
            this.txtDisplayDescription.Location = new System.Drawing.Point(106, 58);
            this.txtDisplayDescription.Multiline = true;
            this.txtDisplayDescription.Name = "txtDisplayDescription";
            this.txtDisplayDescription.Size = new System.Drawing.Size(319, 66);
            this.txtDisplayDescription.TabIndex = 206;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.label2.Location = new System.Drawing.Point(3, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 208;
            this.label2.Text = "Display Name";
            // 
            // txtDisplayName
            // 
            this.txtDisplayName.Location = new System.Drawing.Point(106, 32);
            this.txtDisplayName.Name = "txtDisplayName";
            this.txtDisplayName.Size = new System.Drawing.Size(202, 20);
            this.txtDisplayName.TabIndex = 205;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 207;
            this.label3.Text = "System Name";
            // 
            // txtSystemName
            // 
            this.txtSystemName.Location = new System.Drawing.Point(106, 6);
            this.txtSystemName.Name = "txtSystemName";
            this.txtSystemName.Size = new System.Drawing.Size(202, 20);
            this.txtSystemName.TabIndex = 204;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(31, 167);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 13);
            this.label7.TabIndex = 213;
            this.label7.Text = "Slot Type:";
            // 
            // cboSlotType
            // 
            this.cboSlotType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSlotType.FormattingEnabled = true;
            this.cboSlotType.Location = new System.Drawing.Point(106, 164);
            this.cboSlotType.Name = "cboSlotType";
            this.cboSlotType.Size = new System.Drawing.Size(102, 21);
            this.cboSlotType.TabIndex = 212;
            // 
            // SlotControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cboSlotType);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.numValue);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDisplayDescription);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtDisplayName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtSystemName);
            this.Name = "SlotControl";
            this.Size = new System.Drawing.Size(497, 195);
            ((System.ComponentModel.ISupportInitialize)(this.numValue)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.NumericUpDown numValue;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDisplayDescription;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDisplayName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSystemName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cboSlotType;
    }
}
