using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ABS.Entity
{
    /// <summary>
    /// Contains flight information.
    /// </summary>
    [Table("Flight")]
    public partial class Flight
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Flight()
        {
            Seats = new HashSet<Seat>();
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FlightId { get; set; }

        public DateTime Date { get; set; }

        [Required]
        [StringLength(50)]
        public string FlightName { get; set; }

        public int AirlineId { get; set; }

        public int OrgAirportId { get; set; }

        public int DestAirportId { get; set; }

        public virtual Airline Airline { get; set; }

        public virtual Airport Airport { get; set; }

        public virtual Airport Airport1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Seat> Seats { get; set; }

        public override string ToString()
        {
            return $"{Airline.Name} {FlightName}";
        }
    }
}
