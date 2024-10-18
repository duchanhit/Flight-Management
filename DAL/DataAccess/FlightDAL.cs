using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class FlightDAL
    {
        public List<Flight> GetAllFlights()
        {
            // Truy xuất dữ liệu từ cơ sở dữ liệu (dữ liệu giả lập để minh họa)
            return new List<Flight>();
        }

        public Flight GetFlightById(int flightId)
        {
            // Truy xuất thông tin chuyến bay theo ID từ cơ sở dữ liệu
           
        }

        public void AddFlight(Flight flight)
        {
            // Thêm mới chuyến bay vào cơ sở dữ liệu
        }

        public void UpdateFlight(Flight flight)
        {
            // Cập nhật thông tin chuyến bay trong cơ sở dữ liệu
        }

        public void DeleteFlight(int flightId)
        {
            // Xóa chuyến bay khỏi cơ sở dữ liệu
        }
    }

}
