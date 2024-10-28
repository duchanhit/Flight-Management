﻿using DAL.IAccess;
using DTO.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DataAccess
{
    public class ClassDAL : IRepository<Class>
    {
        // Lấy tất cả các lớp từ cơ sở dữ liệu
        public IEnumerable<Class> GetAll()
        {
            using (FlightModel context = new FlightModel())
            {
                return context.Classes.ToList();
            }
        }

        // Lấy thông tin lớp theo ID
        public Class GetById(int classId)
        {
            using (FlightModel context = new FlightModel())
            {
                return context.Classes.SingleOrDefault(c => c.ClassId == classId.ToString());
            }
        }

        // Thêm lớp vào cơ sở dữ liệu
        public void Add(Class classEntity)
        {
            using (FlightModel context = new FlightModel())
            {
                context.Classes.Add(classEntity);
                context.SaveChanges();
            }
        }

        // Cập nhật thông tin lớp
        public void Update(Class classEntity)
        {
            using (FlightModel context = new FlightModel())
            {
                var existingClass = context.Classes.SingleOrDefault(c => c.ClassId == classEntity.ClassId.ToString());
                if (existingClass != null)
                {
                    // Cập nhật các thuộc tính cần thiết
                    existingClass.ClassName = classEntity.ClassName;
                    existingClass.PriceRatio = classEntity.PriceRatio;
                    context.SaveChanges();
                }
            }
        }

        // Xóa lớp khỏi cơ sở dữ liệu
        public void Delete(int classId)
        {
            using (FlightModel context = new FlightModel())
            {
                var classToDelete = context.Classes.SingleOrDefault(c => c.ClassId == classId.ToString());
                if (classToDelete != null)
                {
                    context.Classes.Remove(classToDelete);
                    context.SaveChanges();
                }
            }
        }
    }
}
