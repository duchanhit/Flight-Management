using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS.Service;
using DTO.Entities;
using GUI.UI;

namespace GUI.Control
{
    public partial class SellTicketControl : UserControl
    {
        private readonly TicketBUS _ticketBUS;

        public SellTicketControl()
        {
            InitializeComponent();
            _ticketBUS = new TicketBUS();
        }

        private void btnTaoVe_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra nếu các TextBox có dữ liệu đầy đủ
                if (!AreAllFieldsFilled())
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Lấy dữ liệu từ các ô nhập liệu
                DateTime ngayBay = dtpNgayBay.Value;
                string tuyenBay = txtTuyenBay.Text.Trim();
                string choNgoi = txtChoNgoi.Text.Trim();
                decimal thanhTien = decimal.Parse(txtThanhTien.Text.Trim());
                string tenKhachHang = txtTenKhachHang.Text.Trim();
                string soCCCD = txtSoCCCD.Text.Trim();
                string soDienThoai = txtSDT.Text.Trim();

                // Tạo đối tượng Passenger (hành khách)
                Passenger passenger = new Passenger
                {
                    PassengerId = Guid.NewGuid().ToString(),
                    PassengerName = tenKhachHang,
                    PassengerIDCard = soCCCD,
                    PassenserTel = soDienThoai
                };

                // Tạo đối tượng Ticket (vé)
                Ticket ticket = new Ticket
                {
                    TicketId = Guid.NewGuid().ToString(),
                    TicketIDPassenger = passenger.PassengerId,
                    ClassId = "ECONOMY", // ID hạng vé, có thể thay đổi theo tùy chọn của bạn
                    FlightId = tuyenBay,
                    timeFlight = ngayBay,
                    TimeBooking = DateTime.Now,
                    isPaid = 1 // Đặt trạng thái đã thanh toán (1)
                };


                ChairBooked chairBooked = new ChairBooked
                {


                };

                // Gọi TicketBUS để lưu vé và hành khách vào cơ sở dữ liệu
                _ticketBUS.AddTicket(ticket, passenger);

                MessageBox.Show("Tạo vé thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearInputFields(); // Xóa dữ liệu sau khi lưu
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool AreAllFieldsFilled()
        {
            return !string.IsNullOrWhiteSpace(txtTuyenBay.Text) &&
                   !string.IsNullOrWhiteSpace(txtChoNgoi.Text) &&
                   !string.IsNullOrWhiteSpace(txtThanhTien.Text) &&
                   !string.IsNullOrWhiteSpace(txtTenKhachHang.Text) &&
                   !string.IsNullOrWhiteSpace(txtSoCCCD.Text) &&
                   !string.IsNullOrWhiteSpace(txtSDT.Text);
        }

        // Phương thức xóa tất cả các trường sau khi lưu thành công
        private void ClearInputFields()
        {
            txtTuyenBay.Clear();
            txtChoNgoi.Clear();
            txtThanhTien.Clear();
            txtTenKhachHang.Clear();
            txtSoCCCD.Clear();
            txtSDT.Clear();
        }
        private void btnChonChoNgoi_Click(object sender, EventArgs e)
        {
            DatChoNgoi formDatCho = new DatChoNgoi();
            formDatCho.ShowDialog();
        }
        private void btnChonTuyenBay_Click(object sender, EventArgs e)
        {
            // Tạo instance của form TuyenBay
            TuyenBay formTuyenBay = new TuyenBay();

            // Hiển thị form dưới dạng dialog
            if (formTuyenBay.ShowDialog() == DialogResult.OK)
            {
                // Nếu người dùng đã chọn một FlightId, lấy giá trị từ SelectedFlightId của formTuyenBay
                txtTuyenBay.Text = formTuyenBay.SelectedFlightId;
            }
        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            Form parentForm = this.FindForm();
            if (parentForm != null)
            {
                parentForm.WindowState = FormWindowState.Minimized;
            }
        }
    }
}

