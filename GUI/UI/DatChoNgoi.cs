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
    public partial class DatChoNgoi : Form
    {
        private readonly ChairBookedBUS _chairBookedBUS;
        private readonly List<Button> _seatButtons = new List<Button>();
        private const int Rows = 6;
        private const int Columns = 10;
        private const int SeatWidth = 50;
        private const int SeatHeight = 50;
        private const int Spacing = 5; // Khoảng cách giữa các ghế

        public DatChoNgoi()
        {
            InitializeComponent();
            _chairBookedBUS = new ChairBookedBUS();
            CreateSeats();
        }

        private void CreateSeats()
        {
            TableLayoutPanel tableLayoutPanel = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                RowCount = Rows,
                ColumnCount = Columns,
                CellBorderStyle = TableLayoutPanelCellBorderStyle.Single
            };

            for (int i = 0; i < Columns; i++)
            {
                tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100 / Columns));
            }
            for (int i = 0; i < Rows; i++)
            {
                tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100 / Rows));
            }

            var bookedSeats = _chairBookedBUS.GetAllBookedChairs().ToList();

            for (int row = 0; row < Rows; row++)
            {
                for (int col = 0; col < Columns; col++)
                {
                    Button seatButton = new Button
                    {
                        Width = SeatWidth,
                        Height = SeatHeight,
                        Text = $"{row + 1}-{col + 1}",
                        Tag = $"{row + 1}-{col + 1}",
                        Enabled = true
                    };

                    // Kiểm tra ghế đã được đặt chưa và đặt màu sắc
                    if (bookedSeats.Any(bs => bs.XPos == row + 1 && bs.YPos == col + 1))
                    {
                        seatButton.BackColor = Color.Gray;
                        seatButton.Enabled = false;
                    }
                    else
                    {
                        // Đặt màu sắc cho ghế theo hạng
                        if (row < 3)
                        {
                            seatButton.BackColor = Color.Yellow; // Hạng thương gia
                        }
                        else
                        {
                            seatButton.BackColor = Color.Green; // Hạng thường
                        }
                    }

                    seatButton.Click += SeatButton_Click;
                    tableLayoutPanel.Controls.Add(seatButton, col, row);
                }
            }

            this.Controls.Add(tableLayoutPanel);
        }

        private void SeatButton_Click(object sender, EventArgs e)
        {
            Button selectedButton = (Button)sender;
            string seatTag = selectedButton.Tag.ToString();

            // Hiển thị thông báo hoặc thực hiện hành động khi người dùng chọn ghế
            MessageBox.Show($"Bạn đã chọn ghế: {seatTag}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Lưu ghế được chọn vào cơ sở dữ liệu hoặc thực hiện các hành động khác
            SaveSelectedSeat(seatTag);

            // Đổi màu ghế thành xám để thể hiện ghế đã được đặt
            selectedButton.BackColor = Color.Gray;
            selectedButton.Enabled = false;
        }

        private void SaveSelectedSeat(string seatTag)
        {
            // Chuyển đổi vị trí ghế thành tọa độ
            var position = seatTag.Split('-');
            int xPos = int.Parse(position[0]);
            int yPos = int.Parse(position[1]);

            // Tạo đối tượng ghế đã đặt và lưu vào database qua lớp BUS
            var chairBooked = new ChairBooked
            {
                IDChairBooked = Guid.NewGuid().ToString(),
                XPos = xPos,
                YPos = yPos,
                Time = DateTime.Now, // hoặc thời gian bạn muốn lưu
                FlightId = "YOUR_FLIGHT_ID" // Cập nhật với ID chuyến bay hiện tại
            };

            _chairBookedBUS.AddBookedChair(chairBooked);
        }
    }
}
