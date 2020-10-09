using System;
using System.Text;
using System.Windows.Forms;
using TRMWinFormUI.Helper;

namespace TRMWinFormUI
{
    public partial class frmLogin : Form
    {
        private string _username, _password;
        private IAPIHelper _aPIHelper;
        string yourName;
        public frmLogin()
        {
            InitializeComponent();
        }

        public string Username { get => _username; set => _username = value; }
        public string Password { get => _password; set => _password = value; }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            _aPIHelper = new APIHelper();
            int? len = yourName?.Length;
        }

        private void frmLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmMain.IsShowLogin = false;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Login();
        }

        private async void Login()
        {
            Username = txtUsername.Text;
            Password = txtPassword.Text;
            try
            {
                var result = await _aPIHelper.Authenticate(Username, Password);
                StringBuilder sb = new StringBuilder();
                sb.Append("Username: " + result.UserName);
                sb.Append("\nToken: " + result.Access_Token);
                RboxMessage.Text = sb.ToString();
            }
            catch (Exception ex)
            {
                RboxMessage.Text = ex.Message;
            }
        }
    }
}
