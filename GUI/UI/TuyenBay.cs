using BUS;
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
    public partial class TuyenBay : Form
    {
        private FlightBUS _flightBUS;
        private DataTable _flightDataTable;

        public TuyenBay()
        {
            InitializeComponent();
            _flightBUS = new FlightBUS();
            dgvChuyenBay.RowTemplate.Height = 20;
            LoadFlightData();

            // Gắn sự kiện
            txtFlightId.TextChanged += txtTimKiem_TextChanged;
            btnChonChuyenBay.Click += btnChonChuyenBay_Click;
            dgvChuyenBay.SelectionChanged += dgvChuyenBay_SelectionChanged;
        }

        private void LoadFlightData()
        {
            // Lấy dữ liệu từ BUS
            _flightDataTable = _flightBUS.GetFlightsWithAirportNames();
            dgvChuyenBay.DataSource = _flightDataTable;

            // Thiết lập chế độ lựa chọn cho DataGridView
            dgvChuyenBay.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvChuyenBay.MultiSelect = false;

            // Đặt chiều cao hàng mặc định là 20
            dgvChuyenBay.ColumnHeadersHeight = 20;

            // Đổi tên các cột
            dgvChuyenBay.Columns["FlightId"].HeaderText = "Mã Chuyến Bay"; // Đổi tên cột FlightId
            dgvChuyenBay.Columns["OriginAirportName"].HeaderText = "Khởi Hành";
            dgvChuyenBay.Columns["DestinationAirportName"].HeaderText = "Kết Thúc";
            dgvChuyenBay.Columns["Price"].HeaderText = "Giá (VNĐ)";
            dgvChuyenBay.Columns["Duration"].HeaderText = "Giờ Khởi Hành";
            dgvChuyenBay.Columns["TotalSeat"].HeaderText = "Số Ghế";

            // Ẩn cột "DepartureDateTime" nếu tồn tại
            if (dgvChuyenBay.Columns.Contains("DepartureDateTime"))
            {
                dgvChuyenBay.Columns["DepartureDateTime"].Visible = false;
            }

            // Hiển thị Flight ID của dòng đầu tiên nếu có dữ liệu
            if (dgvChuyenBay.Rows.Count > 0)
            {
                dgvChuyenBay.Rows[0].Selected = true; // Chọn dòng đầu tiên
                DataGridViewRow selectedRow = dgvChuyenBay.SelectedRows[0];
                string flightId = selectedRow.Cells["FlightId"].Value.ToString();
                txtFlightId.Text = flightId; // Gán vào txtFlightId
            }
            else
            {
                txtFlightId.Text = string.Empty;
            }
        }



        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            string filterText = txtFlightId.Text.Trim();
            if (!string.IsNullOrEmpty(filterText))
            {
                DataView dv = new DataView(_flightDataTable);
                dv.RowFilter = $"DestinationAirportNames LIKE '%{filterText}%' OR OriginAirportNames LIKE '%{filterText}%'";
                dgvChuyenBay.DataSource = dv;
            }
            else
            {
                dgvChuyenBay.DataSource = _flightDataTable;
            }
        }

        public string SelectedFlightId { get; private set; } // Thuộc tính để lưu FlightId đã chọn

        private void btnChonChuyenBay_Click(object sender, EventArgs e)
        {
            if (dgvChuyenBay.SelectedRows.Count > 0)
            {
                // Lấy dòng được chọn trong DataGridView
                DataGridViewRow selectedRow = dgvChuyenBay.SelectedRows[0];

                // Lấy giá trị của FlightId từ dòng được chọn và lưu vào thuộc tính SelectedFlightId
                SelectedFlightId = selectedRow.Cells["FlightId"].Value.ToString();

                // Đóng form với DialogResult.OK để báo hiệu rằng người dùng đã chọn một chuyến bay
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một chuyến bay.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private void dgvChuyenBay_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra xem có dòng nào được chọn trong DataGridView không
                if (dgvChuyenBay.SelectedRows.Count > 0)
                {
                    // Lấy dòng đang được chọn
                    DataGridViewRow selectedRow = dgvChuyenBay.SelectedRows[0];

                    // Lấy giá trị của FlightId từ cột tương ứng
                    string flightId = selectedRow.Cells["FlightId"].Value.ToString();

                    // Gán giá trị vào TextBox để hiển thị FlightId
                    txtFlightId.Text = flightId; // Hiển thị trong txtFlightId
                }
                else
                {
                    // Xóa dữ liệu trong TextBox nếu không có dòng nào được chọn
                    txtFlightId.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                // Ghi log lỗi vào bảng điều khiển
                Console.WriteLine($"Lỗi khi lấy thông tin chuyến bay: {ex.Message}");
            }
        }

        private void TuyenBay_Load(object sender, EventArgs e)
        {
            dgvChuyenBay.ColumnHeadersHeight = 20;
        }
    }
}
