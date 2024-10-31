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
        public virtual DbSet<DurationFlight> DurationFlights { get; set; }
        public virtual DbSet<Flight> Flights { get; set; }
        public virtual DbSet<Passenger> Passengers { get; set; }
        public virtual DbSet<PerDetail> PerDetails { get; set; }
        public virtual DbSet<Permission> Permissions { get; set; }
        public virtual DbSet<Profile> Profiles { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<Ticket> Tickets { get; set; }
        public virtual DbSet<Transit> Transits { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
                .HasOptional(e => e.Profile)
                .WithRequired(e => e.Account);

            modelBuilder.Entity<Airport>()
                .HasMany(e => e.Transits)
                .WithRequired(e => e.Airport)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Airport>()
                .HasMany(e => e.Flights)
                .WithRequired(e => e.Airport)
                .HasForeignKey(e => e.OriginAP)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Airport>()
                .HasMany(e => e.Flights1)
                .WithRequired(e => e.Airport1)
                .HasForeignKey(e => e.DestinationAP)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<City>()
                .HasMany(e => e.Airports)
                .WithRequired(e => e.City)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Class>()
                .HasMany(e => e.Tickets)
                .WithRequired(e => e.Class)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DurationFlight>()
                .HasMany(e => e.Tickets)
                .WithRequired(e => e.DurationFlight)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Flight>()
                .Property(e => e.Price)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Flight>()
                .HasOptional(e => e.DefineSizeFlight)
                .WithRequired(e => e.Flight);

            modelBuilder.Entity<Flight>()
                .HasMany(e => e.DurationFlights)
                .WithRequired(e => e.Flight)
                .HasForeignKey(e => e.IDFlight)
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

            modelBuilder.Entity<Permission>()
                .HasOptional(e => e.PerDetail)
                .WithRequired(e => e.Permission);

            modelBuilder.Entity<Profile>()
                .HasMany(e => e.Permissions)
                .WithMany(e => e.Profiles)
                .Map(m => m.ToTable("Per_Acc").MapLeftKey("AccId").MapRightKey("PerID"));
        }
    }
}
