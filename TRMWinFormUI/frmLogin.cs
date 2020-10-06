using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TRMWinFormUI
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private string _username, _password;

        public string Username { get => _username; set => _username = value; }
        public string Password { get => _password; set => _password = value; }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        private void frmLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmMain.IsShowLogin = false;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

        }
    }
}
