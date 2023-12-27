using System;
using System.Data.Entity;
using System.Linq;

namespace webBiletProje.Models
{
    public class TicketDB : DbContext
    {

        public TicketDB()
            : base("name=TicketDB")
        {
        }

        public System.Data.Entity.DbSet<webBiletProje.Models.Ticket> Tickets { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}