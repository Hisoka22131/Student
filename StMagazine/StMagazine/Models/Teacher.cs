using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StMagazine.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public List<Group> Groups { get; set; } = new List<Group>();
        public int ItemId { get; set; }
        public Item Item { get; set; }
        public string PhotoPath { get; set; }
    }
}
