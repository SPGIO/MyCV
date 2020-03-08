using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyCV.Models
{
    public class Skill : IRatable
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }
        [Required]
        public int Rating { get; set; }

        [Required]
        ExperienceCategory Category { get; set; }
    }
}

