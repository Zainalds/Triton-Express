using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TritonExpress.Models
{
    public class TritonExpressContext : DbContext
    {

        public TritonExpressContext(DbContextOptions<TritonExpressContext> options) : base(options)
        {

        }

        public DbSet<Vehicle> Vehicles { get; set; }

        public DbSet<Waybill> Waybill { get; set; }
    }
}
