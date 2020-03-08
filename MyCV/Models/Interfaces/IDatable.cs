using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCV.Models
{
    interface IDatable
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}