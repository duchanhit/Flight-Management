using BUS;
using BUS.Service;
using DTO.Entities;
using GUI.UI;
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
        private readonly TransitBUS _transitBUS;
        private readonly DefineSizeFlightBUS _defineSizeFlightBUS;
        private DataTable originalData;

        private List<Transit> transitList = new List<Transit>();

        private Queue<string> messageQueue = new Queue<string>();
        private bool isShowingMessage = false;



        #region Methods

        public SchedulingControl()
        {
            InitializeComponent();

            _flightBUS = new FlightBUS();
            _transitBUS = new TransitBUS(); // Initialize _transitBUS
            _defineSizeFlightBUS = new DefineSizeFlightBUS();


            InitializeDataGridView(dgvFlight);
            InitializeDataGridView(dgvTransit);

        }

        private void LoadTransitsForFlight(string flightId)
        {
            // Gọi phương thức GetTransitsByFlightId từ TransitBUS
            List<Transit> transits = _transitBUS.GetTransitsByFlightId(flightId);

            // Cập nhật dữ liệu vào dgvTransit
            dgvTransit.DataSource = null;
            dgvTransit.DataSource = transits;

            // Đổi tên các cột cần hiển thị
            dgvTransit.Columns["airportID"].HeaderText = "Mã Sân Bay";
            dgvTransit.Columns["transitTime"].HeaderText = "Thời Gian Chờ";
            dgvTransit.Columns["transitNote"].HeaderText = "Ghi Chú";

            // Ẩn các cột không cần thiết
            foreach (DataGridViewColumn column in dgvTransit.Columns)
            {
                if (column.Name != "airportID" && column.Name != "transitTime" && column.Name != "transitNote")
                {
                    column.Visible = false;
                }
            }
        }


        private void LoadFlightData()
        {
            try
            {
                
                DataTable flightsTable = _flightBUS.GetFlightsWithAirportNames(); // Adjust this line based on your actual data retrieval method

                // Store the original data to use for filtering and searching
                originalData = flightsTable;

                // Bind the data to dgvFlight
                dgvFlight.DataSource = originalData;

                // Set column headers and widths
                SetColumnHeaders();
                SetColumnWidths(dgvFlight);

                // Hide any unnecessary columns if needed
                HideUnnecessaryColumns();
            }
            catch (Exception ex)
            {
                ShowErrorMessage(ex);
            }
        }


        public void UpdateTransitGrid(List<Tuple<string, TimeSpan?, string>> transitDataList)
        {

            // Xóa danh sách cũ và cập nhật danh sách mới từ dữ liệu truyền vào
            transitList.Clear();
            foreach (var data in transitDataList)
            {
                transitList.Add(new Transit
                {
                    transitID = Guid.NewGuid().ToString(),
                    airportID = data.Item1,
                    transitTime = data.Item2,
                    transitNote = data.Item3,
                    isActive = 1
                });
            }

            // Cập nhật dữ liệu lên dgvTransit
            dgvTransit.DataSource = new BindingSource(transitList, null);

            dgvTransit.Refresh(); // Làm mới DataGridView

            // Đổi tên các cột cần hiển thị
            dgvTransit.Columns["airportID"].HeaderText = "Mã Sân Bay";
            dgvTransit.Columns["transitTime"].HeaderText = "Thời Gian Chờ";
            dgvTransit.Columns["transitNote"].HeaderText = "Ghi Chú";

            // Ẩn tất cả các cột ngoại trừ airportID, transitTime và transitNote
            foreach (DataGridViewColumn column in dgvTransit.Columns)
            {
                if (column.Name != "airportID" && column.Name != "transitTime" && column.Name != "transitNote")
                {
                    column.Visible = false;
                }
            }
        }






        private void btnAddTranSit_Click(object sender, EventArgs e)
        {
            AirplantTransit airplantTransit = new AirplantTransit();
            airplantTransit.TransitListUpdated += UpdateTransitGrid;
            airplantTransit.ShowDialog();
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


        private void InitializeDataGridView(DataGridView dgv)
        {
            dgv.ColumnHeadersVisible = true;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgv.ColumnHeadersHeight = 20;

            // Nếu là dgvTransit, tạo các cột cố định
            if (dgv == dgvTransit)
            {
                dgv.Columns.Clear(); // Xóa tất cả các cột nếu đã tồn tại

                // Thêm cột Mã Sân Bay (airportID)
                DataGridViewTextBoxColumn airportColumn = new DataGridViewTextBoxColumn
                {
                    Name = "airportID",
                    HeaderText = "Mã Sân Bay",
                    DataPropertyName = "airportID" // Thiết lập tên thuộc tính dữ liệu
                };
                dgv.Columns.Add(airportColumn);

                // Thêm cột Thời Gian Trung Chuyển (transitTime) với chiều rộng 150
                DataGridViewTextBoxColumn timeColumn = new DataGridViewTextBoxColumn
                {
                    Name = "transitTime",
                    HeaderText = "Thời Gian Chờ",
                    Width = 150,
                    DataPropertyName = "transitTime"
                };
                dgv.Columns.Add(timeColumn);

                // Thêm cột Ghi Chú (transitNote)
                DataGridViewTextBoxColumn noteColumn = new DataGridViewTextBoxColumn
                {
                    Name = "transitNote",
                    HeaderText = "Ghi Chú",
                    DataPropertyName = "transitNote"
                };
                dgv.Columns.Add(noteColumn);
            }
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

        private void SetColumnWidths(DataGridView dgv)
        {
            if (dgv.Columns["OriginAirportName"] != null)
            {
                dgv.Columns["OriginAirportName"].Width = 125;  // Đặt chiều rộng cho cột Khởi Hành
            }

            if (dgv.Columns["DestinationAirportName"] != null)
            {
                dgv.Columns["DestinationAirportName"].Width = 125;  // Đặt chiều rộng cho cột Kết Thúc
            }

            if (dgv.Columns["DepartureDateTime"] != null)
            {
                dgv.Columns["DepartureDateTime"].Width = 125;
            }
            if (dgv.Columns["transitTime"] != null)
            {
                dgv.Columns["transitTime"].Width = 150;
            }
            if (dgv.Columns["TotalSeat"] != null)
            {
                dgv.Columns["TotalSeat"].Width = 150;
            }
        }

        private void LoadData()
        {
            SetColumnHeaders();

            SetColumnWidths(dgvFlight);


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
            if (dgvFlight.Columns["DepartureDateTime"] != null)
            {
                dgvFlight.Columns["DepartureDateTime"].Visible = false;
            }
            if (dgvFlight.Columns["SeatWidth"] != null)
            {
                dgvFlight.Columns["SeatWidth"].Visible = false;
            }
            if (dgvFlight.Columns["SeatHeight"] != null)
            {
                dgvFlight.Columns["SeatHeight"].Visible = false;
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

            if (!AreSeatsValid())
            {
                return false;
            }

            return true;
        }

        public void UpdateTransitGrid(List<Transit> transitList)
        {
            dgvTransit.DataSource = null;
            dgvTransit.DataSource = transitList;
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
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra các trường nhập liệu
                if (!IsInputValid())
                {
                    return;
                }


                Flight newFlight = new Flight
                {
                    FlightId = Guid.NewGuid().ToString(),
                    Price = decimal.Parse(txtPrice.Text.Trim()),
                    OriginAP = txtOriginAP.Text.Trim(),
                    DestinationAP = txtDestinationAP.Text.Trim(),
                    TotalSeat = int.Parse(txtHeight.Text.Trim()) * int.Parse(txtWeight.Text.Trim()),
                    isActive = 1,
                    Duration = dtpDuration.Value.TimeOfDay, // Lấy phần thời gian từ DateTimePicker
                    DepartureDateTime = null,
                };

                DefineSizeFlight newDefineSizeFlight = new DefineSizeFlight
                {
                    IdFlight = newFlight.FlightId,
                    width = int.Parse(txtWeight.Text.Trim()),
                    height = int.Parse(txtHeight.Text.Trim())
                };


                // Cập nhật FlightId cho tất cả transit trong danh sách
                foreach (var transit in transitList)
                {
                    transit.flightID = newFlight.FlightId;
                }

                // Lưu chuyến bay và danh sách transit
                _flightBUS.AddFlight(newFlight);
                foreach (var transit in transitList)
                {
                    _transitBUS.AddTransit(transit);
                }
                _defineSizeFlightBUS.AddDefineSizeFlight(newDefineSizeFlight);
                ShowAutoCloseMessage("Lưu dữ liệu thành công!", 1500);
                ClearInput();
                LoadData();
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"SQL Error: {ex.Message}");
                // Log thêm thông tin nếu cần
            }
        }


        private void txtFind_TextChanged(object sender, EventArgs e)
        {
            string airportCode = txtFind.Text.Trim();
            string selection = cmbOriginDestination.SelectedItem?.ToString();
            FilterDataGridView(selection, airportCode);
        }
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

        private void SchedulingControl_Load(object sender, EventArgs e)
        {
            // Cấu hình các DateTimePicker khác nếu cần
            dtpDuration.Format = DateTimePickerFormat.Custom;
            dtpDuration.CustomFormat = "HH:mm:ss";



            fillComboBox();
            InitializeDataGridView(dgvFlight);
            InitializeDataGridView(dgvTransit);
            LoadData();
            LoadFlightData();

            // Thêm sự kiện CellClick cho dgvFlight
            dgvFlight.CellClick += dgvFlight_CellClick;
        }
        private void dgvFlight_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Kiểm tra nếu hàng được chọn hợp lệ
            {
                try
                {
                    // Lấy dòng hiện tại mà người dùng click vào
                    DataGridViewRow selectedRow = dgvFlight.Rows[e.RowIndex];

                    // Gán dữ liệu từ các cột của DataGridView vào các TextBox theo đúng tên cột
                    txtOriginAP.Text = selectedRow.Cells["OriginAP"].Value?.ToString(); // Binding OriginAirportName vào txtOriginAP
                    txtDestinationAP.Text = selectedRow.Cells["DestinationAP"].Value?.ToString(); // Binding DestinationAirportName vào txtDestinationAP
                    txtWeight.Text = selectedRow.Cells["SeatWidth"].Value?.ToString(); // Binding SeatWidth (số ghế ngang) vào txtWeight
                    txtHeight.Text = selectedRow.Cells["SeatHeight"].Value?.ToString(); // Binding SeatHeight (số ghế dọc) vào txtHeight

                    // Kiểm tra và gán giá trị cho Duration nếu có
                    if (TimeSpan.TryParse(selectedRow.Cells["Duration"].Value?.ToString(), out TimeSpan duration))
                    {
                        dtpDuration.Value = DateTime.Today.Add(duration); // Gán TimeSpan vào DateTimePicker
                    }
                    else
                    {
                        dtpDuration.Value = DateTime.Today; // Gán giá trị mặc định nếu không hợp lệ
                    }

                    // Gán giá trị cho giá tiền (Price)
                    txtPrice.Text = selectedRow.Cells["Price"].Value?.ToString();

                    // Lấy FlightId từ dòng đã chọn và gọi phương thức LoadTransitsForFlight
                    string flightId = selectedRow.Cells["FlightId"].Value?.ToString();
                    if (!string.IsNullOrEmpty(flightId))
                    {
                        LoadTransitsForFlight(flightId); // Hiển thị danh sách transit của chuyến bay
                    }
                }
                catch (Exception ex)
                {
                    ShowErrorMessage(ex);
                }
            }

        }
        #endregion
        private void guna2HtmlLabel6_Click(object sender, EventArgs e)
        {

        }

        private void dtpDuration_ValueChanged(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel3_Click(object sender, EventArgs e)
        {

        }

        private void MiniMize_Click(object sender, EventArgs e)
        {
            Form parentForm = this.FindForm();
            if (parentForm != null)
            {
                parentForm.WindowState = FormWindowState.Minimized;
            }
        }
    }
}


