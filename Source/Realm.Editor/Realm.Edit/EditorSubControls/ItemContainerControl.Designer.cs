namespace RealmEdit
{
    partial class ItemContainerControl
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkIsCloseable = new System.Windows.Forms.CheckBox();
            this.linkLock = new RealmEdit.AuraLinkLabel();
            this.chkIsLockable = new System.Windows.Forms.CheckBox();
            this.chkIsLocked = new System.Windows.Forms.CheckBox();
            this.cboSize = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.numWeight = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.numVolume = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.gridItems = new RealmEdit.AuraDataGridView();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numWeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numVolume)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridItems)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.gridItems);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.cboSize);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.numWeight);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.numVolume);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(652, 273);
            this.groupBox1.TabIndex = 205;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Container:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkIsCloseable);
            this.groupBox2.Controls.Add(this.linkLock);
            this.groupBox2.Controls.Add(this.chkIsLockable);
            this.groupBox2.Controls.Add(this.chkIsLocked);
            this.groupBox2.Location = new System.Drawing.Point(307, 19);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 111);
            this.groupBox2.TabIndex = 225;
            this.groupBox2.TabStop = false;
            // 
            // chkIsCloseable
            // 
            this.chkIsCloseable.AutoSize = true;
            this.chkIsCloseable.Location = new System.Drawing.Point(16, 19);
            this.chkIsCloseable.Name = "chkIsCloseable";
            this.chkIsCloseable.Size = new System.Drawing.Size(83, 17);
            this.chkIsCloseable.TabIndex = 211;
            this.chkIsCloseable.Text = "Is Closeable";
            this.chkIsCloseable.UseVisualStyleBackColor = true;
            // 
            // linkLock
            // 
            this.linkLock.AllowDrop = true;
            this.linkLock.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.linkLock.Location = new System.Drawing.Point(36, 85);
            this.linkLock.Name = "linkLock";
            this.linkLock.Padding = new System.Windows.Forms.Padding(20, 1, 0, 0);
            this.linkLock.Size = new System.Drawing.Size(122, 21);
            this.linkLock.SystemType = RealmEdit.EditorSystemType.None;
            this.linkLock.TabIndex = 223;
            // 
            // chkIsLockable
            // 
            this.chkIsLockable.AutoSize = true;
            this.chkIsLockable.Location = new System.Drawing.Point(16, 42);
            this.chkIsLockable.Name = "chkIsLockable";
            this.chkIsLockable.Size = new System.Drawing.Size(81, 17);
            this.chkIsLockable.TabIndex = 212;
            this.chkIsLockable.Text = "Is Lockable";
            this.chkIsLockable.UseVisualStyleBackColor = true;
            this.chkIsLockable.CheckedChanged += new System.EventHandler(this.chkIsLockable_CheckedChanged);
            // 
            // chkIsLocked
            // 
            this.chkIsLocked.AutoSize = true;
            this.chkIsLocked.Location = new System.Drawing.Point(16, 65);
            this.chkIsLocked.Name = "chkIsLocked";
            this.chkIsLocked.Size = new System.Drawing.Size(73, 17);
            this.chkIsLocked.TabIndex = 213;
            this.chkIsLocked.Text = "Is Locked";
            this.chkIsLocked.UseVisualStyleBackColor = true;
            // 
            // cboSize
            // 
            this.cboSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSize.FormattingEnabled = true;
            this.cboSize.Location = new System.Drawing.Point(161, 83);
            this.cboSize.Name = "cboSize";
            this.cboSize.Size = new System.Drawing.Size(124, 21);
            this.cboSize.TabIndex = 210;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(84, 86);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(63, 13);
            this.label14.TabIndex = 209;
            this.label14.Text = "Mouth Size:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 57);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label4.Size = new System.Drawing.Size(141, 13);
            this.label4.TabIndex = 208;
            this.label4.Text = "Weight Allowance (Pounds):";
            // 
            // numWeight
            // 
            this.numWeight.Location = new System.Drawing.Point(161, 57);
            this.numWeight.Maximum = new decimal(new int[] {
            1410065408,
            2,
            0,
            0});
            this.numWeight.Name = "numWeight";
            this.numWeight.Size = new System.Drawing.Size(98, 20);
            this.numWeight.TabIndex = 207;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 31);
            this.label5.Name = "label5";
            this.label5.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label5.Size = new System.Drawing.Size(142, 13);
            this.label5.TabIndex = 206;
            this.label5.Text = "Volume Allowance (Pounds):";
            // 
            // numVolume
            // 
            this.numVolume.Location = new System.Drawing.Point(161, 29);
            this.numVolume.Maximum = new decimal(new int[] {
            1410065408,
            2,
            0,
            0});
            this.numVolume.Name = "numVolume";
            this.numVolume.Size = new System.Drawing.Size(98, 20);
            this.numVolume.TabIndex = 205;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 107);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 13);
            this.label7.TabIndex = 230;
            this.label7.Text = "Contains:";
            // 
            // gridItems
            // 
            this.gridItems.AllowDrop = true;
            this.gridItems.AllowRowDeletion = true;
            this.gridItems.AllowUserToResizeRows = false;
            this.gridItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridItems.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.gridItems.Location = new System.Drawing.Point(9, 123);
            this.gridItems.Name = "gridItems";
            this.gridItems.RowHeadersWidth = 20;
            this.gridItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridItems.Size = new System.Drawing.Size(276, 134);
            this.gridItems.TabIndex = 229;
            this.gridItems.DefaultValuesNeeded += new System.Windows.Forms.DataGridViewRowEventHandler(this.gridItems_DefaultValuesNeeded);
            // 
            // ItemContainerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "ItemContainerControl";
            this.Size = new System.Drawing.Size(661, 281);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numWeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numVolume)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridItems)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkIsCloseable;
        private System.Windows.Forms.ComboBox cboSize;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numWeight;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numVolume;
        private System.Windows.Forms.CheckBox chkIsLocked;
        private System.Windows.Forms.CheckBox chkIsLockable;
        private AuraLinkLabel linkLock;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label7;
        private AuraDataGridView gridItems;

    }
}
