using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Repository;

namespace BLL
{
  public class ParticipantManager
    {


        ParticipantRepository _participantRepository = new ParticipantRepository();



        public List<Batch> GetBatchByCourseId(int id)
        {
            return _participantRepository.GetBatchByCourseId(id);
        }



    }
}
