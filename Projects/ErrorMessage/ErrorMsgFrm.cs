using System;
using System.Windows.Forms;

namespace ErrorMessage
{
    public partial class ErrorMsgFrm : Form
    {        
        public ErrorMsgFrm()
        {
            InitializeComponent();
        }
        public ErrorMsgFrm(string header, string errorFile) : this()
        {
            initializeComponent(header, errorFile);
        }


        private void ErrorMsgFrm_Load(object sender, EventArgs e)
        {
            loadForm();
        }

        private void btnReboot_Click(object sender, EventArgs e)
        {
            reboot();    
        }

        private void btnRetry_Click(object sender, EventArgs e)
        {
            Environment.Exit(2);
        }
    }
}
