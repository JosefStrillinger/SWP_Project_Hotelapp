using Hotel;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Models.DB {
    public class HotelContext : DbContext{
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Guest> Guests { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Bill> Bills { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Guest>()
                .HasKey(g => g.Passnumber);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            string conn = "Server=localhost;database=hotelapp;user=root;password=; Convert Zero Datetime = True";
            optionsBuilder.UseMySql(conn, ServerVersion.AutoDetect(conn));
        }
    }
}
