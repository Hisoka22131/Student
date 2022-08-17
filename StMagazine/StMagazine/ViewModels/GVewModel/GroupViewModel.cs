using StMagazine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StMagazine.ViewModels.GVewModel
{
    public class GroupViewModel
    {
        public IEnumerable<Group> Groups { get; set; }
        public PageViewModel PageViewModel { get; }
        public GroupViewModel(IEnumerable<Group> groups, PageViewModel viewModel)
        {
            Groups = groups;
            PageViewModel = viewModel;
        }
    }
}
