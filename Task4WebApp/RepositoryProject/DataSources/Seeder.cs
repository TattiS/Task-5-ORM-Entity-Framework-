using System;
using System.Collections.Generic;
using System.Text;
using DALProject.Models;

namespace DALProject
{
	public static class Seeder
	{
		public static void Seed(MainDBContext context)
		{
			var flights = new List<Flight> {
			new Flight { DeparturePoint="Rome", Destination="Paris", DepartureTime=DateTime.Parse("2018-01-11T15:45:00"), ArrivalTime=DateTime.Parse("2018-01-11T15:45:00"),
				Tickets = new List<Ticket> {
													new Ticket { Price=25.00, FlightId=1},
													new Ticket { Price = 35.00, FlightId = 1 },
													new Ticket {Price = 45.00, FlightId = 1 } } },
			new Flight {DeparturePoint = "NY", Destination="Paris", DepartureTime=DateTime.Parse("2018-01-11T15:45:00"), ArrivalTime=DateTime.Parse("2018-01-11T15:45:00"),
				Tickets = new List<Ticket> {
													new Ticket {Price=25.00, FlightId=2},
													new Ticket {Price = 35.00, FlightId = 2 },
													new Ticket {Price = 45.00, FlightId = 2 } }},
			new Flight {DeparturePoint = "Ottawa", Destination="Paris", DepartureTime=DateTime.Parse("2018-01-11T15:45:00"), ArrivalTime=DateTime.Parse("2018-01-11T15:45:00"),
				Tickets = new List<Ticket> {
													new Ticket {Price=25.00, FlightId=3},
													new Ticket {Price = 35.00, FlightId = 3 },
													new Ticket {Price = 45.00, FlightId = 3 } } },
			new Flight {DeparturePoint="Rome", Destination="Paris", DepartureTime=DateTime.Parse("2018-01-11T15:45:00"), ArrivalTime=DateTime.Parse("2018-01-11T15:45:00"),
				Tickets = new List<Ticket> {
													new Ticket {Price=25.00, FlightId=4},
													new Ticket { Price = 35.00, FlightId = 4 },
													new Ticket {Price = 45.00, FlightId = 4 } } },
			new Flight {DeparturePoint = "NY", Destination="Paris", DepartureTime=DateTime.Parse("2018-01-11T15:45:00"), ArrivalTime=DateTime.Parse("2018-01-11T15:45:00"),
				Tickets = new List<Ticket> {
													new Ticket {  Price=25.00, FlightId=5},
													new Ticket {  Price = 35.00, FlightId = 5 },
													new Ticket {  Price = 45.00, FlightId = 5 } }  },
			new Flight { DeparturePoint = "Ottawa", Destination="Paris", DepartureTime=DateTime.Parse("2018-01-11T15:45:00"), ArrivalTime=DateTime.Parse("2018-01-11T15:45:00"),
				Tickets = new List<Ticket> {
													new Ticket { Price=25.00, FlightId=6},
													new Ticket {Price = 35.00, FlightId = 6 },
													new Ticket { Price = 45.00, FlightId = 6 } }  }
		};
			context.Flights.AddRange(flights);
			context.SaveChanges();

			var departures = new List<Departure> {
			new Departure { FlightId=2, DepartureDate=DateTime.Parse("2018-01-11T15:45:00"), PlaneItem=new Plane { Name="Boeing 787",
				TypeOfPlane =new PlaneType { AirLift=244900 , Model="Boeing 787 Dreamliner", Seats=250  },
				ReleaseDate = DateTime.Parse("2010-10-15"), OperationLife=DateTime.Parse("2022-10-15")-DateTime.Parse("2010-10-15")},
				CrewItem =new Crew{ PilotId=1, Stewardesses=new List<Stewardess>(){ new Stewardess { Name ="Eve", Surname="Fairy", BirthDate = DateTime.Parse("2001-06-12") },
					new Stewardess { Name ="Samantha", Surname="Simson", BirthDate = DateTime.Parse("1999-12-03") }} } },
			new Departure {FlightId=3, DepartureDate=DateTime.Parse("2018-02-13T11:30:00"), PlaneItem=new Plane {Name="Boeing 737",
				TypeOfPlane =new PlaneType {AirLift=58100 , Model="Boeing 737-200", Seats=130 },
				ReleaseDate = DateTime.Parse("2013-02-01"), OperationLife=DateTime.Parse("2026-02-01")-DateTime.Parse("2013-02-01")},
				CrewItem =new Crew{PilotId=2, Stewardesses=new List<Stewardess>(){ new Stewardess { Name ="Gabrial", Surname="Fate", BirthDate = DateTime.Parse("1998-05-13")  }, new Stewardess { Name ="Hannah", Surname="Screw", BirthDate = DateTime.Parse("1993-07-08") }, new Stewardess {Name ="Jennah", Surname="Johns", BirthDate = DateTime.Parse("1996-04-03") },} } },
			new Departure { FlightId=5, DepartureDate=DateTime.Parse("2018-01-11T15:45:00"), PlaneItem=new Plane { Name="Boeing 777",
				TypeOfPlane =new PlaneType {AirLift=351800 , Model="Boeing 777-300", Seats=550  },
				ReleaseDate = DateTime.Parse("2012-09-01"), OperationLife=DateTime.Parse("2028-09-01")-DateTime.Parse("2012-09-01")},
				CrewItem =new Crew{PilotId=3, Stewardesses=new List<Stewardess>(){ new Stewardess {Name ="Hannah", Surname="Screw", BirthDate = DateTime.Parse("1993-07-08") }, new Stewardess { Name ="Jennah", Surname="Johns", BirthDate = DateTime.Parse("1996-04-03") }, new Stewardess { Name ="Ivory", Surname="Rocket", BirthDate = DateTime.Parse("1992-08-19")  }} } }

			};
			context.Departures.AddRange(departures);
			context.SaveChanges();



			var pilots = new List<Pilot> {
			new Pilot { Name="Adam", Surname="Benn", BirthDate=DateTime.Parse("1978-11-01"), Experience= DateTime.Today-DateTime.Parse("2004-12-01") },
			new Pilot { Name="Max", Surname="Payne", BirthDate=DateTime.Parse("1964-06-12"), Experience= DateTime.Today-DateTime.Parse("1987-03-24")},
			new Pilot { Name="Francis", Surname="Castle", BirthDate=DateTime.Parse("1974-02-01"), Experience= DateTime.Today-DateTime.Parse("1992-04-30") }
		};
			context.Pilots.AddRange(pilots);
			context.SaveChanges();

			var stewardesses = new List<Stewardess> {
			new Stewardess { Name ="Eve", Surname="Fairy", BirthDate = DateTime.Parse("2001-06-12") },
			new Stewardess { Name ="Samantha", Surname="Simson", BirthDate = DateTime.Parse("1999-12-03") },
			new Stewardess {Name ="Gabrial", Surname="Fate", BirthDate = DateTime.Parse("1998-05-13")  },
			new Stewardess { Name ="Hannah", Surname="Screw", BirthDate = DateTime.Parse("1993-07-08") },
			new Stewardess { Name ="Jennah", Surname="Johns", BirthDate = DateTime.Parse("1996-04-03") },
			new Stewardess {  Name ="Ivory", Surname="Rocket", BirthDate = DateTime.Parse("1992-08-19")  }
		};
			context.Stewardesses.AddRange(stewardesses);
			context.SaveChanges();

			var planeTypes = new List<PlaneType> {
			new PlaneType { AirLift=58100 , Model="Boeing 737-200", Seats=130 },
			new PlaneType { AirLift=244900 , Model="Boeing 787 Dreamliner", Seats=250  },
			new PlaneType { AirLift=351800 , Model="Boeing 777-300", Seats=550  }
		};
			context.PlaneTypes.AddRange(planeTypes);
			context.SaveChanges();
		}
	}
}

