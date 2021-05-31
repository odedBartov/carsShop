using spinFrameMvc.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace spinFrameMvc.DB
{
    public class CarDbContext : DbContext
    {
        public CarDbContext(): base("CarDbContext")
        {
        }

        public DbSet<Car> Cars { get; set; }
    }
}