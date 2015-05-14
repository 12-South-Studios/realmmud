namespace RealmEdit
{
    partial class ItemPortalControl
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
            this.linkDestination = new RealmEdit.AuraLinkLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.chkOnUse = new System.Windows.Forms.CheckBox();
            this.chkOnEnter = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.chkOnEnter);
            this.groupBox1.Controls.Add(this.chkOnUse);
            this.groupBox1.Controls.Add(this.linkDestination);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(652, 186);
            this.groupBox1.TabIndex = 207;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Portal:";
            // 
            // linkDestination
            // 
            this.linkDestination.AllowDrop = true;
            this.linkDestination.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.linkDestination.Location = new System.Drawing.Point(119, 31);
            this.linkDestination.Name = "linkDestination";
            this.linkDestination.Padding = new System.Windows.Forms.Padding(20, 1, 0, 0);
            this.linkDestination.Size = new System.Drawing.Size(149, 21);
            this.linkDestination.SystemType = RealmEdit.EditorSystemType.Space;
            this.linkDestination.TabIndex = 215;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 13);
            this.label2.TabIndex = 216;
            this.label2.Text = "Space Destination:";
            // 
            // chkOnUse
            // 
            this.chkOnUse.AutoSize = true;
            this.chkOnUse.Location = new System.Drawing.Point(71, 66);
            this.chkOnUse.Name = "chkOnUse";
            this.chkOnUse.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkOnUse.Size = new System.Drawing.Size(62, 17);
            this.chkOnUse.TabIndex = 223;
            this.chkOnUse.Text = "On Use";
            this.chkOnUse.UseVisualStyleBackColor = true;
            this.chkOnUse.CheckedChanged += new System.EventHandler(this.chkOnUse_CheckedChanged);
            // 
            // chkOnEnter
            // 
            this.chkOnEnter.AutoSize = true;
            this.chkOnEnter.Location = new System.Drawing.Point(65, 89);
            this.chkOnEnter.Name = "chkOnEnter";
            this.chkOnEnter.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkOnEnter.Size = new System.Drawing.Size(68, 17);
            this.chkOnEnter.TabIndex = 224;
            this.chkOnEnter.Text = "On Enter";
            this.chkOnEnter.UseVisualStyleBackColor = true;
            this.chkOnEnter.CheckedChanged += new System.EventHandler(this.chkOnEnter_CheckedChanged);
            // 
            // ItemPortalControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "ItemPortalControl";
            this.Size = new System.Drawing.Size(662, 199);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private AuraLinkLabel linkDestination;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkOnEnter;
        private System.Windows.Forms.CheckBox chkOnUse;
    }
}
