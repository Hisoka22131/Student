﻿using StMagazine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StMagazine.ViewModels.IViewModel
{
    public class ItemCreateViewModel
    {
        public string Name { get; set; }
        public List<Teacher> Teacher { get; set; } = new List<Teacher>();
    }
}
