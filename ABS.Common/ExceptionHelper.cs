using System;
using System.Collections.Generic;
using System.Text;

namespace ABS.Common
{
    public static class ExceptionHelper
    {
        public const string InvalidAirlineNameSize = "Airline name must be 1 to 6 characters!";
        public const string InvalidAirlineNameCharacters = "Airline name must not contain special characters!";
        public const string NullAirlineName = "Airline name can't be null or empty!";
        public const string NonExistentAirline = "Airline does not exist!";
        public const string AlreadyExistentAirline = "Airline already exists!";
        public const string InvalidAirportNameSize = "Airport name must be exactly 3 Characters!";
        public const string InvalidAirportNameCharacters = "Airport name must not contain special characters!";
        public const string NullAirportName = "Airport name can't be null or empty!";
        public const string NonExistentAirport = "Airport does not exist!";
        public const string NonExistentFlight = "Flight does not exist!";
        public const string AlreadyExistentAirport = "Airport already exists!";
        public const string FlightSectionOutOfBound = "Flight section can have at most 100 rows and 10 columns!";
        public const string ColumnOutOfBound = "Columnn value must be number in the range 1-10!";
        public const string RowOutOfBouund = "Row value must be number in the range 1-100!";
        public const string FlightNotFound = "Flight with this id cannot be found!";
        public const string ExistingSection = "Such seatclass is already asociated with this flight!";
        public const string SeatAlreadyBooked = "Seat you want to book is already booked!";
        public const string AlreadyExistentFlight = "Flight already exists!";
        public const string InvalidSeat = "Seat input is invalid!";
        public const string SameOriginAndDestination = " Origin and destination airport cannot be the same!";
    }
}
