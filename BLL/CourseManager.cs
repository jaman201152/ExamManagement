using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using Models;
using Repository;

namespace BLL
{
    public class CourseManager
    {

        CourseRepository _courseRepository = new CourseRepository();
        public bool Add(Course course)
        {

            bool isAdded = _courseRepository.Add(course);
            return isAdded;

        }

        public List<Organization> GetAll()
        {
           return _courseRepository.GetAll();
        }

    }
}
