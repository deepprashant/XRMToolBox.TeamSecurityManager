using System;

namespace PKM.XRMToolBox.TeamSecurityManager.UserControls
{
    partial class USMView
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
                ((IDisposable)userSorter).Dispose();
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
            this.gbUsers = new System.Windows.Forms.GroupBox();
            this.listViewTeams = new System.Windows.Forms.ListView();
            this.FullName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.userBU = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.gbUserDetails = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.gbTeams = new System.Windows.Forms.GroupBox();
            this.multiSelectUsers = new PKM.XRMToolBox.TeamSecurityManager.UserControls.MultiSelectControl();
            this.gbRoles = new System.Windows.Forms.GroupBox();
            this.multiSelectRoles = new PKM.XRMToolBox.TeamSecurityManager.UserControls.MultiSelectControl();
            this.gbGeneral = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxBU = new System.Windows.Forms.ComboBox();
            this.lblTeamName = new System.Windows.Forms.Label();
            this.txtTeamName = new System.Windows.Forms.TextBox();
            this.lblTeamType = new System.Windows.Forms.Label();
            this.txtTeamType = new System.Windows.Forms.TextBox();
            this.btnRemoveTeams = new System.Windows.Forms.Button();
            this.btnRemoveRoles = new System.Windows.Forms.Button();
            this.btnRemoveFSPs = new System.Windows.Forms.Button();
            this.gbFSP = new System.Windows.Forms.GroupBox();
            this.multiSelectFS = new PKM.XRMToolBox.TeamSecurityManager.UserControls.MultiSelectControl();
            this.toolTipRemoveRoles = new System.Windows.Forms.ToolTip(this.components);
            this.toolTipRemoveTeams = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip3 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip4 = new System.Windows.Forms.ToolTip(this.components);
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.gbReport = new System.Windows.Forms.GroupBox();
            this.userSecurityReport1 = new PKM.XRMToolBox.TeamSecurityManager.View.UserSecurityReport();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.gbUsers.SuspendLayout();
            this.gbUserDetails.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.gbTeams.SuspendLayout();
            this.gbRoles.SuspendLayout();
            this.gbGeneral.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.gbFSP.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.gbReport.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbUsers
            // 
            this.gbUsers.Controls.Add(this.listViewTeams);
            this.gbUsers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbUsers.Location = new System.Drawing.Point(0, 0);
            this.gbUsers.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbUsers.Name = "gbUsers";
            this.gbUsers.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbUsers.Size = new System.Drawing.Size(400, 1003);
            this.gbUsers.TabIndex = 0;
            this.gbUsers.TabStop = false;
            this.gbUsers.Text = "Users: 0";
            // 
            // listViewTeams
            // 
            this.listViewTeams.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.FullName,
            this.userBU});
            this.listViewTeams.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewTeams.FullRowSelect = true;
            this.listViewTeams.HideSelection = false;
            this.listViewTeams.Location = new System.Drawing.Point(3, 17);
            this.listViewTeams.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listViewTeams.MultiSelect = false;
            this.listViewTeams.Name = "listViewTeams";
            this.listViewTeams.Size = new System.Drawing.Size(394, 984);
            this.listViewTeams.TabIndex = 0;
            this.listViewTeams.UseCompatibleStateImageBehavior = false;
            this.listViewTeams.View = System.Windows.Forms.View.Details;
            this.listViewTeams.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listViewUsers_ColumnClick);
            this.listViewTeams.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.listViewTeams_ItemSelectionChanged);
            // 
            // FullName
            // 
            this.FullName.Text = "Name";
            this.FullName.Width = 200;
            // 
            // userBU
            // 
            this.userBU.Text = "Business Unit";
            this.userBU.Width = 100;
            // 
            // gbUserDetails
            // 
            this.gbUserDetails.Controls.Add(this.tableLayoutPanel1);
            this.gbUserDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbUserDetails.Location = new System.Drawing.Point(0, 0);
            this.gbUserDetails.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbUserDetails.Name = "gbUserDetails";
            this.gbUserDetails.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbUserDetails.Size = new System.Drawing.Size(1329, 861);
            this.gbUserDetails.TabIndex = 1;
            this.gbUserDetails.TabStop = false;
            this.gbUserDetails.Text = "Team Details";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.gbTeams, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.gbRoles, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.gbGeneral, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.gbFSP, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 17);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1323, 842);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // gbTeams
            // 
            this.gbTeams.Controls.Add(this.multiSelectUsers);
            this.gbTeams.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbTeams.Location = new System.Drawing.Point(3, 276);
            this.gbTeams.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbTeams.Name = "gbTeams";
            this.gbTeams.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel1.SetRowSpan(this.gbTeams, 2);
            this.gbTeams.Size = new System.Drawing.Size(655, 544);
            this.gbTeams.TabIndex = 1;
            this.gbTeams.TabStop = false;
            this.gbTeams.Text = "Users";
            // 
            // multiSelectUsers
            // 
            this.multiSelectUsers.Assigned = null;
            this.multiSelectUsers.AutoSize = true;
            this.multiSelectUsers.Available = null;
            this.multiSelectUsers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.multiSelectUsers.Location = new System.Drawing.Point(3, 17);
            this.multiSelectUsers.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.multiSelectUsers.MinimumSize = new System.Drawing.Size(691, 201);
            this.multiSelectUsers.Name = "multiSelectUsers";
            this.multiSelectUsers.Size = new System.Drawing.Size(691, 525);
            this.multiSelectUsers.TabIndex = 0;
            this.multiSelectUsers.ToAssigned = null;
            this.multiSelectUsers.ToUnAssigned = null;
            // 
            // gbRoles
            // 
            this.gbRoles.Controls.Add(this.multiSelectRoles);
            this.gbRoles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbRoles.Location = new System.Drawing.Point(664, 276);
            this.gbRoles.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbRoles.Name = "gbRoles";
            this.gbRoles.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel1.SetRowSpan(this.gbRoles, 2);
            this.gbRoles.Size = new System.Drawing.Size(656, 544);
            this.gbRoles.TabIndex = 2;
            this.gbRoles.TabStop = false;
            this.gbRoles.Text = "Roles";
            // 
            // multiSelectRoles
            // 
            this.multiSelectRoles.Assigned = null;
            this.multiSelectRoles.AutoSize = true;
            this.multiSelectRoles.Available = null;
            this.multiSelectRoles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.multiSelectRoles.Location = new System.Drawing.Point(3, 17);
            this.multiSelectRoles.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.multiSelectRoles.MinimumSize = new System.Drawing.Size(691, 201);
            this.multiSelectRoles.Name = "multiSelectRoles";
            this.multiSelectRoles.Size = new System.Drawing.Size(691, 525);
            this.multiSelectRoles.TabIndex = 0;
            this.multiSelectRoles.ToAssigned = null;
            this.multiSelectRoles.ToUnAssigned = null;
            // 
            // gbGeneral
            // 
            this.gbGeneral.Controls.Add(this.tableLayoutPanel2);
            this.gbGeneral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbGeneral.Location = new System.Drawing.Point(664, 2);
            this.gbGeneral.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbGeneral.Name = "gbGeneral";
            this.gbGeneral.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbGeneral.Size = new System.Drawing.Size(656, 270);
            this.gbGeneral.TabIndex = 4;
            this.gbGeneral.TabStop = false;
            this.gbGeneral.Text = "General";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.comboBoxBU, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblTeamName, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.txtTeamName, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.lblTeamType, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.txtTeamType, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.btnRemoveTeams, 1, 4);
            this.tableLayoutPanel2.Controls.Add(this.btnRemoveRoles, 2, 4);
            this.tableLayoutPanel2.Controls.Add(this.btnRemoveFSPs, 3, 4);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 17);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 6;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(650, 251);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Business Unit:";
            // 
            // comboBoxBU
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.comboBoxBU, 3);
            this.comboBoxBU.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBoxBU.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxBU.FormattingEnabled = true;
            this.comboBoxBU.Location = new System.Drawing.Point(165, 2);
            this.comboBoxBU.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxBU.Name = "comboBoxBU";
            this.comboBoxBU.Size = new System.Drawing.Size(482, 24);
            this.comboBoxBU.TabIndex = 3;
            this.comboBoxBU.SelectedIndexChanged += new System.EventHandler(this.comboBoxBU_SelectedIndexChanged);
            // 
            // lblTeamName
            // 
            this.lblTeamName.AutoSize = true;
            this.lblTeamName.Location = new System.Drawing.Point(3, 35);
            this.lblTeamName.Name = "lblTeamName";
            this.lblTeamName.Size = new System.Drawing.Size(86, 16);
            this.lblTeamName.TabIndex = 4;
            this.lblTeamName.Text = "Team Name:";
            this.lblTeamName.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtTeamName
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.txtTeamName, 3);
            this.txtTeamName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTeamName.Enabled = false;
            this.txtTeamName.Location = new System.Drawing.Point(165, 37);
            this.txtTeamName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTeamName.Name = "txtTeamName";
            this.txtTeamName.Size = new System.Drawing.Size(482, 22);
            this.txtTeamName.TabIndex = 6;
            // 
            // lblTeamType
            // 
            this.lblTeamType.AutoSize = true;
            this.lblTeamType.Location = new System.Drawing.Point(3, 70);
            this.lblTeamType.Name = "lblTeamType";
            this.lblTeamType.Size = new System.Drawing.Size(81, 16);
            this.lblTeamType.TabIndex = 12;
            this.lblTeamType.Text = "Team Type:";
            this.lblTeamType.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtTeamType
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.txtTeamType, 3);
            this.txtTeamType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTeamType.Enabled = false;
            this.txtTeamType.Location = new System.Drawing.Point(165, 72);
            this.txtTeamType.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTeamType.Name = "txtTeamType";
            this.txtTeamType.Size = new System.Drawing.Size(482, 22);
            this.txtTeamType.TabIndex = 13;
            // 
            // btnRemoveTeams
            // 
            this.btnRemoveTeams.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRemoveTeams.Location = new System.Drawing.Point(165, 107);
            this.btnRemoveTeams.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRemoveTeams.Name = "btnRemoveTeams";
            this.btnRemoveTeams.Size = new System.Drawing.Size(156, 31);
            this.btnRemoveTeams.TabIndex = 16;
            this.btnRemoveTeams.Text = "Remove All Users";
            this.toolTipRemoveTeams.SetToolTip(this.btnRemoveTeams, "Removes user from all the teams.");
            this.btnRemoveTeams.UseVisualStyleBackColor = true;
            this.btnRemoveTeams.Click += new System.EventHandler(this.btnRemoveUsers_Click);
            // 
            // btnRemoveRoles
            // 
            this.btnRemoveRoles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRemoveRoles.Location = new System.Drawing.Point(327, 107);
            this.btnRemoveRoles.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRemoveRoles.Name = "btnRemoveRoles";
            this.btnRemoveRoles.Size = new System.Drawing.Size(156, 31);
            this.btnRemoveRoles.TabIndex = 15;
            this.btnRemoveRoles.Text = "Remove All Roles";
            this.toolTipRemoveRoles.SetToolTip(this.btnRemoveRoles, "Removes all the security roles of the team.");
            this.btnRemoveRoles.UseVisualStyleBackColor = true;
            this.btnRemoveRoles.Click += new System.EventHandler(this.btnRemoveRoles_Click);
            // 
            // btnRemoveFSPs
            // 
            this.btnRemoveFSPs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRemoveFSPs.Location = new System.Drawing.Point(489, 108);
            this.btnRemoveFSPs.Name = "btnRemoveFSPs";
            this.btnRemoveFSPs.Size = new System.Drawing.Size(158, 29);
            this.btnRemoveFSPs.TabIndex = 17;
            this.btnRemoveFSPs.Text = "Remove All FSP";
            this.btnRemoveFSPs.UseVisualStyleBackColor = true;
            this.btnRemoveFSPs.Click += new System.EventHandler(this.btnRemoveFSPs_Click);
            // 
            // gbFSP
            // 
            this.gbFSP.Controls.Add(this.multiSelectFS);
            this.gbFSP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbFSP.Location = new System.Drawing.Point(3, 3);
            this.gbFSP.Name = "gbFSP";
            this.gbFSP.Size = new System.Drawing.Size(655, 268);
            this.gbFSP.TabIndex = 5;
            this.gbFSP.TabStop = false;
            this.gbFSP.Text = "Field Security Profile";
            // 
            // multiSelectFS
            // 
            this.multiSelectFS.Assigned = null;
            this.multiSelectFS.AutoSize = true;
            this.multiSelectFS.Available = null;
            this.multiSelectFS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.multiSelectFS.Location = new System.Drawing.Point(3, 18);
            this.multiSelectFS.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.multiSelectFS.MinimumSize = new System.Drawing.Size(691, 201);
            this.multiSelectFS.Name = "multiSelectFS";
            this.multiSelectFS.Size = new System.Drawing.Size(691, 247);
            this.multiSelectFS.TabIndex = 0;
            this.multiSelectFS.ToAssigned = null;
            this.multiSelectFS.ToUnAssigned = null;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.gbReport);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.gbUserDetails);
            this.splitContainer1.Size = new System.Drawing.Size(1329, 1003);
            this.splitContainer1.SplitterDistance = 138;
            this.splitContainer1.TabIndex = 2;
            // 
            // gbReport
            // 
            this.gbReport.Controls.Add(this.userSecurityReport1);
            this.gbReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbReport.Location = new System.Drawing.Point(0, 0);
            this.gbReport.Name = "gbReport";
            this.gbReport.Size = new System.Drawing.Size(1329, 138);
            this.gbReport.TabIndex = 1;
            this.gbReport.TabStop = false;
            this.gbReport.Text = "User Security Report";
            // 
            // userSecurityReport1
            // 
            this.userSecurityReport1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userSecurityReport1.FieldSecurities = null;
            this.userSecurityReport1.Location = new System.Drawing.Point(3, 18);
            this.userSecurityReport1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.userSecurityReport1.Name = "userSecurityReport1";
            this.userSecurityReport1.ParentView = null;
            this.userSecurityReport1.Roles = null;
            this.userSecurityReport1.Size = new System.Drawing.Size(1323, 117);
            this.userSecurityReport1.TabIndex = 0;
            this.userSecurityReport1.TeamFieldSecurity = null;
            this.userSecurityReport1.TeamRole = null;
            this.userSecurityReport1.Teams = null;
            this.userSecurityReport1.UserFieldSecurity = null;
            this.userSecurityReport1.Users = null;
            this.userSecurityReport1.UserTeam = null;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.gbUsers);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer1);
            this.splitContainer2.Size = new System.Drawing.Size(1733, 1003);
            this.splitContainer2.SplitterDistance = 400;
            this.splitContainer2.TabIndex = 3;
            // 
            // USMView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer2);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "USMView";
            this.Size = new System.Drawing.Size(1733, 1003);
            this.gbUsers.ResumeLayout(false);
            this.gbUserDetails.ResumeLayout(false);
            this.gbUserDetails.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.gbTeams.ResumeLayout(false);
            this.gbTeams.PerformLayout();
            this.gbRoles.ResumeLayout(false);
            this.gbRoles.PerformLayout();
            this.gbGeneral.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.gbFSP.ResumeLayout(false);
            this.gbFSP.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.gbReport.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }   

        //private void ListViewFieldSecurity_ItemSelectionChanged(object sender, System.Windows.Forms.ListViewItemSelectionChangedEventArgs e)
        //{
            
        //}

        //private void ListViewFieldSecurity_ColumnClick(object sender, System.Windows.Forms.ColumnClickEventArgs e)
        //{
        //    if (listViewFieldSecurity.Items.Count > 1)
        //    {
        //        userSorter.Sort(e.Column);
        //    }
        //}

        #endregion

        private System.Windows.Forms.GroupBox gbUsers;
        private System.Windows.Forms.GroupBox gbUserDetails;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox gbTeams;
        private MultiSelectControl multiSelectUsers;
        private MultiSelectControl multiSelectRoles;
        private System.Windows.Forms.GroupBox gbGeneral;
        private System.Windows.Forms.ListView listViewTeams;
  //      private System.Windows.Forms.ListView listViewFieldSecurity;
        private System.Windows.Forms.ColumnHeader FullName;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        //private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Label lblTeamName;
        private System.Windows.Forms.TextBox txtTeamName;
        private System.Windows.Forms.Label lblTeamType;
        private System.Windows.Forms.TextBox txtTeamType;
        private System.Windows.Forms.Button btnRemoveRoles;
        private System.Windows.Forms.Button btnRemoveTeams;
        private System.Windows.Forms.ColumnHeader userBU;
        private System.Windows.Forms.ToolTip toolTipRemoveRoles;
        private System.Windows.Forms.ToolTip toolTipRemoveTeams;
        private System.Windows.Forms.ToolTip toolTip3;
        private System.Windows.Forms.ToolTip toolTip4;
        private System.Windows.Forms.GroupBox gbRoles;
        private System.Windows.Forms.GroupBox gbFSP;
        private MultiSelectControl multiSelectFS;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.GroupBox gbReport;
        private View.UserSecurityReport userSecurityReport1;
        private System.Windows.Forms.Button btnRemoveFSPs;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxBU;
    }
}
