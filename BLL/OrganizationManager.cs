using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Models.ViewMoldels.Organization;
using Repository;

namespace BLL
{
   public class OrganizationManager
    {

        OrganizationRepository _organizationRepository = new OrganizationRepository();


        public bool Add(Organization organization)
        {

            return _organizationRepository.Add(organization);
          
        }

        public List<Organization> GetAll()
        {

            return _organizationRepository.GetAll();

        }

        public List<Organization> GetOrganizationLastFive()
        {

            return _organizationRepository.GetOrganizationLastFive();

        }


       public Organization GetById(int id)
       {
           return _organizationRepository.GetById(id);
       }

        public bool Update(Organization organization)
        {
            return _organizationRepository.Update(organization);
        }

        public bool Delete(int id)
        {
            return _organizationRepository.Delete(id);
        }

       
    }
}
