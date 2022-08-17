using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StMagazine.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string ItemName { get; set; }
        public List<Teacher> Teacher { get; set; } = new List<Teacher>();
    }
}
