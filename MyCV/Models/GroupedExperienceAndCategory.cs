using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyCV.Models
{
    [NotMapped]
    public class GroupedExperienceAndCategory
    {

        public string Name { get; set; }

        public List<Experience> Experiences { get; set; }

        public int Order { get; set; }

        public GroupedExperienceAndCategory(string name, List<Experience> experiences)
        {
            this.Experiences = experiences;
            this.Name = name;
            this.Order = Order;
        }

    }
}
