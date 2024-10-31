using DAL.IAccess;
using DTO.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DataAccess
{
    public class PermissionDAL : IRepository<Permission>
    {
        // Lấy tất cả các quyền từ cơ sở dữ liệu
        public IEnumerable<Permission> GetAll()
        {
            using (FlightModel context = new FlightModel())
            {
                return context.Permissions.ToList();
            }
        }

        // Lấy thông tin quyền theo ID
        public Permission GetById(string permissionId)
        {
            using (FlightModel context = new FlightModel())
            {
                return context.Permissions.SingleOrDefault(p => p.PermissionId.ToString() == permissionId);
            }
        }

        // Thêm quyền vào cơ sở dữ liệu
        public void Add(Permission permission)
        {
            using (FlightModel context = new FlightModel())
            {
                context.Permissions.Add(permission);
                context.SaveChanges();
            }
        }

        // Cập nhật thông tin quyền
        public void Update(Permission permission)
        {
            using (FlightModel context = new FlightModel())
            {
                var existingPermission = context.Permissions.SingleOrDefault(p => p.PermissionId == permission.PermissionId);
                if (existingPermission != null)
                {
                    // Cập nhật các thuộc tính cần thiết
                    existingPermission.PermissionName = permission.PermissionName;
                    context.SaveChanges();
                }
            }
        }

        // Xóa quyền khỏi cơ sở dữ liệu
        public void Delete(string permissionId)
        {
            using (FlightModel context = new FlightModel())
            {
                var permissionToDelete = context.Permissions.SingleOrDefault(p => p.PermissionId.ToString() == permissionId);
                if (permissionToDelete != null)
                {
                    context.Permissions.Remove(permissionToDelete);
                    context.SaveChanges();
                }
            }
        }
    }
}
