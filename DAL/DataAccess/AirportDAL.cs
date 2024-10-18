using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class AirportDAL
    {
        // Lấy tất cả các sân bay từ cơ sở dữ liệu
        public List<Airport> GetAllAirports()
        {
            return new List<Airport>();
        }

        // Lấy thông tin sân bay theo ID
        public Airport GetAirportById(int airportId)
        {
           
        }

        // Thêm sân bay mới vào cơ sở dữ liệu
        public void AddAirport(Airport airport)
        {
            // Thực hiện câu lệnh SQL để thêm sân bay
        }

        // Cập nhật thông tin sân bay
        public void UpdateAirport(Airport airport)
        {
            // Thực hiện câu lệnh SQL để cập nhật sân bay
        }

        // Xóa sân bay khỏi cơ sở dữ liệu
        public void DeleteAirport(int airportId)
        {
            // Thực hiện câu lệnh SQL để xóa sân bay
        }
    }

}
