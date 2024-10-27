using BUS.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


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
            // Lấy thông tin từ các trường nhập liệu
            string userId = Guid.NewGuid().ToString(); // Tạo ID duy nhất cho tài khoản
            string username = txtUser.Text.Trim();
            string password = txtPassWord.Text.Trim();
            int permissionId;

            // Kiểm tra các trường bắt buộc đã được nhập chưa
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(txtAccountType.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Xác định quyền truy cập từ `txtAccountType`
            if (!int.TryParse(txtAccountType.Text, out permissionId))
            {
                MessageBox.Show("Loại quyền phải là số!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Gọi phương thức InsertAccount trong lớp AccountBUS
            bool isInserted = _accountBUS.InsertAccount(userId, username, password, permissionId);

            if (isInserted)
            {
                MessageBox.Show("Đăng ký thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Bạn có thể reset form hoặc đóng form sau khi đăng ký thành công
                ClearFields();
            }
            else
            {
                MessageBox.Show("Đăng ký thất bại. Vui lòng thử lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void ClearFields()
        {
            txtUser.Text = "";
            txtPassWord.Text = "";
            txtAccountType.Text = "";
        }
    }
}
