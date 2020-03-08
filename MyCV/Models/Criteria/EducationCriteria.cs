using MyCV.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCV.Models.Criteria
{
    public class EducationCriteria : ICriteria
    {
        public ICollection<Experience> MeetCriteria(ICollection<Experience> experiences)
        {
            List<Experience> educations = new List<Experience>();
            if (experiences == null) return educations;
            foreach(var experience in experiences)
            {
                if (experience.Category.Category == "Uddannelse")
                {
                    educations.Add(experience);
                }
            }
            return educations;
        }
    }
}
