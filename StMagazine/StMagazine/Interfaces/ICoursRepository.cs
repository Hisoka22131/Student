using StMagazine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StMagazine.Interfaces
{
   public interface ICoursRepository
    {
        IEnumerable<Cours> GetAllCourses();
        Cours GetCoursId(int coursId);
        Cours Add(Cours cours);
        Cours Update(Cours coursChanges);
        Cours Delete(int id);

    }
}
