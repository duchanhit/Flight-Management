using BUS.Service;
using DTO.Entites;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
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

        private void ShowAutoCloseMessage(string message, int duration)
        {
            Form messageForm = new Form
            {
                Text = "Warning",
                FormBorderStyle = FormBorderStyle.FixedDialog,
                StartPosition = FormStartPosition.CenterScreen,
                Size = new Size(300, 120), // Increased width for better text fit
                BackColor = Color.White,
                ControlBox = true,
                Icon = SystemIcons.Warning,
                ShowInTaskbar = false
            };

            // Icon PictureBox
            PictureBox iconPictureBox = new PictureBox
            {
                Image = SystemIcons.Warning.ToBitmap(),
                Location = new Point(15, 30),
                Size = new Size(32, 32), // Icon size for smaller form
                SizeMode = PictureBoxSizeMode.StretchImage
            };
            messageForm.Controls.Add(iconPictureBox);

            // Message Label - center aligned
            Label messageLabel = new Label
            {
                Text = message,
                AutoSize = false,
                Location = new Point(55, 30),
                Size = new Size(220, 32), // Increased width for text
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Arial", 10), // Font size
                ForeColor = Color.Black
            };
            messageForm.Controls.Add(messageLabel);

            // Timer for auto-close
            Timer timer = new Timer
            {
                Interval = duration
            };
            timer.Tick += (s, e) =>
            {
                messageForm.Close();
                timer.Stop();
            };

            messageForm.Show();
            timer.Start();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // Tạo đối tượng Account với dữ liệu từ người dùng
            var account = new Account
            {
                AccountUser = txtUser.Text.Trim(),
                AccountPass = txtPassWord.Text.Trim()
            };

            // Tạo danh sách để lưu các kết quả kiểm tra tính hợp lệ
            var validationResults = new List<ValidationResult>();
            var validationContext = new ValidationContext(account, null, null);

            // Kiểm tra tính hợp lệ của đối tượng Account
            bool isValid = Validator.TryValidateObject(account, validationContext, validationResults, true);

            if (!isValid)
            {
                // Nếu có lỗi, hiển thị các thông báo lỗi cho người dùng
                foreach (var validationResult in validationResults)
                {
                    ShowAutoCloseMessage(validationResult.ErrorMessage, 1500); 
                }
                return;
            }

            // Nếu hợp lệ, tiến hành kiểm tra thông tin đăng nhập
            AccountBUS accountBLL = new AccountBUS();
            bool isAuthenticated = accountBLL.Login(account.AccountUser, account.AccountPass);

            if (isAuthenticated)
            {
                ShowAutoCloseMessage("Login success!", 1500); 
                DashBoard mainForm = new DashBoard();
                mainForm.Show();
                this.Hide();
            }
            else
            {
                ShowAutoCloseMessage("Tên đăng nhập hoặc mật khẩu không đúng.", 1500); 
                txtPassWord.Clear();
                txtPassWord.Focus();
            }
        }
    }
}
