using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using StMagazine.Models;

namespace StMagazine.ViewModels
{
    public class TeacherCreateViewModel
    {
        [Required(ErrorMessage = "Не указано имя")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Не указана фамилия")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "Не указан номер телефона")]
        public string PhoneNumber { get; set; }
        public List<Group> Groups { get; set; } = new List<Group>();
        public int ItemId { get; set; }
        public Item Item { get; set; }
        public IFormFile Photo { get; set; }

    }
}
