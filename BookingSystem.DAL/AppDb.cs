using BookingSystem.DAL.DbModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.DAL
{
    public class AppDb : DbContext
    {
        public AppDb(DbContextOptions<AppDb> options) : base(options) { }
        public DbSet<tblBooking> Bookings { get; set; }
        public DbSet<tblRoom> Rooms { get; set; }
        public DbSet<tblHotel> Hotels { get; set; }
        public DbSet<tblCustomer> Customers { get; set; }
        public DbSet<tblPayment> Payments { get; set; }
        public DbSet<tblBookingRoom> BookingRooms { get; set; }
        public DbSet<tblInvoice> Invoices { get; set; }
        public DbSet<tblAdmin> Admins { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tblBooking>()
                .HasKey(c => new { c.Id });
            modelBuilder.Entity<tblRoom>()
                .HasKey(c => new { c.Id });
            modelBuilder.Entity<tblBookingRoom>()
               .HasKey(c => new { c.Id });
            modelBuilder.Entity<tblCustomer>()
               .HasKey(c => new { c.Id });
            modelBuilder.Entity<tblHotel>()
             .HasKey(c => new { c.Id });
            modelBuilder.Entity<tblInvoice>()
               .HasKey(c => new { c.Id });
            modelBuilder.Entity<tblPayment>()
               .HasKey(c => new { c.Id });

            modelBuilder.Entity<tblAdmin>()
              .HasKey(c => new { c.Id });
        }

    }
}
