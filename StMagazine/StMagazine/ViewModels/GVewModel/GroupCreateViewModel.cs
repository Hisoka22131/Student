using StMagazine.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StMagazine.ViewModels.GVewModel
{
    public class GroupCreateViewModel
    {
        [Required(ErrorMessage = "Не указано название")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Не указан год")]
        public int Year { get; set; }
        [Required(ErrorMessage = "Не указана специальность")]
        public string Speciality { get; set; }
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        public int CoursId { get; set; }
        public Cours Cours { get; set; }
        public List<Student> Students { get; set; } = new List<Student>();
    }
}
