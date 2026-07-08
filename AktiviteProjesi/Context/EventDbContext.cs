using AktiviteProjesi.Models;
using Microsoft.EntityFrameworkCore;


namespace AktiviteProjesi.Context
{
    public class EventDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data source=VICTUS\\SQLEXPRESS; database=AktiviteProjesi; Integrated Security=True; TrustServerCertificate=True;");

        }
        public DbSet<Event> Events{get;set;}
        public DbSet<Comment> Comments{get;set;}
        public DbSet<Contact> Contacts{get;set;}
    }
}
