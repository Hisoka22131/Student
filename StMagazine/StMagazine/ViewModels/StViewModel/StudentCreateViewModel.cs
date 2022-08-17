using Microsoft.AspNetCore.Http;
using StMagazine.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StMagazine.ViewModels
{
    public class StudentCreateViewModel
    {
        [Required(ErrorMessage = "Не указано имя")]
        [Display(Name = "Имя студента")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Не указана фамилия")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "Не указан номер телефона")]
        public string PhoneNumber { get; set; }
        public int GroupId { get; set; }
        public Group Group { get; set; } //название группы
        //image
        public IFormFile Photo { get; set; }
    }
}
