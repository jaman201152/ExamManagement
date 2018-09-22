using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Policy;
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
            List<Organization> organizations = db.Organizations
                            .Where(c=>c.IsDeleted==false)
                            .OrderByDescending(c=>c.Id)
                            .ToList();

            return organizations;

        }

        public List<Organization> GetOrganizationLastFive()
        {
            List<Organization> organizations = db.Organizations
                                .Where(c => c.IsDeleted == false)
                                .Take(5)
                                .OrderByDescending(c => c.Id)
                                .ToList();

            return organizations;

        }


       public Organization GetById(int id)
       {
           Organization organization = db.Organizations.Find(id);
           return organization;
       }


        public bool Update(Organization organization)
        {
            db.Organizations.Attach(organization);
            db.Entry(organization).State = EntityState.Modified;
            bool isUpdated = db.SaveChanges() > 0;
            return isUpdated;
        }




        public bool Delete(int id)
        {

            Organization organization = new Organization();
            //organization = db.Organizations.Where(c => c.Id == id).FirstOrDefault();

            organization = db.Organizations.FirstOrDefault(c=>c.Id==id);

            if (organization != null)
            {
                organization.IsDeleted = true;
                return Update(organization);
            }
       

            return false;


        }




    }
}
