using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Models.ViewMoldels.Participant;
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


        public bool AddParticipant(Participant participants)
        {
            return _participantRepository.ParticipantAdd(participants);
        }


        public List<Participant> GetAllParticipants()
        {
            return _participantRepository.GetAllParticipants();
        }

        public List<Participant> GetIndividualParticipant(int id)
        {
            return _participantRepository.GetIndividualParticipant(id);
        }

        public Participant GetByID(int id)
        {
            return _participantRepository.GetById(id);
        }

        public bool Update(Participant participant)
        {
            return _participantRepository.Update(participant);
        }

        public bool Delete(int id)
        {
            return _participantRepository.Delete(id);
        }
    }
}
