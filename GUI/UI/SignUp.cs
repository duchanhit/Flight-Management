using BUS.Service;
using DTO.Entites;
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

namespace GUI
{
    public partial class SignUp : Form
    {
        public SignUp()
        {
            InitializeComponent();
            _accountBUS = new AccountBUS();
 
        }
        private readonly AccountBUS _accountBUS;

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
                AccountUser = txtUser.Text.Trim(),
                AccountPass = txtPassWord.Text.Trim()
            };

            int permissionId;
            if (string.IsNullOrWhiteSpace(txtAccountType.Text))
            {
                ShowAutoCloseMessage("Permission ID cannot be empty!", 1500);
                return;
            }
            else if (!int.TryParse(txtAccountType.Text, out permissionId))
            {
                ShowAutoCloseMessage("Permission ID must be a number!", 1500);
                return;
            }

            var validationResults = new List<ValidationResult>();

            var accountContext = new ValidationContext(account, null, null);
            bool isAccountValid = Validator.TryValidateObject(account, accountContext, validationResults, true);

            if (!isAccountValid)
            {
                foreach (var validationResult in validationResults)
                {
                    ShowAutoCloseMessage(validationResult.ErrorMessage, 1500);
                }
                return;
            }

            bool isInserted = _accountBUS.InsertAccount(account.AccountId, account.AccountUser, account.AccountPass, permissionId);

            if (isInserted)
            {
                ShowAutoCloseMessage("Registration successful!", 1500);
                ClearFields();
            }
            else
            {
                ShowAutoCloseMessage("Registration failed. Please try again!", 1500);
            }

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



        private void ClearFields()
        {
            txtUser.Text = "";
            txtPassWord.Text = "";
            txtAccountType.Text = "";
        }
    }
}
