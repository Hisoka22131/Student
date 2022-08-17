using StMagazine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StMagazine.ViewModels.StViewModel
{
    public class StudentViewModel
    {
        public IEnumerable<Student> students { get; set; }
        public PageViewModel PageViewModel { get; }
        public StudentViewModel(IEnumerable<Student> student, PageViewModel viewModel)
        {
            students = student;
            PageViewModel = viewModel;
        }
    }
}
