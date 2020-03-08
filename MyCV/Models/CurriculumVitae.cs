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
            return ShortResume.Substring(0,maxLength) + "...";
        }

        public virtual ICollection<Education> Educations { get; private set; }
        public virtual ICollection<WorkExperience> Jobs { get; private set; }
        public ApplicableCompany ApplicableCompany { get; set; }

        public virtual ICollection<Skill> Skills { get; private set; }
        public CurriculumVitae()
        {
            Educations = new List<Education>();
            Jobs = new List<WorkExperience>();
            Skills = new List<Skill>();

        }

    }
}
