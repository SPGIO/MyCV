using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCV.Models.Interfaces
{
    public interface ICriteria
    {
        public ICollection<Experience> MeetCriteria(ICollection<Experience> experiences);
    }
}
