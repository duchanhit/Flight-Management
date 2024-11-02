using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS.Service;
using Guna.UI2.WinForms;

namespace GUI.UI
{
    public partial class QuenMatKhau : Form
    {
        private Guna2HtmlLabel lblEmail;
        private Guna2TextBox txtEmail;
        private Guna2Button btnChon;
        private Guna2TextBox txtNewPassword;
        private AccountBUS accountBUS;

        public QuenMatKhau()
        {
            InitializeComponent();
            InitializeCustomComponents();
            accountBUS = new AccountBUS(); // Khởi tạo đối tượng AccountBUS
        }

        private void InitializeCustomComponents()
        {
            // Cấu hình form
            this.Text = "Quên Mật Khẩu";
            this.Size = new System.Drawing.Size(400, 250);
            this.StartPosition = FormStartPosition.CenterScreen;

            // Label "Nhập Email:"
            lblEmail = new Guna2HtmlLabel();
            lblEmail.Text = "Nhập Email:";
            lblEmail.Location = new System.Drawing.Point(30, 40);
            lblEmail.Size = new System.Drawing.Size(100, 30);
            lblEmail.Font = new System.Drawing.Font("Segoe UI", 10);
            this.Controls.Add(lblEmail);

            // TextBox cho người dùng nhập email
            txtEmail = new Guna2TextBox();
            txtEmail.PlaceholderText = "Nhập email của bạn";
            txtEmail.Location = new System.Drawing.Point(140, 40);
            txtEmail.Size = new System.Drawing.Size(200, 30);
            this.Controls.Add(txtEmail);

            // Button "Chọn"
            btnChon = new Guna2Button();
            btnChon.Text = "Chọn";
            btnChon.Location = new System.Drawing.Point(140, 90);
            btnChon.Size = new System.Drawing.Size(100, 35);
            btnChon.Click += BtnChon_Click;
            this.Controls.Add(btnChon);

            // TextBox hiển thị mật khẩu mới
            txtNewPassword = new Guna2TextBox();
            txtNewPassword.PlaceholderText = "Mật khẩu của bạn";
            txtNewPassword.Location = new System.Drawing.Point(140, 140);
            txtNewPassword.Size = new System.Drawing.Size(200, 30);
            txtNewPassword.ReadOnly = true; // Chỉ đọc
            txtNewPassword.Visible = false; // Ẩn TextBox ban đầu
            this.Controls.Add(txtNewPassword);
        }

        // Xử lý sự kiện khi nhấn nút "Chọn"
        private void BtnChon_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            if (string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Vui lòng nhập email!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra định dạng email
            if (!IsValidEmail(email))
            {
                MessageBox.Show("Email không đúng định dạng! Vui lòng nhập lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Lấy mật khẩu từ AccountBUS
            string password = accountBUS.GetPasswordByEmail(email);

            if (password != null)
            {
                txtNewPassword.Text = password;
                txtNewPassword.Visible = true; // Hiển thị TextBox mật khẩu mới
            }
            else
            {
                MessageBox.Show("Không tìm thấy tài khoản với email này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Hàm kiểm tra định dạng email bằng Regex
        private bool IsValidEmail(string email)
        {
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, pattern);
        }
    }
}
