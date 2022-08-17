using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StMagazine.Models
{
    public class Cours
    {
        public int Id { get; set; }
        public int CoursNumber { get; set; }
        public List<Group> Groups { get; set; } = new List<Group>();
    }
}
