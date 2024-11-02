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
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Class> Classes { get; set; }
        public virtual DbSet<ChairBooked> ChairBookeds { get; set; }
        public virtual DbSet<DefineSizeFlight> DefineSizeFlights { get; set; }
        public virtual DbSet<Flight> Flights { get; set; }
        public virtual DbSet<Passenger> Passengers { get; set; }
        public virtual DbSet<Per_Acc> Per_Acc { get; set; }
        public virtual DbSet<Permission> Permissions { get; set; }
        public virtual DbSet<Ticket> Tickets { get; set; }
        public virtual DbSet<Transit> Transits { get; set; }
        public virtual DbSet<DurationFlight> DurationFlights { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
                .Property(e => e.Gmail)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .HasMany(e => e.Per_Acc)
                .WithRequired(e => e.Account)
                .HasForeignKey(e => e.AccId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Account>()
                .HasMany(e => e.Per_Acc1)
                .WithRequired(e => e.Account1)
                .HasForeignKey(e => e.AccId);

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
                .HasForeignKey(e => e.airportID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Airport>()
                .HasMany(e => e.Transits1)
                .WithRequired(e => e.Airport1)
                .HasForeignKey(e => e.airportID);

            modelBuilder.Entity<City>()
                .HasMany(e => e.Airports)
                .WithRequired(e => e.City)
                .HasForeignKey(e => e.CityId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<City>()
                .HasMany(e => e.Airports1)
                .WithRequired(e => e.City1)
                .HasForeignKey(e => e.CityId);

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
                .HasForeignKey(e => e.FlightId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Flight>()
                .HasMany(e => e.ChairBookeds1)
                .WithRequired(e => e.Flight1)
                .HasForeignKey(e => e.FlightId);

            modelBuilder.Entity<Flight>()
                .HasOptional(e => e.DefineSizeFlight)
                .WithRequired(e => e.Flight);

            modelBuilder.Entity<Flight>()
                .HasOptional(e => e.DefineSizeFlight1)
                .WithRequired(e => e.Flight1)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Flight>()
                .HasMany(e => e.Tickets)
                .WithRequired(e => e.Flight)
                .HasForeignKey(e => e.FlightId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Flight>()
                .HasMany(e => e.Transits)
                .WithRequired(e => e.Flight)
                .HasForeignKey(e => e.flightID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Flight>()
                .HasMany(e => e.DurationFlights)
                .WithRequired(e => e.Flight)
                .HasForeignKey(e => e.IDFlight);

            modelBuilder.Entity<Flight>()
                .HasMany(e => e.Tickets1)
                .WithRequired(e => e.Flight1)
                .HasForeignKey(e => e.FlightId);

            modelBuilder.Entity<Flight>()
                .HasMany(e => e.Transits1)
                .WithRequired(e => e.Flight1)
                .HasForeignKey(e => e.flightID);

            modelBuilder.Entity<Passenger>()
                .HasMany(e => e.Tickets)
                .WithRequired(e => e.Passenger)
                .HasForeignKey(e => e.TicketIDPassenger)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Passenger>()
                .HasMany(e => e.Tickets1)
                .WithRequired(e => e.Passenger1)
                .HasForeignKey(e => e.TicketIDPassenger);

            modelBuilder.Entity<Permission>()
                .HasMany(e => e.Per_Acc)
                .WithRequired(e => e.Permission)
                .HasForeignKey(e => e.PerID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Permission>()
                .HasMany(e => e.Per_Acc1)
                .WithRequired(e => e.Permission1)
                .HasForeignKey(e => e.PerID);

            modelBuilder.Entity<Ticket>()
                .HasMany(e => e.ChairBookeds)
                .WithRequired(e => e.Ticket)
                .WillCascadeOnDelete(false);
        }
    }
}
