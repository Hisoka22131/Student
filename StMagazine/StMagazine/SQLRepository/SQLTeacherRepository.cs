using StMagazine.Interfaces;
using StMagazine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StMagazine.SQLRepository
{
    public class SQLTeacherRepository : ITeacherRepository
    {
        private readonly ApplicationContext context;
        public SQLTeacherRepository(ApplicationContext context)
        {
            this.context = context;
        }
        public Teacher Add(Teacher teacher)
        {
            context.Teachers.Add(teacher);
            context.SaveChanges();
            return teacher;
        }

        public Teacher Delete(int id)
        {
            Teacher teacher = context.Teachers.Find(id);
            if (teacher != null)
            {
                context.Teachers.Remove(teacher);
                context.SaveChanges();
            }
            return teacher;
        }

        public IEnumerable<Teacher> GetAllTeacher()
        {
            return context.Teachers;
        }

        public Teacher GetTeacherId(int teacherId)
        {
            return context.Teachers.Find(teacherId);
        }

        public Teacher Update(Teacher teacherChanges)
        {
            var teacher = context.Teachers.Attach(teacherChanges);
            teacher.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return teacherChanges;
        }
    }
}
