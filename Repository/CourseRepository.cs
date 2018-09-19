using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseContext;
using Models;

namespace Repository
{
  public  class CourseRepository
    {

      OnlineExamDb db = new OnlineExamDb();


      public bool Add(Course course)
      {
          db.Courses.Add(course);
          return db.SaveChanges() > 0;
      }


      public List<Organization> GetAll()
      {
          List<Organization> organizations = db.Organizations.ToList();
          return organizations;
      }

    }
}
