using StMagazine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StMagazine.ViewModels.CViewModel
{
    public class CoursViewModel
    {
        public IEnumerable<Cours> Courses { get; set; }
        public PageViewModel PageViewModel { get; }
        public CoursViewModel(IEnumerable<Cours> Cours, PageViewModel viewModel)
        {
            Courses = Cours;
            PageViewModel = viewModel;
        }
    }
}
