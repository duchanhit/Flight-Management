using BUS.Service;
using DTO.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.UI
{
    public partial class AirplantTransit : Form
    {
        public AirplantTransit()
        {
            InitializeComponent();

        }

        private void InitializeTextBox()
        {
            txtTime.BorderThickness = 0;
            txtTime.FillColor = Color.White; // Nền trắng
            txtTime.ForeColor = Color.Black; // Chữ đen
            txtTime.PlaceholderText = "1:00"; // Văn bản mẫu (placeholder)
            txtTime.PlaceholderForeColor = Color.Black; // Màu placeholder
        }

        private Guna.UI2.WinForms.Guna2Panel CreateUnderlinePanel()
        {
            Guna.UI2.WinForms.Guna2Panel underlinePanel = new Guna.UI2.WinForms.Guna2Panel();
            underlinePanel.Height = 2; // Chiều cao viền
            underlinePanel.Dock = DockStyle.Bottom;
            underlinePanel.FillColor = Color.Black; // Màu đen cho viền dưới
            return underlinePanel;
        }

        private void AddUnderlineToTextBox()
        {
            Guna.UI2.WinForms.Guna2Panel underlinePanel = CreateUnderlinePanel();
            txtTime.Controls.Add(underlinePanel); // Thêm viền dưới vào TextBox
        }

        private void AirplantTransit_Load(object sender, EventArgs e)
        {
            InitializeTextBox();
            AddUnderlineToTextBox();





        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Tạo đối tượng Transit từ dữ liệu người dùng nhập vào form
            Transit transit = new Transit
            {
                transitID = Guid.NewGuid().ToString(),
                flightID = cmbAirport.SelectedValue.ToString(),
                airportID = cmbAirport.SelectedValue.ToString(),
                transitOrder = int.TryParse(txtTransitOrder.Text, out int order) ? order : (int?)null,
                transitTime = TimeSpan.TryParse(txtTransitTime.Text, out TimeSpan time) ? time : (TimeSpan?)null,
                transitNote = txtTransitNote.Text,
                isActive = 1
            };

            // Gọi phương thức SaveTransit từ BUS
            bool isSaved = _transitBUS.SaveTransit(transit);

            // Hiển thị thông báo thành công hoặc thất bại
            if (isSaved)
            {
                MessageBox.Show("Lưu thông tin trung chuyển thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Lưu thất bại. Vui lòng kiểm tra lại dữ liệu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }
    }
}
