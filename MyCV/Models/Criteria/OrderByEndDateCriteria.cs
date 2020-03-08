using MyCV.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCV.Models.Criteria
{
    public class OrderByEndDateCriteria : ICriteria
    {
        public ICollection<Experience> MeetCriteria(ICollection<Experience> experiences)
        {
            if (experiences == null) return new List<Experience>();
            return experiences.OrderByDescending(exp => exp.EndDate).ToList();
        }
    }
}
