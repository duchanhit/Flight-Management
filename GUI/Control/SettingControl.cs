using System;
using System.Drawing;
using System.Windows.Forms;
using BUS;

namespace GUI.Control
{
    public partial class SettingControl : UserControl
    {
        private RestrictionsBUS restrictionsBUS;

        // Các TextBox cho các trường dữ liệu
        private TextBox txtMinFlightTime;
        private TextBox txtMaxTransit;
        private TextBox txtMinTransitTime;
        private TextBox txtMaxTransitTime;
        private TextBox txtLatestBookingTime;
        private TextBox txtLatestCancelingTime;

        public SettingControl()
        {
            InitializeComponent();
            InitializeCustomComponents();
            restrictionsBUS = new RestrictionsBUS();
        }

        private void SettingControl_Load(object sender, EventArgs e)
        {

        }

        private void InitializeCustomComponents()
        {
            this.BackColor = Color.White;

            // Tiêu đề Settings
            Label lblTitle = new Label();
            lblTitle.Text = "Settings";
            lblTitle.Font = new Font("Segoe UI", 24, FontStyle.Bold);
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(250, 20);
            this.Controls.Add(lblTitle);

            // Tạo các hàng thiết lập
            txtMinFlightTime = CreateSettingRow("Thời gian bay tối thiểu", "13:11:15", 100);
            txtMaxTransit = CreateSettingRow("Số lần Transit tối đa", "0", 150);
            txtMinTransitTime = CreateSettingRow("Thời gian Transit tối thiểu", "0:00:00", 200);
            txtMaxTransitTime = CreateSettingRow("Thời gian Transit tối đa", "0:00:00", 250);
            txtLatestBookingTime = CreateSettingRow("Thời gian đặt vé trễ nhất", "20", 300);
            txtLatestCancelingTime = CreateSettingRow("Thời gian hủy vé trễ nhất", "20", 350);

            // Các nút chức năng
            Button btnEdit = new Button();
            btnEdit.Text = "Chỉnh sửa";
            btnEdit.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btnEdit.Size = new Size(100, 40);
            btnEdit.Location = new Point(220, 420);
            btnEdit.BackColor = Color.MediumPurple;
            btnEdit.ForeColor = Color.White;
            btnEdit.Click += new EventHandler(btnEdit_Click);
            this.Controls.Add(btnEdit);

            Button btnReset = new Button();
            btnReset.Text = "Reset";
            btnReset.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btnReset.Size = new Size(100, 40);
            btnReset.Location = new Point(340, 420);
            btnReset.BackColor = Color.Lavender;
            btnReset.ForeColor = Color.Gray;
            btnReset.Click += new EventHandler(btnReset_Click);
            this.Controls.Add(btnReset);

            Button btnSave = new Button();
            btnSave.Text = "Save";
            btnSave.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btnSave.Size = new Size(100, 40);
            btnSave.Location = new Point(460, 420);
            btnSave.BackColor = Color.Lavender;
            btnSave.ForeColor = Color.Gray;
            btnSave.Click += new EventHandler(btnSave_Click);
            this.Controls.Add(btnSave);

            // Ban đầu, các ô nhập liệu sẽ bị khóa
            SetTextBoxEnabled(false);
        }

        // Phương thức tạo hàng thiết lập, trả về TextBox cho các trường
        private TextBox CreateSettingRow(string labelText, string textBoxText, int yPosition)
        {
            Label label = new Label();
            label.Text = labelText;
            label.Font = new Font("Segoe UI", 12);
            label.AutoSize = true;
            label.Location = new Point(50, yPosition);
            this.Controls.Add(label);

            TextBox textBox = new TextBox();
            textBox.Text = textBoxText;
            textBox.Font = new Font("Segoe UI", 12);
            textBox.Size = new Size(250, 30);
            textBox.Location = new Point(250, yPosition - 5);
            textBox.Enabled = false; // Ban đầu các TextBox bị khóa
            this.Controls.Add(textBox);

            return textBox;
        }

        // Sự kiện khi nhấn nút Save
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Chuyển đổi dữ liệu từ TextBox
                TimeSpan minFlightTime = TimeSpan.Parse(txtMinFlightTime.Text);
                int maxTransit = int.Parse(txtMaxTransit.Text);
                TimeSpan minTransitTime = TimeSpan.Parse(txtMinTransitTime.Text);
                TimeSpan maxTransitTime = TimeSpan.Parse(txtMaxTransitTime.Text);
                int latestBookingTime = int.Parse(txtLatestBookingTime.Text);
                int latestCancelingTime = int.Parse(txtLatestCancelingTime.Text);

                // Gọi BUS để lưu dữ liệu
                bool result = restrictionsBUS.SaveRestrictions(minFlightTime, maxTransit, minTransitTime, maxTransitTime, latestBookingTime, latestCancelingTime);

                if (result)
                {
                    MessageBox.Show("Dữ liệu đã được lưu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Lỗi khi lưu dữ liệu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Sự kiện khi nhấn nút Reset
        private void btnReset_Click(object sender, EventArgs e)
        {
            txtMinFlightTime.Text = "0";
            txtMaxTransit.Text = "0";
            txtMinTransitTime.Text = "0:00:00";
            txtMaxTransitTime.Text = "0:00:00";
            txtLatestBookingTime.Text = "0";
            txtLatestCancelingTime.Text = "0";
        }

        // Sự kiện khi nhấn nút Chỉnh sửa
        private void btnEdit_Click(object sender, EventArgs e)
        {
            SetTextBoxEnabled(true); // Cho phép chỉnh sửa các ô nhập liệu
        }

        // Phương thức bật/tắt trạng thái nhập liệu của các TextBox
        private void SetTextBoxEnabled(bool enabled)
        {
            txtMinFlightTime.Enabled = enabled;
            txtMaxTransit.Enabled = enabled;
            txtMinTransitTime.Enabled = enabled;
            txtMaxTransitTime.Enabled = enabled;
            txtLatestBookingTime.Enabled = enabled;
            txtLatestCancelingTime.Enabled = enabled;
        }
    }
}
