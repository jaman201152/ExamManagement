using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseContext;
using Models;
using Models.ViewMoldels.Organization;

namespace Repository
{


   public class OrganizationRepository
    {

        OnlineExamDb db = new OnlineExamDb();

        public bool Add(Organization organization)
        {
            db.Organizations.Add(organization);
            return db.SaveChanges() > 0;
        }

        public List<Organization> GetAll()
        {
            List<Organization> organizations = db.Organizations.ToList();

            return organizations;

        }

       public Organization GetById(int id)
       {
           Organization organization = db.Organizations.Find(id);
           return organization;
       }
    }
}
