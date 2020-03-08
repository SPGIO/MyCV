using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace MyCV.Models
{
    public abstract class Experience : IDatable, IExperience
    {
        public int Id { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Company { get; set; }

        [Required]
        public ExperienceCategory Category { get; set; }

        public Experience(string title, string company, DateTime startDate, DateTime endDate)
        {
            if (endDate < startDate)
            {
                throw new DateTimeTooSmallException();
            }
            Title = title;            
            Company = company;
            StartDate = startDate;
            EndDate = endDate;
        }

        public string FullDate => (
            StartDate == EndDate
            ? StartDate.Year.ToString(CultureInfo.CurrentCulture)
            : string.Format(CultureInfo.CurrentCulture,"{0} - {1}" , StartDate.Year, EndDate.Year)
            );
    }
}
