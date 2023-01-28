using System;

namespace PKM.XRMToolBox.TeamSecurityManager.UserControls
{
    partial class MultiSelectControl
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
                ((IDisposable)assignedSorter).Dispose();
                ((IDisposable)availableSorter).Dispose();
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
            this.components = new System.ComponentModel.Container();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.gbAssigned = new System.Windows.Forms.GroupBox();
            this.listViewAssigned = new System.Windows.Forms.ListView();
            this.DisplayNameASG = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.BUASG = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.gbAvailable = new System.Windows.Forms.GroupBox();
            this.listViewAvailable = new System.Windows.Forms.ListView();
            this.DisplayNameABL = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.BUABL = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnUnAssign = new System.Windows.Forms.Button();
            this.btnAssign = new System.Windows.Forms.Button();
            this.tooltipUnAssign = new System.Windows.Forms.ToolTip(this.components);
            this.tooltipAssign = new System.Windows.Forms.ToolTip(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.gbAssigned.SuspendLayout();
            this.gbAvailable.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 51F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.gbAssigned, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.gbAvailable, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 201F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(691, 201);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // gbAssigned
            // 
            this.gbAssigned.AutoSize = true;
            this.gbAssigned.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.gbAssigned.Controls.Add(this.listViewAssigned);
            this.gbAssigned.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbAssigned.Location = new System.Drawing.Point(3, 2);
            this.gbAssigned.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbAssigned.Name = "gbAssigned";
            this.gbAssigned.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbAssigned.Size = new System.Drawing.Size(314, 197);
            this.gbAssigned.TabIndex = 1;
            this.gbAssigned.TabStop = false;
            this.gbAssigned.Text = "Assigned: 0";
            // 
            // listViewAssigned
            // 
            this.listViewAssigned.AutoArrange = false;
            this.listViewAssigned.CheckBoxes = true;
            this.listViewAssigned.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.DisplayNameASG,
            this.BUASG});
            this.listViewAssigned.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewAssigned.FullRowSelect = true;
            this.listViewAssigned.Location = new System.Drawing.Point(3, 17);
            this.listViewAssigned.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listViewAssigned.Name = "listViewAssigned";
            this.listViewAssigned.Size = new System.Drawing.Size(308, 178);
            this.listViewAssigned.TabIndex = 0;
            this.listViewAssigned.UseCompatibleStateImageBehavior = false;
            this.listViewAssigned.View = System.Windows.Forms.View.Details;
            this.listViewAssigned.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listViewAssigned_ColumnClick);
            // 
            // DisplayNameASG
            // 
            this.DisplayNameASG.Text = "Name";
            this.DisplayNameASG.Width = 250;
            // 
            // BUASG
            // 
            this.BUASG.Text = "Business Unit";
            this.BUASG.Width = 100;
            // 
            // gbAvailable
            // 
            this.gbAvailable.AutoSize = true;
            this.gbAvailable.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.gbAvailable.Controls.Add(this.listViewAvailable);
            this.gbAvailable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbAvailable.Location = new System.Drawing.Point(374, 2);
            this.gbAvailable.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbAvailable.Name = "gbAvailable";
            this.gbAvailable.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbAvailable.Size = new System.Drawing.Size(314, 197);
            this.gbAvailable.TabIndex = 2;
            this.gbAvailable.TabStop = false;
            this.gbAvailable.Text = "Available: 0";
            // 
            // listViewAvailable
            // 
            this.listViewAvailable.CheckBoxes = true;
            this.listViewAvailable.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.DisplayNameABL,
            this.BUABL});
            this.listViewAvailable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewAvailable.FullRowSelect = true;
            this.listViewAvailable.Location = new System.Drawing.Point(3, 17);
            this.listViewAvailable.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listViewAvailable.Name = "listViewAvailable";
            this.listViewAvailable.Size = new System.Drawing.Size(308, 178);
            this.listViewAvailable.TabIndex = 1;
            this.listViewAvailable.UseCompatibleStateImageBehavior = false;
            this.listViewAvailable.View = System.Windows.Forms.View.Details;
            this.listViewAvailable.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listViewAvailable_ColumnClick);
            // 
            // DisplayNameABL
            // 
            this.DisplayNameABL.Text = "Name";
            this.DisplayNameABL.Width = 250;
            // 
            // BUABL
            // 
            this.BUABL.Text = "Business Unit";
            this.BUABL.Width = 100;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnUnAssign);
            this.panel1.Controls.Add(this.btnAssign);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(323, 2);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(45, 197);
            this.panel1.TabIndex = 3;
            // 
            // btnUnAssign
            // 
            this.btnUnAssign.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnUnAssign.Enabled = false;
            this.btnUnAssign.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnUnAssign.FlatAppearance.BorderSize = 2;
            this.btnUnAssign.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnUnAssign.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUnAssign.Location = new System.Drawing.Point(1, 69);
            this.btnUnAssign.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnUnAssign.Name = "btnUnAssign";
            this.btnUnAssign.Size = new System.Drawing.Size(45, 37);
            this.btnUnAssign.TabIndex = 5;
            this.btnUnAssign.Text = ">>";
            this.tooltipUnAssign.SetToolTip(this.btnUnAssign, "Unassign selected.");
            this.btnUnAssign.UseVisualStyleBackColor = false;
            this.btnUnAssign.Click += new System.EventHandler(this.btnUnAssign_Click);
            // 
            // btnAssign
            // 
            this.btnAssign.Enabled = false;
            this.btnAssign.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAssign.Location = new System.Drawing.Point(0, 111);
            this.btnAssign.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAssign.Name = "btnAssign";
            this.btnAssign.Size = new System.Drawing.Size(45, 37);
            this.btnAssign.TabIndex = 4;
            this.btnAssign.Text = "<<";
            this.tooltipAssign.SetToolTip(this.btnAssign, "Assign selected.");
            this.btnAssign.UseVisualStyleBackColor = true;
            this.btnAssign.Click += new System.EventHandler(this.btnAssign_Click);
            // 
            // MultiSelectControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MinimumSize = new System.Drawing.Size(691, 201);
            this.Name = "MultiSelectControl";
            this.Size = new System.Drawing.Size(691, 201);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.gbAssigned.ResumeLayout(false);
            this.gbAvailable.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox gbAssigned;
        private System.Windows.Forms.ListView listViewAssigned;
        private System.Windows.Forms.ColumnHeader DisplayNameASG;
        private System.Windows.Forms.GroupBox gbAvailable;
        private System.Windows.Forms.ListView listViewAvailable;
        private System.Windows.Forms.ColumnHeader DisplayNameABL;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnUnAssign;
        private System.Windows.Forms.Button btnAssign;
        private System.Windows.Forms.ColumnHeader BUASG;
        private System.Windows.Forms.ColumnHeader BUABL;
        private System.Windows.Forms.ToolTip tooltipUnAssign;
        private System.Windows.Forms.ToolTip tooltipAssign;
    }
}
