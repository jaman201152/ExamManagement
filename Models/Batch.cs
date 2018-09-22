using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
   public class Batch
    {

        public int Id { get; set; }
        [Required]
        public int OrganizationId { get; set; }
        [Required]
        public int CourseId { get; set; }
       [Required]
        public string BatchNo { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsDeleted { get; set; }

    }
}
