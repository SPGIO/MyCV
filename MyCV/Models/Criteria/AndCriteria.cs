using MyCV.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCV.Models.Criteria
{
    public class AndCriteria : ICriteria
    {

        private ICriteria Criteria1;
        private ICriteria Criteria2;
        public AndCriteria(ICriteria criteria1, ICriteria criteria2)
        {
            this.Criteria1 = criteria1;
            this.Criteria2 = criteria2;
        }
        public ICollection<Experience> MeetCriteria(ICollection<Experience> experiences)
        {
            var firstCriteriaList = Criteria1.MeetCriteria(experiences);
            var secondCriteraList = Criteria2.MeetCriteria(firstCriteriaList);
            return secondCriteraList;
        }
    }
}
