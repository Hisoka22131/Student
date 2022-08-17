using StMagazine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StMagazine.ViewModels.TViewModel
{
    public class TeacherViewModel
    {
       public IEnumerable<Teacher> teacherViewModels { get; set; }
        public PageViewModel PageViewModel { get; }
        public TeacherViewModel(IEnumerable<Teacher> teacher, PageViewModel viewModel)
        {
            teacherViewModels = teacher;
            PageViewModel = viewModel;
        }
    }
}
