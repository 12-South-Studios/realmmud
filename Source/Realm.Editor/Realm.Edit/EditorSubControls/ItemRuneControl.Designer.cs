namespace RealmEdit
{
    partial class ItemRuneControl
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
            this.label7 = new System.Windows.Forms.Label();
            this.gridSockets = new RealmEdit.AuraDataGridView();
            this.chkIsRemovable = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridSockets)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.chkIsRemovable);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.gridSockets);
            this.groupBox1.Location = new System.Drawing.Point(7, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(652, 186);
            this.groupBox1.TabIndex = 231;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Rune:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(24, 25);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 13);
            this.label7.TabIndex = 232;
            this.label7.Text = "Valid Sockets:";
            // 
            // gridSockets
            // 
            this.gridSockets.AllowDrop = true;
            this.gridSockets.AllowRowDeletion = true;
            this.gridSockets.AllowUserToResizeRows = false;
            this.gridSockets.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridSockets.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.gridSockets.Location = new System.Drawing.Point(27, 41);
            this.gridSockets.Name = "gridSockets";
            this.gridSockets.RowHeadersWidth = 20;
            this.gridSockets.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridSockets.Size = new System.Drawing.Size(262, 103);
            this.gridSockets.TabIndex = 231;
            // 
            // chkIsRemovable
            // 
            this.chkIsRemovable.AutoSize = true;
            this.chkIsRemovable.Location = new System.Drawing.Point(27, 150);
            this.chkIsRemovable.Name = "chkIsRemovable";
            this.chkIsRemovable.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkIsRemovable.Size = new System.Drawing.Size(91, 17);
            this.chkIsRemovable.TabIndex = 233;
            this.chkIsRemovable.Text = "Is Removable";
            this.chkIsRemovable.UseVisualStyleBackColor = true;
            // 
            // ItemRuneControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "ItemRuneControl";
            this.Size = new System.Drawing.Size(662, 197);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridSockets)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label7;
        private AuraDataGridView gridSockets;
        private System.Windows.Forms.CheckBox chkIsRemovable;
    }
}
