using BUS.Service;
using DTO.Entities;
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
        private Queue<string> messageQueue = new Queue<string>();
        private bool isShowingMessage = false;
        #region Methods
        public Login()
        {
            InitializeComponent();
        }
        private void EnqueueMessage(string message, int duration)
        {
            messageQueue.Enqueue(message);
            ShowNextMessage(duration);
        }

        private void ShowNextMessage(int duration)
        {
            if (isShowingMessage || messageQueue.Count == 0)
            {
                return;
            }

            isShowingMessage = true;
            string message = messageQueue.Dequeue();
            ShowAutoCloseMessage(message, duration);
        }


        private void ShowAutoCloseMessage(string message, int duration)
        {
            Form messageForm = new Form
            {
                Text = "Cảnh Báo",
                FormBorderStyle = FormBorderStyle.FixedDialog,
                StartPosition = FormStartPosition.CenterScreen,
                Size = new Size(300, 120),
                BackColor = Color.White,
                ControlBox = true,
                Icon = SystemIcons.Warning,
                ShowInTaskbar = false
            };

            PictureBox iconPictureBox = new PictureBox
            {
                Image = SystemIcons.Warning.ToBitmap(),
                Location = new Point(15, 30),
                Size = new Size(32, 32),
                SizeMode = PictureBoxSizeMode.StretchImage
            };
            messageForm.Controls.Add(iconPictureBox);

            Label messageLabel = new Label
            {
                Text = message,
                AutoSize = false,
                Location = new Point(55, 30),
                Size = new Size(220, 32),
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Arial", 10),
                ForeColor = Color.Black
            };
            messageForm.Controls.Add(messageLabel);

            Timer timer = new Timer
            {
                Interval = duration
            };
            timer.Tick += (s, e) =>
            {
                messageForm.Close();
                timer.Stop();
                isShowingMessage = false;
                ShowNextMessage(duration); 
            };

            messageForm.Show();
            timer.Start();
        }


        #endregion

        #region Events
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

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var account = new Account
            {
                AccountUser = txtUser.Text.Trim(),
                AccountPass = txtPassWord.Text.Trim()
            };

            var validationResults = new List<ValidationResult>();
            var validationContext = new ValidationContext(account, null, null);
            bool isValid = Validator.TryValidateObject(account, validationContext, validationResults, true);

            var filteredErrors = validationResults.Where(v => !v.MemberNames.Contains("Gmail")).ToList();

            if (filteredErrors.Any())
            {
                foreach (var validationResult in filteredErrors)
                {
                    EnqueueMessage(validationResult.ErrorMessage, 1500);
                }
                return;
            }

            AccountBUS accountBLL = new AccountBUS();
            bool isAuthenticated = accountBLL.Login(account.AccountUser, account.AccountPass);

            if (isAuthenticated)
            {
                EnqueueMessage("Đăng nhập thành công!", 1500);
                DashBoard mainForm = new DashBoard();
                mainForm.Show();
                this.Hide();
            }
            else
            {
                EnqueueMessage("Tên đăng nhập hoặc mật khẩu không đúng.", 4000);
                txtPassWord.Clear();
                txtPassWord.Focus();
            }
            #endregion
        }
    }
}
