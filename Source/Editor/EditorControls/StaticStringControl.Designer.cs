namespace RealmEdit
{
    partial class StaticStringControl
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
            this.txtStringText = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.numCodeValue = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numCodeValue)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 183;
            this.label3.Text = "System Name";
            // 
            // txtSystemName
            // 
            this.txtSystemName.Location = new System.Drawing.Point(106, 8);
            this.txtSystemName.Name = "txtSystemName";
            this.txtSystemName.Size = new System.Drawing.Size(202, 20);
            this.txtSystemName.TabIndex = 1;
            // 
            // txtStringText
            // 
            this.txtStringText.AcceptsTab = true;
            this.txtStringText.Location = new System.Drawing.Point(106, 33);
            this.txtStringText.Multiline = true;
            this.txtStringText.Name = "txtStringText";
            this.txtStringText.Size = new System.Drawing.Size(319, 66);
            this.txtStringText.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 107);
            this.label5.Name = "label5";
            this.label5.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label5.Size = new System.Drawing.Size(80, 13);
            this.label5.TabIndex = 185;
            this.label5.Text = "Code (Optional)";
            // 
            // numCodeValue
            // 
            this.numCodeValue.Location = new System.Drawing.Point(106, 105);
            this.numCodeValue.Maximum = new decimal(new int[] {
            1410065408,
            2,
            0,
            0});
            this.numCodeValue.Name = "numCodeValue";
            this.numCodeValue.Size = new System.Drawing.Size(98, 20);
            this.numCodeValue.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 186;
            this.label1.Text = "String Text";
            // 
            // StaticStringControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtStringText);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.numCodeValue);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtSystemName);
            this.Name = "StaticStringControl";
            this.Size = new System.Drawing.Size(437, 139);
            ((System.ComponentModel.ISupportInitialize)(this.numCodeValue)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSystemName;
        private System.Windows.Forms.TextBox txtStringText;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numCodeValue;
        private System.Windows.Forms.Label label1;
    }
}
