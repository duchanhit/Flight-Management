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

namespace GUI.Control
{
    public partial class ReportControl : UserControl
    {
        private readonly RevenueBUS _revenueBUS;
        private DataTable originalData; // Lưu trữ dữ liệu gốc
        #region #Methods
        public ReportControl()
        {
            InitializeComponent();
            _revenueBUS = new RevenueBUS();
            InitializeDataGridView(dgvMonthRevenue);
            InitializeDataGridView(dgvYearRevenue);

        }

        private void ReportControl_Load(object sender, EventArgs e)
        {

                dtpMonthRevenue.CustomFormat = "MM/yyyy";
                dtpMonthRevenue.ShowUpDown = true;
                dtpYearRevenue.CustomFormat = "yyyy";
                dtpYearRevenue.ShowUpDown = true;

                // Gọi LoadDataToGridView để tải dữ liệu tháng mặc định
                LoadDataToGridView();

                // Gọi dtpYearRevenue_ValueChanged để tự động tải dữ liệu theo năm hiện tại
                dtpYearRevenue.Value = DateTime.Now; // Đặt năm hiện tại
                dtpYearRevenue_ValueChanged(null, null); // Gọi sự kiện để tải dữ liệu cho dgvYearRevenue


        }
        private void SetColumnHeaders(DataGridView dgv)
        {
            dgv.Columns["DepartureAirport"].HeaderText = "Chuyến bay";
            dgv.Columns["ArrivalAirport"].HeaderText = "Điểm đến";
            dgv.Columns["TotalFlights"].HeaderText = "Số chuyến bay (chuyến)";
            dgv.Columns["TotalRevenue"].HeaderText = "Doanh Thu (VNĐ)";
            dgv.Columns["RevenuePercentage"].HeaderText = "Tỷ lệ (%)";
        }
        private void SetColumnWidths(DataGridView dgv)
        {
            if (dgv.Columns.Contains("DepartureAirport"))
            {
                dgv.Columns["DepartureAirport"].Width = 175; // Kéo dài cột Chuyến bay
            }

            if (dgv.Columns.Contains("ArrivalAirport"))
            {
                dgv.Columns["ArrivalAirport"].Width = 175; // Kéo dài cột Điểm đến
            }
        }

        private void LoadDataToGridView()
        {
            // Tải dữ liệu gốc và lưu vào originalData
            originalData = _revenueBUS.LoadRevenueReport();
            dgvMonthRevenue.DataSource = originalData;

            // Ẩn cột "FlightMonthYear"
            if (dgvMonthRevenue.Columns["FlightMonthYear"] != null)
            {
                dgvMonthRevenue.Columns["FlightMonthYear"].Visible = false;
            }

            SetColumnHeaders(dgvMonthRevenue);
            SetColumnWidths(dgvMonthRevenue);
            dgvYearRevenue.DataSource = originalData;
        }


        private void InitializeDataGridView(DataGridView dgv)
        {
            dgv.ColumnHeadersVisible = true;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgv.ColumnHeadersHeight = 20; // Chiều cao tiêu đề cột      
        }





        #endregion

        #region Events
        private void dtpMonthRevenue_ValueChanged(object sender, EventArgs e)
        {
            // Lấy giá trị tháng-năm từ DateTimePicker dưới dạng chuỗi "MM-yyyy"
            string selectedMonthYear = dtpMonthRevenue.Value.ToString("MM-yyyy");

            // Kiểm tra nếu originalData có dữ liệu để lọc
            if (originalData != null)
            {
                DataView dv = new DataView(originalData);
                // Áp dụng bộ lọc cho DataView theo cột "FlightMonthYear"
                dv.RowFilter = $"FlightMonthYear = '{selectedMonthYear}'";

                // Gán DataView đã lọc vào DataGridView
                dgvMonthRevenue.DataSource = dv;
            }
        }


        private void dtpYearRevenue_ValueChanged(object sender, EventArgs e)
        {
            // Lấy giá trị năm từ DateTimePicker
            int selectedYear = dtpYearRevenue.Value.Year;

            // Tải dữ liệu theo năm từ RevenueBUS và hiển thị trong DataGridView
            DataTable revenueDataByYear = _revenueBUS.LoadRevenueReportByYear(selectedYear);
            dgvYearRevenue.DataSource = revenueDataByYear;

            // Đổi tên các cột cho phù hợp
            dgvYearRevenue.Columns["Tháng"].HeaderText = "Tháng";
            dgvYearRevenue.Columns["Số chuyến bay"].HeaderText = "Số chuyến bay (chuyến)";
            dgvYearRevenue.Columns["Lợi nhuận (VNĐ)"].HeaderText = "Doanh Thu (VNĐ)";
            dgvYearRevenue.Columns["Tỷ lệ (%)"].HeaderText = "Tỷ lệ (%)";
        }
        #endregion


    }
}
