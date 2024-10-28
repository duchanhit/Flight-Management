using DAL.IAccess;
using DTO.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS.Service
{
    public class ClassBUS
    {
        private readonly IRepository<Class> _classRepository;

        // Constructor Injection
        public ClassBUS(IRepository<Class> classRepository)
        {
            _classRepository = classRepository;
        }

        // Method to get all classes
        public IEnumerable<Class> GetAllClasses()
        {
            return _classRepository.GetAll();
        }

        // Method to get class by ID
        public Class GetClassById(int id)
        {
            return _classRepository.GetById(id);
        }

        // Method to add a new class
        public void AddClass(Class classEntity)
        {
            _classRepository.Add(classEntity);
        }

        // Method to update an existing class
        public void UpdateClass(Class classEntity)
        {
            _classRepository.Update(classEntity);
        }

        // Method to delete a class
        public void DeleteClass(int id)
        {
            _classRepository.Delete(id);
        }
    }
}
