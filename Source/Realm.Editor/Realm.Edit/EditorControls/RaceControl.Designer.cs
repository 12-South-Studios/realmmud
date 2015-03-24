using Realm.Edit.CustomControls;

namespace Realm.Edit.EditorControls
{
    partial class RaceControl
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
            this.txtDisplayDescription = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDisplayName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSystemName = new System.Windows.Forms.TextBox();
            this.chkPlayerRace = new System.Windows.Forms.CheckBox();
            this.cboSize = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabStatMods = new System.Windows.Forms.TabPage();
            this.gridStatMods = new Realm.Edit.CustomControls.AuraDataGridView();
            this.tabAbilities = new System.Windows.Forms.TabPage();
            this.gridAbilities = new Realm.Edit.CustomControls.AuraDataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.txtAbbreviation = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.tabStatMods.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridStatMods)).BeginInit();
            this.tabAbilities.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridAbilities)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.label1.Location = new System.Drawing.Point(3, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 13);
            this.label1.TabIndex = 183;
            this.label1.Text = "Display Description";
            // 
            // txtDisplayDescription
            // 
            this.txtDisplayDescription.Location = new System.Drawing.Point(6, 62);
            this.txtDisplayDescription.MaxLength = 8192;
            this.txtDisplayDescription.Multiline = true;
            this.txtDisplayDescription.Name = "txtDisplayDescription";
            this.txtDisplayDescription.Size = new System.Drawing.Size(349, 66);
            this.txtDisplayDescription.TabIndex = 180;
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
            // chkPlayerRace
            // 
            this.chkPlayerRace.AutoSize = true;
            this.chkPlayerRace.Location = new System.Drawing.Point(361, 102);
            this.chkPlayerRace.Name = "chkPlayerRace";
            this.chkPlayerRace.Size = new System.Drawing.Size(84, 17);
            this.chkPlayerRace.TabIndex = 184;
            this.chkPlayerRace.Text = "Player Race";
            this.chkPlayerRace.UseVisualStyleBackColor = true;
            // 
            // cboSize
            // 
            this.cboSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSize.FormattingEnabled = true;
            this.cboSize.Location = new System.Drawing.Point(361, 65);
            this.cboSize.Name = "cboSize";
            this.cboSize.Size = new System.Drawing.Size(124, 21);
            this.cboSize.TabIndex = 203;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(361, 49);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(30, 13);
            this.label14.TabIndex = 202;
            this.label14.Text = "Size:";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabStatMods);
            this.tabControl1.Controls.Add(this.tabAbilities);
            this.tabControl1.Location = new System.Drawing.Point(6, 134);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(515, 197);
            this.tabControl1.TabIndex = 208;
            // 
            // tabStatMods
            // 
            this.tabStatMods.Controls.Add(this.gridStatMods);
            this.tabStatMods.Location = new System.Drawing.Point(4, 22);
            this.tabStatMods.Name = "tabStatMods";
            this.tabStatMods.Padding = new System.Windows.Forms.Padding(3);
            this.tabStatMods.Size = new System.Drawing.Size(507, 171);
            this.tabStatMods.TabIndex = 0;
            this.tabStatMods.Text = "Statistic Mods";
            this.tabStatMods.UseVisualStyleBackColor = true;
            // 
            // gridStatMods
            // 
            this.gridStatMods.AllowDrop = true;
            this.gridStatMods.AllowRowDeletion = true;
            this.gridStatMods.AllowUserToResizeRows = false;
            this.gridStatMods.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridStatMods.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridStatMods.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.gridStatMods.Location = new System.Drawing.Point(3, 3);
            this.gridStatMods.Name = "gridStatMods";
            this.gridStatMods.RowHeadersWidth = 20;
            this.gridStatMods.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridStatMods.Size = new System.Drawing.Size(501, 165);
            this.gridStatMods.TabIndex = 195;
            // 
            // tabAbilities
            // 
            this.tabAbilities.Controls.Add(this.gridAbilities);
            this.tabAbilities.Location = new System.Drawing.Point(4, 22);
            this.tabAbilities.Name = "tabAbilities";
            this.tabAbilities.Padding = new System.Windows.Forms.Padding(3);
            this.tabAbilities.Size = new System.Drawing.Size(507, 171);
            this.tabAbilities.TabIndex = 1;
            this.tabAbilities.Text = "Abilities";
            this.tabAbilities.UseVisualStyleBackColor = true;
            // 
            // gridAbilities
            // 
            this.gridAbilities.AllowDrop = true;
            this.gridAbilities.AllowRowDeletion = true;
            this.gridAbilities.AllowUserToResizeRows = false;
            this.gridAbilities.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridAbilities.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridAbilities.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.gridAbilities.Location = new System.Drawing.Point(3, 3);
            this.gridAbilities.Name = "gridAbilities";
            this.gridAbilities.RowHeadersWidth = 20;
            this.gridAbilities.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridAbilities.Size = new System.Drawing.Size(501, 165);
            this.gridAbilities.TabIndex = 196;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(449, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 210;
            this.label4.Text = "Abbreviation";
            // 
            // txtAbbreviation
            // 
            this.txtAbbreviation.Location = new System.Drawing.Point(452, 16);
            this.txtAbbreviation.MaxLength = 50;
            this.txtAbbreviation.Name = "txtAbbreviation";
            this.txtAbbreviation.Size = new System.Drawing.Size(69, 20);
            this.txtAbbreviation.TabIndex = 209;
            // 
            // RaceControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtAbbreviation);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.cboSize);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.chkPlayerRace);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDisplayDescription);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtDisplayName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtSystemName);
            this.Name = "RaceControl";
            this.Size = new System.Drawing.Size(526, 346);
            this.tabControl1.ResumeLayout(false);
            this.tabStatMods.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridStatMods)).EndInit();
            this.tabAbilities.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridAbilities)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDisplayDescription;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDisplayName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSystemName;
        private System.Windows.Forms.CheckBox chkPlayerRace;
        private System.Windows.Forms.ComboBox cboSize;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabStatMods;
        private AuraDataGridView gridStatMods;
        private System.Windows.Forms.TabPage tabAbilities;
        private AuraDataGridView gridAbilities;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtAbbreviation;
    }
}
