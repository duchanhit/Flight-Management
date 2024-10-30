﻿using BUS;
using BUS.Service;
using DTO.Entities;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace GUI.Control
{
    public partial class SchedulingControl : UserControl
    {
        private readonly FlightBUS _flightBUS;
        private readonly DefineSizeFlightBUS _defineSizeFlightBUS;
        private DataTable originalData;

        private Queue<string> messageQueue = new Queue<string>();
        private bool isShowingMessage = false;

        #region Methods

        public SchedulingControl()
        {
            InitializeComponent();
            _flightBUS = new FlightBUS();
            _defineSizeFlightBUS = new DefineSizeFlightBUS();
            InitializeDataGridView();
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
                ShowNextMessage(duration); 
            };

            messageForm.Show();
            timer.Start();
        }


        private void InitializeDataGridView()
        {
            dgvFlight.ColumnHeadersVisible = true;
            dgvFlight.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvFlight.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgvFlight.ColumnHeadersHeight = 20;


        }
        private void ClearInput()
        {
            txtDestinationAP.Clear();
            txtOriginAP.Clear();
            txtHeight.Clear();
            txtWeight.Clear();
            txtOriginAP.Clear();
            txtPrice.Clear();
        }

        private void SetColumnWidths()
        {
            if (dgvFlight.Columns["OriginAirportName"] != null)
            {
                dgvFlight.Columns["OriginAirportName"].Width = 125;  // Đặt chiều rộng cho cột Khởi Hành
            }

            if (dgvFlight.Columns["DestinationAirportName"] != null)
            {
                dgvFlight.Columns["DestinationAirportName"].Width = 125;  // Đặt chiều rộng cho cột Kết Thúc
            }

            if (dgvFlight.Columns["DepartureDateTime"] != null)
            {
                dgvFlight.Columns["DepartureDateTime"].Width = 125;
            }
        }

        private void LoadData()
        {
            // Lấy DataTable từ view với tên sân bay khởi hành và kết thúc
            DataTable flightsTable = _flightBUS.GetFlightsWithAirportNames();

            // Thêm cột mã sân bay để tìm kiếm theo mã sân bay
            flightsTable.Columns.Add("OriginAP", typeof(string));
            flightsTable.Columns.Add("DestinationAP", typeof(string));

            foreach (DataRow row in flightsTable.Rows)
            {
                row["OriginAP"] = _flightBUS.GetAirportCodeByName(row["OriginAirportName"].ToString());
                row["DestinationAP"] = _flightBUS.GetAirportCodeByName(row["DestinationAirportName"].ToString());

                // Định dạng cột Duration theo hh:mm:ss
                if (TimeSpan.TryParse(row["Duration"].ToString(), out TimeSpan duration))
                {
                    row["Duration"] = duration.ToString(@"hh\:mm\:ss");
                }
            }

            // Lưu lại dữ liệu gốc để phục vụ cho tìm kiếm
            originalData = flightsTable;
            dgvFlight.DataSource = flightsTable;

            SetColumnHeaders();

            SetColumnWidths();

            HideUnnecessaryColumns();
        }


        private void SetColumnHeaders()
        {
            SetColumnHeader("OriginAirportName", "Khởi Hành");
            SetColumnHeader("DestinationAirportName", "Kết Thúc");
            SetColumnHeader("Price", "Giá");
            SetColumnHeader("Duration", "Thời lượng");
            SetColumnHeader("TotalSeat", "Số Ghế");
            SetColumnHeader("DepartureDateTime", "Ngày Khởi Hành");
        }

        private void SetColumnHeader(string columnName, string headerText)
        {
            if (dgvFlight.Columns[columnName] != null)
            {
                dgvFlight.Columns[columnName].HeaderText = headerText;
            }
        }

        private void HideUnnecessaryColumns()
        {
            if (dgvFlight.Columns["FlightId"] != null)
            {
                dgvFlight.Columns["FlightId"].Visible = false;
            }
            if (dgvFlight.Columns["OriginAP"] != null)
            {
                dgvFlight.Columns["OriginAP"].Visible = false;
            }
            if (dgvFlight.Columns["DestinationAP"] != null)
            {
                dgvFlight.Columns["DestinationAP"].Visible = false;
            }
        }


        private void fillComboBox()
        {
            cmbOriginDestination.Items.Clear(); 
            cmbOriginDestination.Items.Add("Khởi Hành");
            cmbOriginDestination.Items.Add("Kết Thúc");

            cmbOriginDestination.SelectedIndex = 0; 

        }

        private void FilterDataGridView(string selection, string airportCode)
        {
            if (string.IsNullOrEmpty(airportCode))
            {
                dgvFlight.DataSource = originalData;
                return;
            }

            DataView dv = new DataView(originalData);

            // Chọn cột tìm kiếm dựa trên lựa chọn "Khởi Hành" hay "Kết Thúc"
            string filterColumn = selection == "Khởi Hành" ? "OriginAP" : "DestinationAP";
            dv.RowFilter = $"{filterColumn} LIKE '%{airportCode}%'";

            dgvFlight.DataSource = dv;
        }

        // Phương thức kiểm tra tính hợp lệ của đầu vào
        private bool IsInputValid()
        {
            if (IsAnyFieldEmpty())
            {
                ShowAutoCloseMessage("Vui lòng nhập đầy đủ thông tin!", 3000);
                return false;
            }

            if (dtpDuration.Value == null || dtpDuration.Value == DateTime.MinValue)
            {
                ShowAutoCloseMessage("Giờ Bay không được để trống!", 3000);
                return false;
            }

            if (!AreSeatsValid())
            {
                return false;
            }

            return true;
        }


        // Phương thức kiểm tra các trường nhập liệu không được để trống
        private bool IsAnyFieldEmpty()
        {
            return string.IsNullOrWhiteSpace(txtPrice.Text) ||
                   string.IsNullOrWhiteSpace(txtOriginAP.Text) ||
                   string.IsNullOrWhiteSpace(txtDestinationAP.Text) ||
                   string.IsNullOrWhiteSpace(txtHeight.Text) ||
                   string.IsNullOrWhiteSpace(txtWeight.Text);
        }

        // Phương thức kiểm tra các trường ghế ngang và ghế dọc chỉ chứa số và lớn hơn 0
        private bool AreSeatsValid()
        {
            // Kiểm tra ghế ngang
            if (!int.TryParse(txtWeight.Text.Trim(), out int height))
            {
                ShowAutoCloseMessage("Ghế ngang chỉ có thể nhập số!", 3000);
                return false;
            }
            else if (height <= 0)
            {
                ShowAutoCloseMessage("Ghế ngang phải lớn hơn 0!", 3000);
                return false;
            }

            // Kiểm tra ghế dọc
            if (!int.TryParse(txtHeight.Text.Trim(), out int weight))
            {
                ShowAutoCloseMessage("Ghế dọc chỉ có thể nhập số!", 3000);
                return false;
            }
            else if (weight <= 0)
            {
                ShowAutoCloseMessage("Ghế dọc phải lớn hơn 0!", 3000);
                return false;
            }

            return true;
        }

        // Phương thức hiển thị lỗi chi tiết
        private void ShowErrorMessage(Exception ex)
        {
            // Lấy thông báo lỗi sâu nhất
            string errorMessage = ex.Message;
            Exception inner = ex.InnerException;

            // Duyệt qua tất cả các lớp InnerException để lấy thông báo cuối cùng
            while (inner != null)
            {
                errorMessage = inner.Message;
                inner = inner.InnerException;
            }

            // Nếu thông báo chứa phần không cần thiết, hãy cắt bỏ
            if (errorMessage.Contains("The transaction ended in the trigger"))
            {
                int index = errorMessage.IndexOf("The transaction ended in the trigger");
                errorMessage = errorMessage.Substring(0, index).Trim();
            }

            ShowAutoCloseMessage(errorMessage, 3000);
        }
        #endregion

        #region Events
        private void SchedulingControl_Load(object sender, EventArgs e)
        {
            dtpDuration.Format = DateTimePickerFormat.Custom;
            dtpDuration.CustomFormat = "HH:mm:ss"; 
            fillComboBox();

            InitializeDataGridView(); 

            LoadData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra các trường nhập liệu
                if (!IsInputValid())
                {
                    return;
                }

                // Tạo đối tượng chuyến bay mới
                var newFlight = new Flight
                {
                    FlightId = Guid.NewGuid().ToString(),
                    Price = decimal.Parse(txtPrice.Text.Trim()),
                    OriginAP = txtOriginAP.Text.Trim(),
                    DestinationAP = txtDestinationAP.Text.Trim(),
                    TotalSeat = int.Parse(txtHeight.Text.Trim()) * int.Parse(txtWeight.Text.Trim()),
                    isActive = 1,
                    Duration = dtpDuration.Value.TimeOfDay,
                    DepartureDateTime = dtpDepartureDate.Value,
                };

                // Gọi qua BUS để thêm chuyến bay vào cơ sở dữ liệu
                _flightBUS.AddFlight(newFlight);

                ShowAutoCloseMessage("Lưu dữ liệu thành công!", 1500);
                ClearInput();
                LoadData();
            }
            catch (Exception ex)
            {
                ShowErrorMessage(ex);
            }
        }


        private void txtFind_TextChanged(object sender, EventArgs e)
        {
            string airportCode = txtFind.Text.Trim();
            string selection = cmbOriginDestination.SelectedItem?.ToString();
            FilterDataGridView(selection, airportCode);
        }


        #endregion

        private void btnReload_Click(object sender, EventArgs e)
        {

            LoadData();
  
            txtFind.Clear();

            cmbOriginDestination.SelectedIndex = 0;
        }

        private void btnDeleteFlight_Click(object sender, EventArgs e)
        {

            txtFind.Clear();

            dgvFlight.DataSource = originalData;
        }
    }
}
