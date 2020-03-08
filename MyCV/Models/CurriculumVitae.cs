using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyCV.Models
{
    public class CurriculumVitae
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string ShortResume { get; set; }
        [Required]
        public PersonalInformation PersonalInformation { get; set; }


        public string ShortResumeWithThreeDots(int maxLength)
        {
            if (ShortResume.Length < maxLength)
                return ShortResume;
            return ShortResume.Substring(0, maxLength) + "...";
        }

        public virtual ICollection<Experience> Experience { get; private set; }
        public ApplicableCompany ApplicableCompany { get; set; }

        public virtual ICollection<Skill> Skills { get; private set; }
        public CurriculumVitae()
        {
            Experience = new List<Experience>();
            Skills = new List<Skill>();
        }

        public List<Experience> GetEducations()
        {
            return Experience.Where(e => e.Category.Category == "Education").ToList();
        }
    }
}
