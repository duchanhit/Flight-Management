using DAL;
using DAL.DataAccess;
using DTO.Entities;
using System.Collections.Generic;

namespace BUS.Service
{
    public class PermissionBUS
    {
        private readonly PermissionDAL _permissionDAL;

        // Constructor
        public PermissionBUS()
        {
            _permissionDAL = new PermissionDAL();
        }

        // Method to get all permissions
        public IEnumerable<Permission> GetAllPermissions()
        {
            return _permissionDAL.GetAll();
        }

        // Method to get a permission by ID
        public Permission GetPermissionById(int id)
        {
            return _permissionDAL.GetById(id);
        }

        // Method to add a new permission
        public void AddPermission(Permission permission)
        {
            _permissionDAL.Add(permission);
        }

        // Method to update an existing permission
        public void UpdatePermission(Permission permission)
        {
            _permissionDAL.Update(permission);
        }

        // Method to delete a permission
        public void DeletePermission(int id)
        {
            _permissionDAL.Delete(id);
        }
    }
}
