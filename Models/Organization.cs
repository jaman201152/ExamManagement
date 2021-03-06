﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
   public class Organization
   {
        public int Id { get; set; }
       [Required]
       //[Display(Name = "Organization Name")]
        public string Name { get; set; }
       [Required]
        public string Code { get; set; }
        public string Address { get; set; }
        public string ContactNo { get; set; }
        public string About { get; set; }
        public string LogoName { get; set; }
        public string LogoUrl { get; set; }
        public bool IsDeleted { get; set; }

       [NotMapped]
       public List<Organization> Organizations { get; set; }

    }
}
