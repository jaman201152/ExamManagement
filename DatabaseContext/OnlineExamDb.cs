using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace DatabaseContext
{
   public class OnlineExamDb:DbContext
    {
       public DbSet<Organization> Organizations { get; set; }
       public DbSet<Course> Courses { get; set; }
       public DbSet<Batch> Batches { get; set; }
       public DbSet<Exam> Exams { get; set; }
       public DbSet<Participant> Participants { get; set; }
       public DbSet<Trainer> Trainers { get; set; }

    }
}
