using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Participant
    {
       public int Id { get; set; }
        [Required]
        public int OrganizationId { get; set; }
        [Required]
        public int CourseId { get; set; }
        [Required]
        public int BatchId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string RegNo { get; set; }
        public  string ContactNo { get; set; }
        public  string Email { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public  string City { get; set; }
        public  string PostalCode { get; set; } 
        public  string Country { get; set; }
        public  string Profession { get; set; } 
        public string HighestAcademic { get; set; }
        public string Image { get; set; }
        public bool IsDeleted { get; set; }

    }
}
