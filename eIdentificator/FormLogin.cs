using eIdentificator.Domain.Interfaces;
using System;
using System.Windows.Forms;

namespace eIdentificator
{
    public partial class FormLogin : Form
    {
        private const string Password = "3s/l0hOLRnf0cTlZodC2xIhI0VuZTpzZDTg4kC8mhJKKqPeBNPJXEr03ajZ9Nhdx++D5bU3h7nfoKVD/tj0K2Q==";
        public bool IsAuthenticated { get; private set; }
        private readonly IFormHelper _formHelper;
        private readonly IPasswordHelper _passwordHelper;
        public FormLogin(
            IFormHelper formHelper, 
            IPasswordHelper passwordHelper
        )
        {
            InitializeComponent(); 
            
            IsAuthenticated = false;
            _formHelper = formHelper;
            _passwordHelper = passwordHelper;
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            _formHelper.CenterControlHorizontal(
                labelLogin,
                textBoxLogin,
                buttonLogin
            );
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxLogin.Text))
            {
                MessageBox.Show(
                    "Password field must be populated!", 
                    "Error", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Error
                );
            }
            else if (!_passwordHelper.VerifyPassword(
                textBoxLogin.Text, 
                Password
                )
            )
            {
                MessageBox.Show(
                    "Invalid Password!", 
                    "Error", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Error
                );
                textBoxLogin.Clear();
            }
            else
            {
                IsAuthenticated = true;
                MessageBox.Show(
                    "Login successful.", 
                    "Information", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Information
                );
                this.Close();
            }
        }
    }
}
