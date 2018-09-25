using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseContext;
using Models;

namespace Repository
{
   public class ParticipantRepository
    {

        OnlineExamDb db = new OnlineExamDb();



        public List<Batch> GetBatchByCourseId(int id)
        {
            var dataList = db.Batches.Where(c => c.CourseId == id).ToList();
            return dataList;
        }



    }
}
