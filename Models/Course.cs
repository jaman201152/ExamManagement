using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Models
{
   public class Course
    {
       public int Id { get; set; }
       public int OrganizationId { get; set; }

       //public Organization Organization { get; set; }

       [Required]
       public string Name { get; set; }
       [Required]
       public string Code { get; set; }
       public string CourseDuration { get; set; }
       public string Credit { get; set; }
       public string OutLine { get; set; }
       public string Tags { get; set; }
       public bool IsDeleted { get; set; }

       public virtual Organization Organization { get; set; }

       [NotMapped]
       public IEnumerable<SelectListItem> SelectListItemsOrganization { get; set; } 

    }
}
