using ABS.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.RegularExpressions;

namespace ABS.Entity
{
    /// <summary>
    /// Holds information about an Airline.
    /// </summary>
    [Table("Airline")]
    public partial class Airline
    {
        private string _name = String.Empty;

        public Airline()
        {
            Flights = new HashSet<Flight>();
        }
        [Required]
        [StringLength(6)]
        public string Name
        {
            get { return _name; }
            set
            {
                if (value.Length > 6 || value.Length < 1)
                    throw new Exception(ExceptionHelper.InvalidAirlineNameSize);

                if (!Regex.IsMatch(value, @"^[A-Za-z][A-Za-z.]+$"))
                    throw new Exception(ExceptionHelper.InvalidAirlineNameCharacters);

                _name = value;
            }
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AirlineId { get; set; }

        public virtual ICollection<Flight> Flights { get; set; }
    }
}
