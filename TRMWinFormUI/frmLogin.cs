using System;
using System.Windows.Forms;
using TRMWinFormUI.Helper;

namespace TRMWinFormUI
{
    public partial class frmLogin : Form
    {
        private string _username, _password;
        private IAPIHelper _aPIHelper;
        public frmLogin()
        {
            InitializeComponent();
        }


        public string Username { get => _username; set => _username = value; }
        public string Password { get => _password; set => _password = value; }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            _aPIHelper = new APIHelper();
        }

        private void frmLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmMain.IsShowLogin = false;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Username = txtUsername.Text;
            Password = txtPassword.Text;
            try
            {
                var result = _aPIHelper.Authenticate(Username, Password);
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }

        }
    }
}
