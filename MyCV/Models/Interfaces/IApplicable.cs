﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCV.Models
{
    interface IApplicable
    {
        public DateTime DateApplied { get; set; }
        public DateTime LastApplyDate { get; set; }
        public DateTime HasApplied { get; set; }
        public string Remarks { get; set; }
    }
}
