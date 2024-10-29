using BUS.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using DTO.Entities;
using System.Text.RegularExpressions;

namespace GUI
{
    public partial class SignUp : Form
    {
        private readonly AccountBUS _accountBUS;
        private Queue<string> messageQueue = new Queue<string>();
        private bool isShowingMessage = false;

        #region Methods
        public SignUp()
        {
            InitializeComponent();
            _accountBUS = new AccountBUS();
 
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

        // Kiểm tra cú pháp Email người dùng nhập
        private bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                // Regular expression pattern for validating email addresses
                var emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
                return Regex.IsMatch(email, emailPattern, RegexOptions.IgnoreCase);
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void ShowAutoCloseMessage(string message, int duration)
        {
            Form messageForm = new Form
            {
                Text = "Warning",
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
                ShowNextMessage(duration); // Show next message when the current one closes
            };

            messageForm.Show();
            timer.Start();
        }
        private void ClearFields()
        {
            txtUser.Text = "";
            txtPassWord.Text = "";
            txtAccountType.Text = "";
        }
        #endregion

        #region Events
        private void SignUp_Load(object sender, EventArgs e)
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

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            var account = new Account
            {
                AccountId = Guid.NewGuid().ToString(),
                Gmail = txtGmail.Text.Trim(),
                AccountUser = txtUser.Text.Trim(),
                AccountPass = txtPassWord.Text.Trim()
            };

            // Validate email syntax
            if (!IsValidEmail(account.Gmail))
            {
                EnqueueMessage("Email không đúng định dạng!", 1500);
                return;
            }

            int permissionId;
            if (string.IsNullOrWhiteSpace(txtAccountType.Text))
            {
                EnqueueMessage("Quyền truy cập không được để trống!", 1500);
                return;
            }
            else if (!int.TryParse(txtAccountType.Text, out permissionId))
            {
                EnqueueMessage("Quyền truy cập phải là số!", 1500);
                return;
            }

            var validationResults = new List<ValidationResult>();
            var accountContext = new ValidationContext(account, null, null);
            bool isAccountValid = Validator.TryValidateObject(account, accountContext, validationResults, true);

            if (!isAccountValid)
            {
                foreach (var validationResult in validationResults)
                {
                    EnqueueMessage(validationResult.ErrorMessage, 2000);
                }
                return;
            }

            bool isInserted = _accountBUS.InsertAccount(account.AccountId, account.AccountUser, account.AccountPass, permissionId, account.Gmail);

            if (isInserted)
            {
<<<<<<< HEAD
                EnqueueMessage("Đăng ký thành công!", 1500);
=======
                MessageBox.Show("Đăng ký thành công!", "Thông báo", MessageBoxButtons.OK);
>>>>>>> hanh
                ClearFields();
            }
            else
            {
                EnqueueMessage("Đăng ký thất bại. Mời bạn thử lại!", 1500);
            }

        }

        #endregion


    }
}
