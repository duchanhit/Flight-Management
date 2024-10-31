
using DTO;
using DTO.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class PassengerDAL 
    {
        // Lấy tất cả hành khách từ cơ sở dữ liệu
        public IEnumerable<Passenger> GetAll()
        {
            using (FlightModel context = new FlightModel())
            {
                return context.Passengers.ToList();
            }
        }

        // Lấy thông tin hành khách theo ID từ cơ sở dữ liệu
        public Passenger GetById(int passengerId)
        {
            using (FlightModel context = new FlightModel())
            {
                string passengerIdString = passengerId.ToString();
                return context.Passengers.SingleOrDefault(p => p.PassengerId == passengerIdString);
            }
        }

        // Thêm hành khách mới vào cơ sở dữ liệu
        public void Add(Passenger passenger)
        {
            using (FlightModel context = new FlightModel())
            {
                context.Passengers.Add(passenger);
                context.SaveChanges();
            }
        }

        // Cập nhật thông tin hành khách trong cơ sở dữ liệu
        public void Update(Passenger passenger)
        {
            using (FlightModel context = new FlightModel())
            {
                var existingPassenger = context.Passengers.SingleOrDefault(p => p.PassengerId == passenger.PassengerId);
                if (existingPassenger != null)
                {
                    // Cập nhật các thuộc tính cần thiết
                    existingPassenger.PassengerName = passenger.PassengerName;
                    existingPassenger.PassengerIDCard = passenger.PassengerIDCard;
                    existingPassenger.PassenserTel = passenger.PassenserTel;

                    context.SaveChanges();
                }
            }
        }

        // Xóa hành khách khỏi cơ sở dữ liệu
        public void Delete(int passengerId)
        {
            using (FlightModel context = new FlightModel())
            {
                string passengerIdString = passengerId.ToString();
                var passengerToDelete = context.Passengers.SingleOrDefault(p => p.PassengerId == passengerIdString);
                if (passengerToDelete != null)
                {
                    context.Passengers.Remove(passengerToDelete);
                    context.SaveChanges();
                }
            }
        }





    }


}
