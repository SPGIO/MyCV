using MyCV.Models.Criteria;
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

        public List<GroupedExperienceAndCategory> GetEducations()
        {
            var educationCriteria = new EducationCriteria();
            var orderByEndDateCriteria = new OrderByEndDateCriteria();
            var bothCriteria = new AndCriteria(educationCriteria, orderByEndDateCriteria);
            var listOfEducations = bothCriteria.MeetCriteria(Experience);

            var listofGroupedExperienceAndCategories = new List<GroupedExperienceAndCategory>()
            {
               new GroupedExperienceAndCategory("Uddannelse", listOfEducations.ToList())
            };

            return listofGroupedExperienceAndCategories;




        }


        public List<GroupedExperienceAndCategory> GetExperiencesWithoutEducation()
        {
            var orderByDateCriteria = new OrderByEndDateCriteria();
            var experiencesWithoutEducation = Experience.Where(exp => exp.Category.Category != "Uddannelse");

            var groupedAndOrdered =  experiencesWithoutEducation.GroupBy(
                    exp => exp.Category,
                    (category, experiences) => new GroupedExperienceAndCategory(
                        category.Category,
                        orderByDateCriteria.MeetCriteria(experiences.ToList()).ToList()
                    )
                    );

            return groupedAndOrdered.OrderBy(exp => experiencesWithoutEducation.First(cat => cat.Category.Category == exp.Name).Category.Order).ToList();

        }

    }
}
