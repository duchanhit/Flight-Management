using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flight_Management
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void FormLogin_Load(object sender, EventArgs e)
        {

        }


        private void txtPass_IconRightClick(object sender, EventArgs e)
        {
            if (txtPassword.PasswordChar == '•') // Nếu đang ẩn mật khẩu
            {
                txtPassword.PasswordChar = '\0'; // Hiển thị mật khẩu
                txtPassword.IconRight = Properties.Resources.eye_slashed; // Đổi icon thành mắt đóng
            }
            else
            {
                txtPassword.PasswordChar = '•'; // Ẩn mật khẩu
                txtPassword.IconRight = Properties.Resources.eye; // Đổi icon thành mắt mở
            }
        }

        private void guna2HtmlLabel2_Click(object sender, EventArgs e)
        {

        }
    }
}
