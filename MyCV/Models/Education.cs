using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyCV.Models
{
    public class Education : Experience , IDatable
    {
        public Education(string title, string company, DateTime startDate, DateTime endDate) : base(title, company, startDate, endDate)
        {
        }


    }
}