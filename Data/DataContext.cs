using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using WebAPI.Models;

namespace WebAPI.Data
{
    public class DataContext : DbContext
    {
        // Shove all the data from the outside class to the EntityFramework
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        // Tell the context what are our tables, bring all tables to DBContext
        public DbSet<Client> Clients { get; set; }
        public DbSet<Country> Coutries { get; set; }
        public DbSet<Tickets> Tickets { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserTickets> UserTickets { get; set; }

        //Customize our tables without going to the Database for sideprojects purpose
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //link only many to many relantionship tables
            modelBuilder.Entity<UserTickets>().
                HasKey(us => new {us.UserId, us.TicketId});
            modelBuilder.Entity<UserTickets>().
                HasOne(u => u.User).
                WithMany(us => us.UserTickets).
                HasForeignKey(u =>  u.UserId);
            modelBuilder.Entity<UserTickets>().
                HasOne(t => t.Tickets).
                WithMany(us => us.UserTickets).
                HasForeignKey(t => t.TicketId);

            base.OnModelCreating(modelBuilder);
        }

    }
}
