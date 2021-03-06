﻿namespace RealmEdit
{
    partial class TreasureControl
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtSystemDescription = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSystemName = new System.Windows.Forms.TextBox();
            this.gridTables = new RealmEdit.AuraDataGridView();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gridTables)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.label1.Location = new System.Drawing.Point(3, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 13);
            this.label1.TabIndex = 199;
            this.label1.Text = "System Description";
            // 
            // txtSystemDescription
            // 
            this.txtSystemDescription.Location = new System.Drawing.Point(110, 28);
            this.txtSystemDescription.Multiline = true;
            this.txtSystemDescription.Name = "txtSystemDescription";
            this.txtSystemDescription.Size = new System.Drawing.Size(319, 66);
            this.txtSystemDescription.TabIndex = 197;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 198;
            this.label3.Text = "System Name";
            // 
            // txtSystemName
            // 
            this.txtSystemName.Location = new System.Drawing.Point(110, 3);
            this.txtSystemName.Name = "txtSystemName";
            this.txtSystemName.Size = new System.Drawing.Size(202, 20);
            this.txtSystemName.TabIndex = 196;
            // 
            // gridTables
            // 
            this.gridTables.AllowDrop = true;
            this.gridTables.AllowRowDeletion = true;
            this.gridTables.AllowUserToResizeRows = false;
            this.gridTables.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridTables.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridTables.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.gridTables.Location = new System.Drawing.Point(6, 125);
            this.gridTables.Name = "gridTables";
            this.gridTables.RowHeadersWidth = 20;
            this.gridTables.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridTables.Size = new System.Drawing.Size(633, 199);
            this.gridTables.TabIndex = 203;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 109);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 13);
            this.label5.TabIndex = 202;
            this.label5.Text = "Treasure Tables:";
            // 
            // TreasureControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridTables);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSystemDescription);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtSystemName);
            this.Name = "TreasureControl";
            this.Size = new System.Drawing.Size(651, 327);
            ((System.ComponentModel.ISupportInitialize)(this.gridTables)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSystemDescription;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSystemName;
        private AuraDataGridView gridTables;
        private System.Windows.Forms.Label label5;
    }
}
