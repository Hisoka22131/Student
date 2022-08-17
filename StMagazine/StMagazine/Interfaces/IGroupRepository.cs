using StMagazine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StMagazine.Interfaces
{
    public interface IGroupRepository
    {
        IEnumerable<Group> GetAllGroups();
        Group GetGroupId(int groupId);
        Group Add(Group group);
        Group Delete(int id);
        Group Update(Group groupChanges);
    }
}
