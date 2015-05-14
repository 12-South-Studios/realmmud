namespace Realm.Edit
{
    partial class ClassListWindow
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.trvClasses = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // trvClasses
            // 
            this.trvClasses.Location = new System.Drawing.Point(1, 3);
            this.trvClasses.Name = "trvClasses";
            this.trvClasses.Size = new System.Drawing.Size(285, 441);
            this.trvClasses.TabIndex = 0;
            this.trvClasses.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.TrvClassesNodeMouseDoubleClick);
            // 
            // ClassListWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 443);
            this.ControlBox = false;
            this.Controls.Add(this.trvClasses);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ClassListWindow";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ClassListWindow";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView trvClasses;
    }
}