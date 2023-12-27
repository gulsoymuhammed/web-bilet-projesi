using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace webBiletProje.Models
{
    public class DataContext:DbContext
    {
        public DataContext():base("biletDataConnection")
        {
            
        }
        //public DbSet<Ticket> Tickets { get; set; }
        public DbSet<OrderTable> OrderTables { get; set; }
        public DbSet<User> Users { get; set; }
    }
}