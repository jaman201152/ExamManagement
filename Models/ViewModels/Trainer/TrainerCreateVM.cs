using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Models.ViewMoldels.Participants
{
   public class ParticipantsCreateVM
    {
       

       public int Id { get; set; }
        [Required]
        public int OrganizationId { get; set; }
        [Required]
        public int CourseId { get; set; }
        public bool LeadTrainerStatus { get; set; }
        [Required]
        public int BatchId { get; set; }
        [Required]
        public string Name { get; set; }

        public string ContactNo { get; set; }
        public string Email { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Image { get; set; }
        public bool IsDeleted { get; set; }

        public IEnumerable<SelectListItem> selectListOrganization;
        public IEnumerable<SelectListItem> selectListCourse { get; set; } 

    }
}
