using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XrmToolBox.Extensibility;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Sdk;
using McTools.Xrm.Connection;
using PKM.XRMToolBox.TeamSecurityManager.View;
using System.Diagnostics;
using PKM.XRMToolBox.TeamSecurityManager.Properties;

namespace PKM.XRMToolBox.TeamSecurityManager
{
    public partial class TSMPluginControl : PluginControlBase
    {
        private Settings mySettings;

        public TSMPluginControl()
        {
            InitializeComponent();
        }

        private void MyPluginControl_Load(object sender, EventArgs e)
        {
            //ShowInfoNotification("This is a notification that can lead to XrmToolBox repository", new Uri("https://github.com/MscrmTools/XrmToolBox"));

            // Loads or creates the settings for the plugin
            if (!SettingsManager.Instance.TryLoad(GetType(), out mySettings))
            {
                mySettings = new Settings();

                LogWarning("Settings not found => a new settings file has been created!");
            }
            else
            {
                LogInfo("Settings found and loaded");
            }
        }

        private void tsbClose_Click(object sender, EventArgs e)
        {
            CloseTool();
        }

        private void tsbLoadCRMData_Click(object sender, EventArgs e)
        {
            ExecuteMethod<Action>(ReloadCRMData, this.usmView1.HideDownloadControls);

        }

        /// <summary>
        /// This event occurs when the plugin is closed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MyPluginControl_OnCloseTool(object sender, EventArgs e)
        {
            // Before leaving, save the settings
            SettingsManager.Instance.Save(GetType(), mySettings);
        }

        /// <summary>
        /// This event occurs when the connection has been updated in XrmToolBox
        /// </summary>
        public override void UpdateConnection(IOrganizationService newService, ConnectionDetail detail, string actionName, object parameter)
        {
            if (this.ConnectionDetail != null)
            {
                this.usmView1.ClearData();
                this.usmView1.TopParentControl = null;
            }
            base.UpdateConnection(newService, detail, actionName, parameter);
            if (mySettings != null)
            {
                mySettings.LastUsedOrganizationWebappUrl = detail.WebApplicationUrl;
            }
            //toolStripLabelUserName.Text = string.Format("{0},", detail.UserName);
            //toolStripLabelCRMOrgUrl.Text = detail.WebApplicationUrl;
            LogInfo("Connection has changed to: {0}", detail.WebApplicationUrl);
        }

        private void ReloadCRMData(Action postLoadEvent = null)
        {
            WorkAsync(new WorkAsyncInfo
            {
                Message = "Getting data from CRM",
                Work = (worker, args) =>
                {
                    this.usmView1.TopParentControl = this;
                    this.usmView1.FetchCRMData();
                },
                PostWorkCallBack = (args) =>
                {
                    if (args.Error != null)
                    {
                        MessageBox.Show(args.Error.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        LogError(args.Error.ToString());
                    }
                    else
                    {
                        this.usmView1.DisplayData();
                        postLoadEvent?.Invoke();
                    }
                }
            });
        }

        private void tsbDownloadReport_Click(object sender, EventArgs e)
        {
            if (this.usmView1.Users?.Count > 0)
            {
                this.usmView1.DisplayDownloadControls();
            }
            else
            {
                ExecuteMethod<Action>(ReloadCRMData, this.usmView1.DisplayDownloadControls);
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start("https://nishantrana.me/user-guide-user-security-manager-xrmtoolbox-plugin-for-managing-users-security/");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}