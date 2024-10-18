using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class TransitDAL
    {
        // Lấy tất cả các trạm trung chuyển từ cơ sở dữ liệu
        public List<Transit> GetAllTransits()
        {
            return new List<Transit>();
        }

        // Lấy thông tin trạm trung chuyển theo ID
        public Transit GetTransitById(int transitId)
        {
        }

        // Thêm trạm trung chuyển vào cơ sở dữ liệu
        public void AddTransit(Transit transit)
        {
            // Thực hiện câu lệnh SQL để thêm trạm trung chuyển
        }

        // Cập nhật thông tin trạm trung chuyển
        public void UpdateTransit(Transit transit)
        {
            // Thực hiện câu lệnh SQL để cập nhật thông tin
        }

        // Xóa trạm trung chuyển khỏi cơ sở dữ liệu
        public void DeleteTransit(int transitId)
        {
            // Thực hiện câu lệnh SQL để xóa trạm trung chuyển
        }
    }

}
