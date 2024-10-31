using DAL;
using DAL.DataAccess;
using DTO.Entities;
using System.Collections.Generic;

namespace BUS.Service
{
    public class ClassBUS
    {
        private readonly ClassDAL _classDAL;

        // Constructor
        public ClassBUS()
        {
            _classDAL = new ClassDAL();
        }

        // Method to get all classes
        public IEnumerable<Class> GetAllClasses()
        {
            return _classDAL.GetAll();
        }

        // Method to get a class by ID
        public Class GetClassById(int id)
        {
            return _classDAL.GetById(id);
        }

        // Method to add a new class
        public void AddClass(Class classEntity)
        {
            _classDAL.Add(classEntity);
        }

        // Method to update an existing class
        public void UpdateClass(Class classEntity)
        {
            _classDAL.Update(classEntity);
        }

        // Method to delete a class
        public void DeleteClass(int id)
        {
            _classDAL.Delete(id);
        }
    }
}
