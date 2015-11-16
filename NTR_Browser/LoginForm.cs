using System.Windows.Forms;

namespace NTR_WebBrowser
{
    partial class LoginForm : Form
    {
        public string UserName
        {
            get { return txtUsername.Text; }
            set { txtUsername.Text = value; }
        }
        public string Password
        {
            get { return txtPassword.Text; }
            set { txtPassword.Text = value; }
        }
        public LoginForm()
        {
            InitializeComponent();
        }
    }
}
