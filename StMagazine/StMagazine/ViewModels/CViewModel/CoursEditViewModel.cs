using StMagazine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StMagazine.ViewModels.CViewModel
{
    public class CoursEditViewModel
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public List<Group> Groups { get; set; } = new List<Group>();
    }
}
