using ABS.Common;
using ABS.Entities;
using ABS.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace ABS.Data
{
    /// <summary>
    /// Holds repository with airports.
    /// </summary>
    public class AirportRepository
    {
        public void AddNewAirport(Airport airport)
        {
            using (var context = new ABS())
            {
                // Tries to find airport with the same name as the passed entity and adds it to the database only if it is not found
                var airp = context.Airports.Where(a => a.Name == airport.Name).FirstOrDefault();
                if (airp != null)
                    throw new Exception(ExceptionHelper.AlreadyExistentAirport);
                context.Airports.Add(airport);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Retreives an airport with name from the parameter.
        /// </summary>
        public Airport Retreive(string airportName)
        {
            if (String.IsNullOrEmpty(airportName))
                throw new Exception(ExceptionHelper.NullAirportName);
            using (var context = new ABS())
            {
                var airport = context.Airports.Where(a => a.Name == airportName).FirstOrDefault();
                if (airport == null)
                    throw new Exception(ExceptionHelper.NonExistentAirport);

                return airport;
            }
        }
        public IEnumerable<AirportViewModel> Retreive()
        {
            using (var context = new ABS())
            {
                List<Airport> airports = new List<Airport>();
                airports = context.Airports.ToList();
                if (airports == null) return null;
                {
                    List<AirportViewModel> airportsDisplay = new List<AirportViewModel>();
                    foreach (var airport in airports)
                    {
                        var airportDisplay = new AirportViewModel()
                        {
                            AirportId = airport.AirportId,
                            Name = airport.Name
                        };
                        airportsDisplay.Add(airportDisplay);

                    }
                    return airportsDisplay;
                }
            }
        }

        /// <summary>
        /// Retreives all airports.
        /// </summary>
        /// <returns></returns>

        public string DisplayAirportsDetails()
        {
            StringBuilder builder = new StringBuilder();
            using (var context = new ABS())
            {
                foreach (Airport airport in context.Airports)
                    builder.Append($"{airport.Name}\n");
            }

            return builder.ToString();
        }
    }
}
