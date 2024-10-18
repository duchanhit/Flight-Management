using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class FlightBUS
    {
        private FlightDAL flightDAL = new FlightDAL();

        public List<Flight> GetAllFlights()
        {
            // Xử lý logic nghiệp vụ nếu cần, ví dụ kiểm tra điều kiện
            return flightDAL.GetAllFlights();
        }

        public Flight GetFlightById(int flightId)
        {
            return flightDAL.GetFlightById(flightId);
        }

        public void AddFlight(Flight flight)
        {
            // Kiểm tra dữ liệu đầu vào trước khi thêm chuyến bay
            flightDAL.AddFlight(flight);
        }

        public void UpdateFlight(Flight flight)
        {
            flightDAL.UpdateFlight(flight);
        }

        public void DeleteFlight(int flightId)
        {
            flightDAL.DeleteFlight(flightId);
        }
    }

}
