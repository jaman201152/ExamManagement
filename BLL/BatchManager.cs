using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Repository;

namespace BLL
{
  public  class BatchManager
    {

      BatchRepository _batchRepository = new BatchRepository();


        public bool AddBatch(Batch batch)
        {
            bool isAdded = _batchRepository.AddBatch(batch);

            return isAdded;
        }
        


        public List<Organization> GetAllOrganizations()
        {
            return _batchRepository.GetAllOrganizations();
        }

        public List<Course> GetAllCourses()
        {
            return _batchRepository.GetAllCourse();
        }



        public List<Course> GetCourseByOrganizationId(int id)
        {
            return _batchRepository.GetCourseByOrganizationId(id);
        }

      public IList<Batch> BatchDetails()
      {
          return _batchRepository.BatchDetails();
      }


      public Batch GetById(int id)
      {
          return _batchRepository.GetById(id);
      }


      public bool Update(Batch course)
      {
          return _batchRepository.Update(course);
      }


      public bool Delete(int id)
      {
          return _batchRepository.Delete(id);
      }
    }
}
