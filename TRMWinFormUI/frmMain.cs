using System;
using System.Windows.Forms;

namespace TRMWinFormUI
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }
        public static bool IsShowLogin;

        private void btnViewLogin_Click(object sender, EventArgs e)
        {
            frmLogin login = new frmLogin();
            if (!IsShowLogin)
            {
                IsShowLogin = true;
                login.Show();
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            btnViewLogin.PerformClick();
        }
    }
}
