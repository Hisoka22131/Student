using StMagazine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StMagazine.Interfaces
{
   public interface ITeacherRepository
    {
        IEnumerable<Teacher> GetAllTeacher();
        Teacher GetTeacherId(int teacherId);
        Teacher Add(Teacher teacher);
        Teacher Delete(int id);
        Teacher Update(Teacher teacherChanges);
    }
}
