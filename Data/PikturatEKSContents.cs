using EkspozitaPikturave.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EkspozitaPikturave.Data
{
    public class PikturatEKSContents : DbContext
    {
        public DbSet<Pikturat> Pikturat { get; set; }
        public DbSet<Ekspozitat> Ekspozitat { get; set; }
        public DbSet<Kritikat> Kritikat { get; set; }
        public DbSet<Shporta> Shporta { get; set; }


        public PikturatEKSContents(DbContextOptions<PikturatEKSContents> options) : base(options)
        {

        }
    }
}
