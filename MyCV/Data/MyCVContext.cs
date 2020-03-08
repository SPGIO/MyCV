using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyCV.Models;

namespace MyCV.Data
{
    public class MyCVContext : DbContext
    {
        public MyCVContext (DbContextOptions<MyCVContext> options)
            : base(options)
        {
            
        }

       
        public DbSet<MyCV.Models.CurriculumVitae> CurriculumVitae { get; set; }
    }
}
