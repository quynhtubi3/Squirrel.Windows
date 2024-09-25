using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Squirrel;

namespace Squirrel.Windows
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Text = "Squirrel.Windows Version " + Application.ProductVersion;
            label3.Text = Application.ProductVersion;
        }
        private async void Button1_ClickAsync(object sender, EventArgs e)
        {
            await CheckForUpdates();
        }
        private async Task CheckForUpdates()
        {
            using (var mgr = UpdateManager.GitHubUpdateManager("https://github.com/quynhtubi3/Squirrel.Windows"))
            {
                var updateInfo = await mgr.Result.CheckForUpdate();
                if (updateInfo.ReleasesToApply.Any())
                {
                    MessageBox.Show("New update found!");
                    await mgr.Result.UpdateApp();
                }
                else
                {
                    MessageBox.Show("No updates available.");
                }
            }
        }
    }
}
