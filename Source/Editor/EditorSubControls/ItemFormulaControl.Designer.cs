namespace RealmEdit
{
    partial class ItemFormulaControl
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
            this.linkTool = new RealmEdit.AuraLinkLabel();
            this.linkMachine = new RealmEdit.AuraLinkLabel();
            this.label7 = new System.Windows.Forms.Label();
            this.gridResources = new RealmEdit.AuraDataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.numXpValue = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.linkProduct = new RealmEdit.AuraLinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.linkSkill = new RealmEdit.AuraLinkLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.numProductQty = new System.Windows.Forms.NumericUpDown();
            this.numMinSkill = new System.Windows.Forms.NumericUpDown();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridResources)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numXpValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numProductQty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinSkill)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.linkTool);
            this.groupBox1.Controls.Add(this.linkMachine);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.gridResources);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.numXpValue);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.linkProduct);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.linkSkill);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.numProductQty);
            this.groupBox1.Controls.Add(this.numMinSkill);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(652, 220);
            this.groupBox1.TabIndex = 206;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Formula:";
            // 
            // linkTool
            // 
            this.linkTool.AllowDrop = true;
            this.linkTool.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.linkTool.Location = new System.Drawing.Point(56, 117);
            this.linkTool.Name = "linkTool";
            this.linkTool.Padding = new System.Windows.Forms.Padding(20, 1, 0, 0);
            this.linkTool.Size = new System.Drawing.Size(149, 21);
            this.linkTool.SystemType = RealmEdit.EditorSystemType.None;
            this.linkTool.TabIndex = 230;
            // 
            // linkMachine
            // 
            this.linkMachine.AllowDrop = true;
            this.linkMachine.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.linkMachine.Location = new System.Drawing.Point(56, 85);
            this.linkMachine.Name = "linkMachine";
            this.linkMachine.Padding = new System.Windows.Forms.Padding(20, 1, 0, 0);
            this.linkMachine.Size = new System.Drawing.Size(149, 21);
            this.linkMachine.SystemType = RealmEdit.EditorSystemType.None;
            this.linkMachine.TabIndex = 229;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(308, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(61, 13);
            this.label7.TabIndex = 228;
            this.label7.Text = "Resources:";
            // 
            // gridResources
            // 
            this.gridResources.AllowDrop = true;
            this.gridResources.AllowRowDeletion = true;
            this.gridResources.AllowUserToResizeRows = false;
            this.gridResources.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridResources.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.gridResources.Location = new System.Drawing.Point(311, 32);
            this.gridResources.Name = "gridResources";
            this.gridResources.RowHeadersWidth = 20;
            this.gridResources.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridResources.Size = new System.Drawing.Size(335, 134);
            this.gridResources.TabIndex = 227;
            this.gridResources.DefaultValuesNeeded += new System.Windows.Forms.DataGridViewRowEventHandler(this.gridResources_DefaultValuesNeeded);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(2, 148);
            this.label6.Name = "label6";
            this.label6.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label6.Size = new System.Drawing.Size(54, 13);
            this.label6.TabIndex = 226;
            this.label6.Text = "XP Value:";
            // 
            // numXpValue
            // 
            this.numXpValue.Location = new System.Drawing.Point(56, 146);
            this.numXpValue.Maximum = new decimal(new int[] {
            1410065408,
            2,
            0,
            0});
            this.numXpValue.Name = "numXpValue";
            this.numXpValue.Size = new System.Drawing.Size(88, 20);
            this.numXpValue.TabIndex = 225;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 223;
            this.label3.Text = "Tool:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(2, 85);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(51, 13);
            this.label14.TabIndex = 221;
            this.label14.Text = "Machine:";
            // 
            // linkProduct
            // 
            this.linkProduct.AllowDrop = true;
            this.linkProduct.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.linkProduct.Location = new System.Drawing.Point(56, 51);
            this.linkProduct.Name = "linkProduct";
            this.linkProduct.Padding = new System.Windows.Forms.Padding(20, 1, 0, 0);
            this.linkProduct.Size = new System.Drawing.Size(149, 21);
            this.linkProduct.SystemType = RealmEdit.EditorSystemType.None;
            this.linkProduct.TabIndex = 219;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 220;
            this.label1.Text = "Product:";
            // 
            // linkSkill
            // 
            this.linkSkill.AllowDrop = true;
            this.linkSkill.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.linkSkill.Location = new System.Drawing.Point(56, 21);
            this.linkSkill.Name = "linkSkill";
            this.linkSkill.Padding = new System.Windows.Forms.Padding(20, 1, 0, 0);
            this.linkSkill.Size = new System.Drawing.Size(149, 21);
            this.linkSkill.SystemType = RealmEdit.EditorSystemType.None;
            this.linkSkill.TabIndex = 217;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 218;
            this.label2.Text = "Skill:";
            // 
            // numProductQty
            // 
            this.numProductQty.Location = new System.Drawing.Point(211, 51);
            this.numProductQty.Maximum = new decimal(new int[] {
            1410065408,
            2,
            0,
            0});
            this.numProductQty.Name = "numProductQty";
            this.numProductQty.Size = new System.Drawing.Size(76, 20);
            this.numProductQty.TabIndex = 207;
            // 
            // numMinSkill
            // 
            this.numMinSkill.Location = new System.Drawing.Point(211, 22);
            this.numMinSkill.Maximum = new decimal(new int[] {
            1410065408,
            2,
            0,
            0});
            this.numMinSkill.Name = "numMinSkill";
            this.numMinSkill.Size = new System.Drawing.Size(76, 20);
            this.numMinSkill.TabIndex = 205;
            // 
            // ItemFormulaControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "ItemFormulaControl";
            this.Size = new System.Drawing.Size(661, 226);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridResources)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numXpValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numProductQty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinSkill)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown numProductQty;
        private System.Windows.Forms.NumericUpDown numMinSkill;
        private AuraLinkLabel linkProduct;
        private System.Windows.Forms.Label label1;
        private AuraLinkLabel linkSkill;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private AuraDataGridView gridResources;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numXpValue;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label14;
        private AuraLinkLabel linkTool;
        private AuraLinkLabel linkMachine;
    }
}
