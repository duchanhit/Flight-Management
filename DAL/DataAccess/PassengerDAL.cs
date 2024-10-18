using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class PassengerDAL
    {
        public List<Passenger> GetAllPassengers()
        {
            // Truy xuất tất cả hành khách từ cơ sở dữ liệu
            return new List<Passenger>();

        }

        public Passenger GetPassengerById(int passengerId)
        {
        }

        public void AddPassenger(Passenger passenger)
        {
            // Thêm hành khách mới vào cơ sở dữ liệu
        }

        public void UpdatePassenger(Passenger passenger)
        {
            // Cập nhật thông tin hành khách trong cơ sở dữ liệu
        }

        public void DeletePassenger(int passengerId)
        {
            // Xóa hành khách khỏi cơ sở dữ liệu
        }
    }

}
