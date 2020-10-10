using System;
using System.Windows.Forms;
using TRMWinFormUI.Helper;

namespace TRMWinFormUI
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
           // _loggedInUser = new LoggedInUser();
        }
        public static bool IsShowLogin;
        public static ILoggedInUser _loggedInUser;

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
