using DAL.IAccess;
using DTO;
using DTO.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class TransitDAL : IRepository<Transit>
    {
        public IEnumerable<Transit> GetAll()
        {
            using (FlightModel context = new FlightModel())
            {
                return context.Transits.ToList();
            }
        }

        // Lấy thông tin trạm trung chuyển theo ID
        public Transit GetById(int transitId)
        {
            using (FlightModel context = new FlightModel())
            {
                return context.Transits.SingleOrDefault(t => t.transitID == transitId.ToString());
            }
        }

        // Thêm trạm trung chuyển vào cơ sở dữ liệu
        public void Add(Transit transit)
        {
            using (FlightModel context = new FlightModel())
            {
                context.Transits.Add(transit);
                context.SaveChanges();
            }
        }

        // Cập nhật thông tin trạm trung chuyển
        public void Update(Transit transit)
        {
            using (FlightModel context = new FlightModel())
            {
                var existingTransit = context.Transits.SingleOrDefault(t => t.transitID == transit.transitID.ToString());
                if (existingTransit != null)
                {
                    // Cập nhật các thuộc tính cần thiết
                    existingTransit.flightID = transit.flightID;
                    existingTransit.airportID = transit.airportID;
                    existingTransit.transitOrder = transit.transitOrder;
                    existingTransit.transitTime = transit.transitTime;
                    existingTransit.transitNote = transit.transitNote;
                    existingTransit.isActive = transit.isActive;
                    context.SaveChanges();
                }
            }
        }

        // Xóa trạm trung chuyển khỏi cơ sở dữ liệu
        public void Delete(int transitId)
        {
            using (FlightModel context = new FlightModel())
            {
                var transitToDelete = context.Transits.SingleOrDefault(t => t.transitID == transitId.ToString());
                if (transitToDelete != null)
                {
                    context.Transits.Remove(transitToDelete);
                    context.SaveChanges();
                }
            }
        }

        public bool SaveTransit(Transit transit)
        {
            bool isSaved = false;
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["FlightModel"].ConnectionString))
            {
                // Sử dụng Stored Procedure thay vì câu lệnh SQL trực tiếp
                using (var command = new SqlCommand("InsertTransit", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    // Thêm các tham số cho Stored Procedure
                    command.Parameters.AddWithValue("@transitID", transit.transitID);
                    command.Parameters.AddWithValue("@flightID", transit.flightID);
                    command.Parameters.AddWithValue("@airportID", transit.airportID);
                    command.Parameters.AddWithValue("@transitOrder", (object)transit.transitOrder ?? DBNull.Value);
                    command.Parameters.AddWithValue("@transitTime", (object)transit.transitTime ?? DBNull.Value);
                    command.Parameters.AddWithValue("@transitNote", (object)transit.transitNote ?? DBNull.Value);
                    command.Parameters.AddWithValue("@isActive", (object)transit.isActive ?? DBNull.Value);

                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        isSaved = rowsAffected > 0; // Trả về true nếu có ít nhất một dòng được chèn
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Lỗi khi lưu dữ liệu Transit: " + ex.Message);
                        isSaved = false;
                    }
                }
            }
            return isSaved;
        }


    }

}
