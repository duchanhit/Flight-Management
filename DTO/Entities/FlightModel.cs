using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace DTO.Entities
{
    public partial class FlightModel : DbContext
    {
        public FlightModel()
            : base("name=FlightModel")
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Airport> Airports { get; set; }
        public virtual DbSet<ChairBooked> ChairBookeds { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Class> Classes { get; set; }
        public virtual DbSet<DefineSizeFlight> DefineSizeFlights { get; set; }
        public virtual DbSet<Flight> Flights { get; set; }
        public virtual DbSet<Passenger> Passengers { get; set; }
        public virtual DbSet<Permission> Permissions { get; set; }
        public virtual DbSet<Ticket> Tickets { get; set; }
        public virtual DbSet<Transit> Transits { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
                .Property(e => e.Gmail)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .HasMany(e => e.Permissions)
                .WithMany(e => e.Accounts)
                .Map(m => m.ToTable("Per_Acc").MapLeftKey("AccId").MapRightKey("PerID"));

            modelBuilder.Entity<Airport>()
                .HasMany(e => e.Flights)
                .WithRequired(e => e.Airport)
                .HasForeignKey(e => e.DestinationAP)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Airport>()
                .HasMany(e => e.Flights1)
                .WithRequired(e => e.Airport1)
                .HasForeignKey(e => e.OriginAP)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Airport>()
                .HasMany(e => e.Transits)
                .WithRequired(e => e.Airport)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<City>()
                .HasMany(e => e.Airports)
                .WithRequired(e => e.City)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Class>()
                .HasMany(e => e.Tickets)
                .WithRequired(e => e.Class)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Flight>()
                .Property(e => e.Price)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Flight>()
                .HasMany(e => e.ChairBookeds)
                .WithRequired(e => e.Flight)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Flight>()
                .HasOptional(e => e.DefineSizeFlight)
                .WithRequired(e => e.Flight);

            modelBuilder.Entity<Flight>()
                .HasMany(e => e.Tickets)
                .WithRequired(e => e.Flight)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Flight>()
                .HasMany(e => e.Transits)
                .WithRequired(e => e.Flight)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Passenger>()
                .HasMany(e => e.Tickets)
                .WithRequired(e => e.Passenger)
                .HasForeignKey(e => e.TicketIDPassenger)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Ticket>()
                .HasMany(e => e.ChairBookeds)
                .WithRequired(e => e.Ticket)
                .WillCascadeOnDelete(false);
        }
    }
}
