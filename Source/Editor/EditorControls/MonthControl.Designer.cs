using Realm.Edit.CustomControls;

namespace Realm.Edit.EditorControls
{
    partial class MonthControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MonthControl));
            this.label2 = new System.Windows.Forms.Label();
            this.txtDisplayName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSystemName = new System.Windows.Forms.TextBox();
            this.cboSeasonTypes = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.numNumberDays = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.chkIsShrouding = new System.Windows.Forms.CheckBox();
            this.gridEffects = new Realm.Edit.CustomControls.AuraDataGridView();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numNumberDays)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridEffects)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.label2.Location = new System.Drawing.Point(163, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 182;
            this.label2.Text = "Display Name";
            // 
            // txtDisplayName
            // 
            this.txtDisplayName.Location = new System.Drawing.Point(166, 16);
            this.txtDisplayName.MaxLength = 250;
            this.txtDisplayName.Name = "txtDisplayName";
            this.txtDisplayName.Size = new System.Drawing.Size(280, 20);
            this.txtDisplayName.TabIndex = 179;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 181;
            this.label3.Text = "System Name";
            // 
            // txtSystemName
            // 
            this.txtSystemName.Location = new System.Drawing.Point(6, 16);
            this.txtSystemName.MaxLength = 50;
            this.txtSystemName.Name = "txtSystemName";
            this.txtSystemName.Size = new System.Drawing.Size(154, 20);
            this.txtSystemName.TabIndex = 178;
            // 
            // cboSeasonTypes
            // 
            this.cboSeasonTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSeasonTypes.FormattingEnabled = true;
            this.cboSeasonTypes.Location = new System.Drawing.Point(111, 70);
            this.cboSeasonTypes.Name = "cboSeasonTypes";
            this.cboSeasonTypes.Size = new System.Drawing.Size(124, 21);
            this.cboSeasonTypes.TabIndex = 255;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(15, 46);
            this.label11.Name = "label11";
            this.label11.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label11.Size = new System.Drawing.Size(86, 13);
            this.label11.TabIndex = 254;
            this.label11.Text = "Number of Days:";
            // 
            // numNumberDays
            // 
            this.numNumberDays.Location = new System.Drawing.Point(111, 44);
            this.numNumberDays.Maximum = new decimal(new int[] {
            1410065408,
            2,
            0,
            0});
            this.numNumberDays.Name = "numNumberDays";
            this.numNumberDays.Size = new System.Drawing.Size(98, 20);
            this.numNumberDays.TabIndex = 253;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(28, 73);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 13);
            this.label6.TabIndex = 252;
            this.label6.Text = "Season Type:";
            // 
            // chkIsShrouding
            // 
            this.chkIsShrouding.AutoSize = true;
            this.chkIsShrouding.Location = new System.Drawing.Point(41, 107);
            this.chkIsShrouding.Name = "chkIsShrouding";
            this.chkIsShrouding.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkIsShrouding.Size = new System.Drawing.Size(85, 17);
            this.chkIsShrouding.TabIndex = 256;
            this.chkIsShrouding.Text = "Is Shrouding";
            this.chkIsShrouding.UseVisualStyleBackColor = true;
            // 
            // gridEffects
            // 
            this.gridEffects.AllowDrop = true;
            this.gridEffects.AllowRowDeletion = true;
            this.gridEffects.AllowUserToResizeRows = false;
            this.gridEffects.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridEffects.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.gridEffects.Location = new System.Drawing.Point(6, 153);
            this.gridEffects.Name = "gridEffects";
            this.gridEffects.RowHeadersWidth = 20;
            this.gridEffects.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridEffects.Size = new System.Drawing.Size(229, 165);
            this.gridEffects.TabIndex = 257;
            //this.gridEffects.ValidateRow = ((Realm.Edit.CustomControls.ValidateRowDelegate)(resources.GetObject("gridEffects.ValidateRow")));
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 137);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 258;
            this.label1.Text = "Effects:";
            // 
            // MonthControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gridEffects);
            this.Controls.Add(this.chkIsShrouding);
            this.Controls.Add(this.cboSeasonTypes);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.numNumberDays);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtDisplayName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtSystemName);
            this.Name = "MonthControl";
            this.Size = new System.Drawing.Size(526, 346);
            ((System.ComponentModel.ISupportInitialize)(this.numNumberDays)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridEffects)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDisplayName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSystemName;
        private System.Windows.Forms.ComboBox cboSeasonTypes;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown numNumberDays;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox chkIsShrouding;
        private AuraDataGridView gridEffects;
        private System.Windows.Forms.Label label1;
    }
}
