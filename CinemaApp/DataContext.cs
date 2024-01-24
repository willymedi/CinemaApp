using CinemaApp.Models;
using Microsoft.EntityFrameworkCore;

namespace CinemaApp
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        public DbSet<CustomerEntity> Customers { get; set; }
        public DbSet<SeatEntity> Seatings { get; set; }
        public DbSet<RoomEntity> Room { get; set; }
        public DbSet<BillboardEntity> Billboard { get; set; }
        public DbSet<BookingEntity> Booking { get; set; }
        public DbSet<MovieEntity> Movie { get; set; }


    }
}
