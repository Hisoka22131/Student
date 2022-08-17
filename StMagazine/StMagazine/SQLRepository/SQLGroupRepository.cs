using StMagazine.Interfaces;
using StMagazine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StMagazine.SQLRepository
{
    public class SQLGroupRepository : IGroupRepository
    {
        private readonly ApplicationContext context;
        public SQLGroupRepository(ApplicationContext context)
        {
            this.context = context;
        }
        public Group Add(Group group)
        {
            context.Groups.Add(group);
            context.SaveChanges();
            return group;
        }

        public Group Delete(int id)
        {
            Group group = context.Groups.Find(id);
            if (group != null)
            {
                context.Groups.Remove(group);
                context.SaveChanges();
            }
            return group;
        }

        public IEnumerable<Group> GetAllGroups()
        {
            return context.Groups;
        }

        public Group GetGroupId(int groupId)
        {
            return context.Groups.Find(groupId);
        }

        public Group Update(Group groupChanges)
        {
            var group = context.Groups.Attach(groupChanges);
            group.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return groupChanges;
        }
    }
}
