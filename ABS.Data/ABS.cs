namespace ABS.Data
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using global::ABS.Entity;

    public partial class ABS : DbContext
    {
        public ABS()
            : base("name=ABS")
        {
        }

        public virtual DbSet<Airline> Airlines { get; set; }
        public virtual DbSet<Airport> Airports { get; set; }
        public virtual DbSet<Flight> Flights { get; set; }
        public virtual DbSet<Seat> Seats { get; set; }
        public virtual DbSet<Section> Sections { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Airline>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Airline>()
                .HasMany(e => e.Flights)
                .WithRequired(e => e.Airline)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Airport>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Airport>()
                .HasMany(e => e.Flights)
                .WithRequired(e => e.Airport)
                .HasForeignKey(e => e.OrgAirportId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Airport>()
                .HasMany(e => e.Flights1)
                .WithRequired(e => e.Airport1)
                .HasForeignKey(e => e.DestAirportId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Flight>()
                .Property(e => e.FlightName)
                .IsUnicode(false);

            modelBuilder.Entity<Flight>()
                .HasMany(e => e.Seats)
                .WithRequired(e => e.Flight)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Seat>()
                .Property(e => e.Col)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Section>()
                .Property(e => e.SeatClassName)
                .IsUnicode(false);

            modelBuilder.Entity<Section>()
                .HasMany(e => e.Seats)
                .WithRequired(e => e.Section)
                .WillCascadeOnDelete(false);
        }
    }
}
