using StMagazine.Interfaces;
using StMagazine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StMagazine.SQLRepository
{
    public class SQLCoursRepository : ICoursRepository
    {
        private readonly ApplicationContext context;
        public SQLCoursRepository(ApplicationContext context)
        {
            this.context = context;
        }
        public Cours Add(Cours cours)
        {
            context.Courses.Add(cours);
            context.SaveChanges();
            return cours;
        }

        public Cours Delete(int id)
        {
            Cours cours = context.Courses.Find(id);
            if (cours != null)
            {
                context.Courses.Remove(cours);
                context.SaveChanges();
            }
            return cours;
        }

        public IEnumerable<Cours> GetAllCourses()
        {
            return context.Courses;
        }

        public Cours GetCoursId(int coursId)
        {
            return context.Courses.Find(coursId);
        }

        public Cours Update(Cours coursChanges)
        {
            var cours = context.Courses.Attach(coursChanges);
            cours.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return coursChanges;
        }
    }
}
