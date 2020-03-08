using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyCV.Models
{
    public class WorkExperience : Experience, IDescribable
    {

        [Required]
        public string Description { get; set; }


        public WorkExperience(string title, string description, string company, DateTime startDate, DateTime endDate) : base(title, company, startDate, endDate)
        {
            this.Description = description;
        }
    }
}
