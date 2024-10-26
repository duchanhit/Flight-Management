using DAL.IAccess;
using DTO.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS.Service
{
    public class PermissionBUS
    {
        private readonly IRepository<Permission> _permissionRepository;

        // Constructor Injection
        public PermissionBUS(IRepository<Permission> permissionRepository)
        {
            _permissionRepository = permissionRepository;
        }

        // Method to get all permissions
        public IEnumerable<Permission> GetAllPermissions()
        {
            return _permissionRepository.GetAll();
        }

        // Method to get permission by ID
        public Permission GetPermissionById(int id)
        {
            return _permissionRepository.GetById(id);
        }

        // Method to add a new permission
        public void AddPermission(Permission permission)
        {
            _permissionRepository.Add(permission);
        }

        // Method to update an existing permission
        public void UpdatePermission(Permission permission)
        {
            _permissionRepository.Update(permission);
        }

        // Method to delete a permission
        public void DeletePermission(int id)
        {
            _permissionRepository.Delete(id);
        }
    }
}
