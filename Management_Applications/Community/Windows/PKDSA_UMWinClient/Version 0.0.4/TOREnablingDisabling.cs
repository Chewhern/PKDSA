using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PKDSA_UMWinClient.Helper;

namespace PKDSA_UMWinClient
{
    public partial class TOREnablingDisabling : Form
    {
        public TOREnablingDisabling()
        {
            InitializeComponent();
        }

        private async void DownloadBTN_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(Application.StartupPath + "\\TOR_Proxy") == false) 
            {
                Directory.CreateDirectory(Application.StartupPath + "\\TOR_Proxy");
            }
            if (Directory.Exists(Application.StartupPath + "\\TOR_Proxy\\Zipped") == false) 
            {
                Directory.CreateDirectory(Application.StartupPath + "\\TOR_Proxy\\Zipped");
            }
            if (Directory.Exists(Application.StartupPath + "\\TOR_Proxy\\Extracted") == false) 
            {
                Directory.CreateDirectory(Application.StartupPath + "\\TOR_Proxy\\Extracted");
            }
            TORMainOperations.SetToolsDirectory(Application.StartupPath + "\\TOR_Proxy\\Zipped", Application.StartupPath + "\\TOR_Proxy\\Extracted");
            String TORDownloadStatus = await TORMainOperations.DownloadTOR();
            MessageBox.Show(TORDownloadStatus, "TOR Download Status");
        }

        private async void StartTORBTN_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(Application.StartupPath + "\\TOR_Proxy") == false || Directory.Exists(Application.StartupPath + "\\TOR_Proxy\\Zipped") == false || Directory.Exists(Application.StartupPath + "\\TOR_Proxy\\Extracted") == false)
            {
                MessageBox.Show("You have not downloaded the TOR software", "Missing Component");
            }
            else 
            {
                TORMainOperations.SetToolsDirectory(Application.StartupPath + "\\TOR_Proxy\\Zipped", Application.StartupPath + "\\TOR_Proxy\\Extracted");
                String TORStartStatus = await TORMainOperations.StartTOR();
                MessageBox.Show(TORStartStatus, "TOR Start Status");
            }
        }

        private void StopTORBTN_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(Application.StartupPath + "\\TOR_Proxy") == false || Directory.Exists(Application.StartupPath + "\\TOR_Proxy\\Zipped") == false || Directory.Exists(Application.StartupPath + "\\TOR_Proxy\\Extracted") == false)
            {
                MessageBox.Show("You have not downloaded the TOR software", "Missing Component");
            }
            else
            {
                TORMainOperations.SetToolsDirectory(Application.StartupPath + "\\TOR_Proxy\\Zipped", Application.StartupPath + "\\TOR_Proxy\\Extracted");
                TORMainOperations.StopTOR();
            }
        }

        private void OnFormClosing(object sender, EventArgs e)
        {
            MainFormHolder.myForm.Show();
        }
    }
}
