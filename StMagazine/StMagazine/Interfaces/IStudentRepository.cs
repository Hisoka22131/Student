using StMagazine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StMagazine.Interfaces
{
    public interface IStudentRepository
    {
        IEnumerable<Student> GetAllStudents();
        Student GetStudentId(int studentId);
        Student Add(Student student);
        Student Delete(int id);
        Student Update(Student studentChanges);
    }
}
