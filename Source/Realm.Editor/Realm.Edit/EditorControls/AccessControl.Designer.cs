﻿namespace RealmEdit
{
    partial class AccessControl
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
            this.label3 = new System.Windows.Forms.Label();
            this.txtSystemName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.numValue = new System.Windows.Forms.NumericUpDown();
            this.txtSystemDescription = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numValue)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 181;
            this.label3.Text = "System Name";
            // 
            // txtSystemName
            // 
            this.txtSystemName.Location = new System.Drawing.Point(104, 3);
            this.txtSystemName.Name = "txtSystemName";
            this.txtSystemName.Size = new System.Drawing.Size(202, 20);
            this.txtSystemName.TabIndex = 180;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(49, 31);
            this.label5.Name = "label5";
            this.label5.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 195;
            this.label5.Text = "Bit Value";
            // 
            // numValue
            // 
            this.numValue.Location = new System.Drawing.Point(104, 29);
            this.numValue.Maximum = new decimal(new int[] {
            1410065408,
            2,
            0,
            0});
            this.numValue.Name = "numValue";
            this.numValue.Size = new System.Drawing.Size(98, 20);
            this.numValue.TabIndex = 194;
            this.numValue.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // txtSystemDescription
            // 
            this.txtSystemDescription.Location = new System.Drawing.Point(104, 55);
            this.txtSystemDescription.Multiline = true;
            this.txtSystemDescription.Name = "txtSystemDescription";
            this.txtSystemDescription.Size = new System.Drawing.Size(281, 101);
            this.txtSystemDescription.TabIndex = 196;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 13);
            this.label1.TabIndex = 197;
            this.label1.Text = "System Description";
            // 
            // AccessControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSystemDescription);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.numValue);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtSystemName);
            this.Name = "AccessControl";
            this.Size = new System.Drawing.Size(395, 236);
            ((System.ComponentModel.ISupportInitialize)(this.numValue)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSystemName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numValue;
        private System.Windows.Forms.TextBox txtSystemDescription;
        private System.Windows.Forms.Label label1;
    }
}
