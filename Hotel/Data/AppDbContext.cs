using Hotel.Models;
using Microsoft.EntityFrameworkCore;

namespace Hotel.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Room> Rooms { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Review> Reviews { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=Hotel.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Room>(entity =>
            {
                entity.ToTable("Rooms"); 

                entity.Property(e => e.Id)
                    .IsRequired()
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.RoomNumber)
                    .IsRequired()
                    .HasColumnType("TEXT"); 

                entity.Property(e => e.RoomType)
                    .IsRequired()
                    .HasColumnType("TEXT"); 

                entity.Property(e => e.PricePerNight)
                    .IsRequired()
                    .HasColumnType("DECIMAL(18, 2)"); 

                entity.Property(e => e.IsAvailable)
                    .IsRequired()
                    .HasColumnType("BOOLEAN"); 
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customers"); 

                entity.Property(e => e.Id)
                    .IsRequired()
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnType("TEXT"); 

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnType("TEXT"); 

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnType("TEXT"); 

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasColumnType("TEXT"); 
            });

            modelBuilder.Entity<Booking>(entity =>
            {
                entity.ToTable("Bookings"); 

                entity.Property(e => e.Id)
                    .IsRequired()
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.EventName)
                    .IsRequired()
                    .HasColumnType("TEXT");

                entity.Property(e => e.EventDate)
                    .IsRequired()
                    .HasColumnType("TEXT");

                entity.Property(e => e.Location)
                    .IsRequired()
                    .HasColumnType("TEXT"); 
            });

            modelBuilder.Entity<Review>(entity =>
            {
                entity.ToTable("Reviews"); 

                entity.Property(e => e.Id)
                    .IsRequired()
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.ReviewerName)
                    .IsRequired()
                    .HasColumnType("TEXT"); 

                entity.Property(e => e.Rating)
                    .IsRequired()
                    .HasColumnType("INTEGER"); 

                entity.Property(e => e.Comments)
                    .HasColumnType("TEXT"); 
            });
        }
    }
}
