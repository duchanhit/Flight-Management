using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            txtPassWord.UseSystemPasswordChar = true;
            txtPassWord.IconRight = Properties.Resources.icons_eye_white_;
        }

        private void txtUser_Enter(object sender, EventArgs e)
        {
            txtUser.IconLeft = Properties.Resources.icons8_user_green;
        }

        private void txtUser_Leave(object sender, EventArgs e)
        {
            txtUser.IconLeft = Properties.Resources.icons8_user_White;
        }

        private void txtPassWord_Enter(object sender, EventArgs e)
        {
            txtPassWord.IconLeft = Properties.Resources.icons8_lock_green;
        }

        private void txtPassWord_Leave(object sender, EventArgs e)
        {
            txtPassWord.IconLeft = Properties.Resources.icons8_lock_white;
        }

        private void txtPassWord_IconRightClick(object sender, EventArgs e)
        {    
            if (txtPassWord.UseSystemPasswordChar)
            {
                txtPassWord.UseSystemPasswordChar = false; 
                txtPassWord.IconRight = Properties.Resources.icons8_hide_eye; 
            }
            else
            {
                txtPassWord.UseSystemPasswordChar = true; 
                txtPassWord.IconRight = Properties.Resources.icons_eye_white_; 
            }
        }

        private void signupLabel_Click(object sender, EventArgs e)
        {
            SignUp signUpForm = new SignUp(); 
            signUpForm.Show();
        }


    }
}
