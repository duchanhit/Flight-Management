using BUS;
using BUS.Service;
using DTO.Entities;
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

        private void BindGrid(List<Flight> listFlight)
        {
            dgvFlight.Rows.Clear();
            foreach (var item in listFlight)
            {
                int index = dgvFlight.Rows.Add();
                dgvFlight.Rows[index].Cells[0].Value = item.OriginAP;
                dgvFlight.Rows[index].Cells[1].Value = item.DestinationAP;
                dgvFlight.Rows[index].Cells[2].Value = item.Price;

                // Kiểm tra nếu Duration có giá trị, nếu có thì định dạng đến giây
                dgvFlight.Rows[index].Cells[3].Value = item.Duration.HasValue
                    ? item.Duration.Value.ToString(@"hh\:mm\:ss")
                    : ""; // Nếu không có giá trị, để trống hoặc giá trị khác nếu muốn

                dgvFlight.Rows[index].Cells[4].Value = item.TotalSeat;
            }
        }

        private void InitializeDataGridView()
        {
            dgvFlight.ColumnHeadersVisible = true;
            dgvFlight.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvFlight.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgvFlight.ColumnHeadersHeight = 20; // Chiều cao tiêu đề cột
            CreateFlightGridColumns();
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

        private void CreateFlightGridColumns()
        {
            dgvFlight.Columns.Clear();

            dgvFlight.Columns.Add("OriginAP", "Khởi Hành");
            dgvFlight.Columns.Add("DestinationAP", "Kết Thúc");
            dgvFlight.Columns.Add("Price", "Giá (VNĐ)");
            dgvFlight.Columns.Add("Duration", "Giờ Khởi Hành");
            dgvFlight.Columns.Add("TotalSeat", "Số Ghế");
        }

        private void LoadData()
        {
            List<Flight> listFlight = _flightBUS.GetAllFlights().ToList();
            BindGrid(listFlight);
        }

        #endregion

        #region Events
        private void SchedulingControl_Load(object sender, EventArgs e)
        {
            InitializeDataGridView(); // Tạo các cột trước
            List<Flight> listFlight = _flightBUS.GetAllFlights().ToList();
            BindGrid(listFlight);
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
                    Duration = dtpDuration.Value.TimeOfDay
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

                // Hiển thị thông báo lỗi bằng ShowAutoCloseMessage
                ShowAutoCloseMessage(errorMessage, 3000);
            }





        }

        #endregion


    }
}
