using System;
using System.Collections.Generic;
using System.Data.Entity;
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


        public bool ParticipantAdd(Participant participant)
        {
            db.Participants.Add(participant);
            return db.SaveChanges() > 0;
        }

        public bool Update(Participant participant)
        {
            db.Participants.Attach(participant);
            db.Entry(participant).State = EntityState.Modified;
            bool isUpdated = db.SaveChanges() > 0;
            return isUpdated;
        }


        public List<Participant> GetAllParticipants()
        {
            List<Participant> participants = db.Participants
                                    .Where(c => c.IsDeleted == false)
                                    .OrderByDescending(c=>c.Id)
                                    .ToList();
            return participants;
        }




        public bool Delete(int id)
        {

            Participant participant = new Participant();

            participant = db.Participants.FirstOrDefault(c=>c.Id==id);

            if (participant != null)
            {
                participant.IsDeleted = true;
                return Update(participant);
            }
            return false;

        }


        public List<Batch> GetBatchByCourseId(int id)
        {
            var dataList = db.Batches.Where(c => c.CourseId == id).ToList();
            return dataList;
        }


        public List<Participant> GetIndividualParticipant(int id)
        {
            var data = db.Participants.Where(c => c.Id == id).ToList();
            return data;
        }

        public Participant GetById(int id)
        {
            var dataList = db.Participants.FirstOrDefault(c => c.Id == id);

            return dataList;
        }


    }
}
