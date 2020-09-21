using ABS.Common;
using ABS.Entities;
using ABS.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;

namespace ABS.Data
{
    /// <summary>
    /// Holds repository with airlines.
    /// </summary>
    public class AirlineRepository
    {
        public void AddNewAirline(Airline airline)
        {
            using (var context = new ABS())
            {
                var airline1 = context.Airlines.Where(a => a.Name == airline.Name).FirstOrDefault();
                if (airline1 != null)
                    throw new Exception(ExceptionHelper.AlreadyExistentAirline);

                context.Airlines.Add(airline);
                context.SaveChanges();
            }

        }

        /// <summary>
        /// Рetreives and airline by airline name.
        /// </summary>
        /// <param name="airlineName"></param>
        /// <returns></returns>
        public Airline Retreive(string airlineName)
        {
            if (String.IsNullOrEmpty(airlineName))
                throw new Exception(ExceptionHelper.NullAirlineName);
            using (var context = new ABS())
            {
                var airline = context.Airlines.Where(a => a.Name == airlineName).FirstOrDefault();
                if (airline == null)
                    throw new Exception(ExceptionHelper.NonExistentAirline);

                return airline;
            }
        }

        public Airline Retreive(int airlineId)
        {

            using (var context = new ABS())
            {
                var airline = context.Airlines.Where(a => a.AirlineId == airlineId).FirstOrDefault();
                if (airline == null)
                    throw new Exception(ExceptionHelper.NonExistentAirline);

                return airline;
            }
        }

        public IEnumerable<AirlineViewModel> Retreive()
        {
            using (var context = new ABS())
            {
                List<Airline> airlines = new List<Airline>();
                airlines = context.Airlines.ToList();

                if (airlines == null) return null;
                List<AirlineViewModel> airlinesDisplay = new List<AirlineViewModel>();
                foreach (var airline in airlines)
                {
                    AirlineViewModel airlineDisplay = new AirlineViewModel()
                    {
                        AirlineId = airline.AirlineId,
                        Name = airline.Name
                    };
                    airlinesDisplay.Add(airlineDisplay);
                }
                return airlinesDisplay;
            }
        }

        /// <summary>
        /// Retreives all airlines
        /// </summary>
        /// <returns></returns>

        public string DisplayAirlinesDetails()
        {
            StringBuilder builder = new StringBuilder();
            using (var context = new ABS())
            {
                foreach (Airline airline in context.Airlines)
                {
                    builder.Append($"{airline.Name}\n");
                }
            }

            return builder.ToString();
        }
    }
}
