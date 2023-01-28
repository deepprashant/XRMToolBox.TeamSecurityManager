namespace PKM.XRMToolBox.TeamSecurityManager
{
    partial class TSMPluginControl
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TSMPluginControl));
            this.toolStripMenu = new System.Windows.Forms.ToolStrip();
            this.tsbClose = new System.Windows.Forms.ToolStripButton();
            this.tssSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbLoadCRMData = new System.Windows.Forms.ToolStripButton();
            this.tsbReport = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.usmView1 = new PKM.XRMToolBox.TeamSecurityManager.UserControls.USMView();
            this.toolStripMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripMenu
            // 
            this.toolStripMenu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStripMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbClose,
            this.tssSeparator1,
            this.tsbLoadCRMData,
            this.tsbReport,
            this.toolStripButton1});
            this.toolStripMenu.Location = new System.Drawing.Point(0, 0);
            this.toolStripMenu.Name = "toolStripMenu";
            this.toolStripMenu.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.toolStripMenu.Size = new System.Drawing.Size(1459, 31);
            this.toolStripMenu.TabIndex = 4;
            this.toolStripMenu.Text = "toolStrip1";
            // 
            // tsbClose
            // 
            this.tsbClose.Image = ((System.Drawing.Image)(resources.GetObject("tsbClose.Image")));
            this.tsbClose.Name = "tsbClose";
            this.tsbClose.Size = new System.Drawing.Size(73, 28);
            this.tsbClose.Text = "Close";
            this.tsbClose.ToolTipText = "Close User Security Manager";
            this.tsbClose.Click += new System.EventHandler(this.tsbClose_Click);
            // 
            // tssSeparator1
            // 
            this.tssSeparator1.Name = "tssSeparator1";
            this.tssSeparator1.Size = new System.Drawing.Size(6, 31);
            // 
            // tsbLoadCRMData
            // 
            this.tsbLoadCRMData.Image = ((System.Drawing.Image)(resources.GetObject("tsbLoadCRMData.Image")));
            this.tsbLoadCRMData.Name = "tsbLoadCRMData";
            this.tsbLoadCRMData.Size = new System.Drawing.Size(116, 28);
            this.tsbLoadCRMData.Text = "Load Teams";
            this.tsbLoadCRMData.Click += new System.EventHandler(this.tsbLoadCRMData_Click);
            // 
            // tsbReport
            // 
            this.tsbReport.Image = ((System.Drawing.Image)(resources.GetObject("tsbReport.Image")));
            this.tsbReport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbReport.Name = "tsbReport";
            this.tsbReport.Size = new System.Drawing.Size(178, 28);
            this.tsbReport.Text = "Team Security Report";
            this.tsbReport.Click += new System.EventHandler(this.tsbDownloadReport_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(119, 28);
            this.toolStripButton1.Text = "User Manual";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // usmView1
            // 
            this.usmView1.BUs = null;
            this.usmView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.usmView1.FieldSecurity = null;
            this.usmView1.Location = new System.Drawing.Point(0, 31);
            this.usmView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.usmView1.Name = "usmView1";
            this.usmView1.Presenter = null;
            this.usmView1.Roles = null;
            this.usmView1.SelectedTeams = null;
            this.usmView1.Size = new System.Drawing.Size(1459, 818);
            this.usmView1.TabIndex = 5;
            this.usmView1.TeamFieldSecurity = null;
            this.usmView1.TeamRole = null;
            this.usmView1.Teams = null;
            this.usmView1.TopParentControl = null;
            this.usmView1.UserFieldSecurity = null;
            this.usmView1.UserRole = null;
            this.usmView1.Users = null;
            this.usmView1.UserTeam = null;
            // 
            // USMPluginControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.usmView1);
            this.Controls.Add(this.toolStripMenu);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "USMPluginControl";
            this.Size = new System.Drawing.Size(1459, 849);
            this.Load += new System.EventHandler(this.MyPluginControl_Load);
            this.toolStripMenu.ResumeLayout(false);
            this.toolStripMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip toolStripMenu;
        private System.Windows.Forms.ToolStripButton tsbClose;
        private System.Windows.Forms.ToolStripButton tsbLoadCRMData;
        private System.Windows.Forms.ToolStripSeparator tssSeparator1;
        private TeamSecurityManager.UserControls.USMView usmView1;
        private System.Windows.Forms.ToolStripButton tsbReport;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
    }
}
