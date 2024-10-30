using BUS;
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
        private DataTable ConvertListToDataTable(List<Flight> listFlight)
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Departure", typeof(string));
            dataTable.Columns.Add("Arrival", typeof(string));
            dataTable.Columns.Add("Giá (VNĐ)", typeof(decimal));
            dataTable.Columns.Add("Giờ Khởi Hành", typeof(string));
            dataTable.Columns.Add("Số Ghế", typeof(int));

            foreach (var item in listFlight)
            {
                var row = dataTable.NewRow();
                row["Departure"] = item.OriginAP;
                row["Arrival"] = item.DestinationAP;
                row["Giá (VNĐ)"] = item.Price;
                row["Giờ Khởi Hành"] = item.Duration?.ToString(@"hh\:mm\:ss") ?? "";
                row["Số Ghế"] = item.TotalSeat;
                dataTable.Rows.Add(row);
            }
            return dataTable;
        }
        private void BindGrid(List<Flight> listFlight)
        {
            originalData = ConvertListToDataTable(listFlight);
            dgvFlight.DataSource = originalData;
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


        private void LoadData()
        {
            List<Flight> listFlight = _flightBUS.GetAllFlights().ToList();
            originalData = ConvertListToDataTable(listFlight); 
            dgvFlight.DataSource = originalData;

            if (dgvFlight.Columns["Departure"] != null)
            {
                dgvFlight.Columns["Departure"].HeaderText = "Khởi Hành";
            }
            
            if (dgvFlight.Columns["Arrival"] != null)
            {
                dgvFlight.Columns["Arrival"].HeaderText = "Kết Thúc";
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

            // Sử dụng tên cột không dấu cho bộ lọc
            string filterColumn = selection == "Khởi Hành" ? "Departure" : "Arrival";
            dv.RowFilter = $"{filterColumn} LIKE '%{airportCode}%'";

            dgvFlight.DataSource = dv;
        }


        #endregion

        #region Events
        private void SchedulingControl_Load(object sender, EventArgs e)
        {
            dtpDuration.Format = DateTimePickerFormat.Custom;
            dtpDuration.CustomFormat = "HH:mm:ss";
            fillComboBox();

            InitializeDataGridView(); // Tạo các cột trước

            // Gọi LoadData để tải dữ liệu gốc vào originalData
            LoadData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
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
