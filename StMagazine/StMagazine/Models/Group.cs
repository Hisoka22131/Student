using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StMagazine.Models
{
    public class Group
    {
        public int Id { get; set; }
        public string GroupName { get; set; }
        public int Year { get; set; }
        public string Speciality { get; set; }
        public Teacher Teacher { get; set; }
        public int TeacherId { get; set; }
        public int CoursId { get; set; }
        public Cours Cours { get; set; }
        public List<Student> Students { get; set; } = new List<Student>();
    }
}
