using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyCV.Models
{
    interface IExperience
    {
        [Required]
        public string Company { get; set; }
        [Required]
        public string Title { get; set; }

        
    }
}
