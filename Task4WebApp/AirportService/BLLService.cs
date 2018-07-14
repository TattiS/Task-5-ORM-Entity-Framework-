using System;
using System.Collections.Generic;
using AutoMapper;

using DALProject;
using DALProject.Models;
using DALProject.UnitOfWork;
using DTOLibrary.DTOs;

namespace AirportService
{
	public class BLLService : IBLLService
	{
		private static UnitOfWork unit;
		private static IMapper mapper;

		public BLLService(MainDBContext dBContext)
		{
			unit = new UnitOfWork(dBContext);

			var mapConfig = new MapperConfiguration(c =>
			{
				c.CreateMap<Flight, FlightDTO>().ReverseMap();
				c.CreateMap<Departure, DepartureDTO>().ReverseMap();
				c.CreateMap<Ticket, TicketDTO>().ReverseMap();
				c.CreateMap<Crew, CrewDTO>().ReverseMap();
				c.CreateMap<Pilot, PilotDTO>().ForMember(e => e.StartedIn, opt => opt.Ignore());
				c.CreateMap<PilotDTO, Pilot>().ForMember(e => e.Experience, opt => opt.MapFrom(src => (DateTime.Today.Subtract(src.StartedIn))));
				c.CreateMap<Plane, PlaneDTO>().ForMember(e => e.ExpiryDate, opt => opt.Ignore());
				c.CreateMap<PlaneDTO, Plane>().ForMember(e => e.OperationLife, opt => opt.MapFrom(src => (src.ExpiryDate.Subtract(src.ReleaseDate))));
				c.CreateMap<Stewardess, StewardessDTO>().ReverseMap();
				c.CreateMap<PlaneType, PlaneTypeDTO>().ReverseMap();
			});
			mapConfig.AssertConfigurationIsValid();
			if (mapper == null)
			{
				mapper = mapConfig.CreateMapper();
			}
		}

		public void CreateCrew(int departId, CrewDTO value)
		{
			var departure = unit.DeparturesRepo.GetEntityById(departId);
			if (departure != null)
			{
				var crew = mapper.Map<CrewDTO, Crew>(value);
				if (crew == null)
				{
					throw new Exception("Error: Can't add this crew to the the departure!");
				}
				departure.CrewItem = crew;
				unit.DeparturesRepo.Update(departure);
				unit.SaveChanges();
			}
			else
			{
				throw new Exception("Error: Can't find such departure!");
			}
		}

		public void CreateDeparture(DepartureDTO departure)
		{
			if (departure != null)
			{
				Departure newDepart = mapper.Map<DepartureDTO, Departure>(departure);
				unit.DeparturesRepo.Insert(newDepart);
				unit.SaveChanges();
			}
		}

		public void CreateFlight(FlightDTO flight)
		{
			if (flight == null)
			{
				Flight newFlight = mapper.Map<FlightDTO, Flight>(flight);
				unit.FlightsRepo.Insert(newFlight);
				unit.SaveChanges();
			}
		}

		public void CreatePilot(PilotDTO pilot)
		{
			if (pilot != null)
			{
				Pilot newPilot = mapper.Map<PilotDTO, Pilot>(pilot);
				unit.PilotsRepo.Insert(newPilot);
				unit.SaveChanges();
			}
		}

		public void CreatePlane(int departId, PlaneDTO value)
		{
			var departure = unit.DeparturesRepo.GetEntityById(departId);
			if (departure != null)
			{
				var plane = mapper.Map<PlaneDTO, Plane>(value);
				if (plane == null)
				{
					throw new Exception("Error: Can't add this crew to the the departure!");
				}
				departure.PlaneItem = plane;
				unit.DeparturesRepo.Update(departure);
				unit.SaveChanges();
			}
			else
			{
				throw new Exception("Error: Can't find such departure!");
			}
		}

		public void CreatePlaneType(PlaneTypeDTO planeType)
		{
			if (planeType != null)
			{
				PlaneType newPlaneType = mapper.Map<PlaneTypeDTO, PlaneType>(planeType);
				unit.PlaneTypesRepo.Insert(newPlaneType);
				unit.SaveChanges();
			}
		}

		public void CreateStewardess(StewardessDTO stewardess)
		{
			if (stewardess != null)
			{
				Stewardess newStewardess = mapper.Map<StewardessDTO, Stewardess>(stewardess);
				unit.StewardessesRepo.Insert(newStewardess);
			}
		}

		public void CreateTicket(int flightId, TicketDTO value)
		{
			var flight = unit.FlightsRepo.GetEntityById(flightId);
			if (flight != null)
			{
				var ticket = mapper.Map<TicketDTO, Ticket>(value);
				if (ticket == null)
				{
					throw new Exception("Error: Can't add this ticket to the the flight!");
				}
				flight.Tickets.Add(ticket);
				unit.FlightsRepo.Update(flight);
				unit.SaveChanges();
			}
			else
			{
				throw new Exception("Error: Can't find such flight!");
			}
		}

		public void DeleteCrew(int id)
		{
			var itemToDelete = unit.DeparturesRepo.GetEntities().Find(p => p.CrewItem.Id == id);
			if (itemToDelete != null)
			{
				itemToDelete.CrewItem = null;
				unit.DeparturesRepo.Update(itemToDelete);
				unit.SaveChanges();
			}
			else
			{
				throw new Exception("Can't find such crew!");
			}
		}

		public void DeleteDeparture(int id)
		{
			
			var departureToDelete = unit.DeparturesRepo.GetEntityById(id);
			if (departureToDelete != null)
			{
				unit.DeparturesRepo.Delete(id);
				unit.SaveChanges();
			}
			else
			{
				throw new Exception("Error: Cant't find such departure to delete.");
			}
		}
		
		public void DeleteFlight(int id)
		{
			var flightToDelete = unit.FlightsRepo.GetEntityById(id);
			if (flightToDelete != null)
			{
				unit.FlightsRepo.Delete(id);
				unit.SaveChanges();
			}
			else
			{
				throw new Exception("Error: Cant't find such flight to delete.");
			}
		}

		public void DeletePilot(int id)
		{
			var pilotToDelete = unit.PilotsRepo.GetEntityById(id);
			if (pilotToDelete != null)
			{
				unit.PilotsRepo.Delete(id);
				unit.SaveChanges();
			}
			else
			{
				throw new Exception("Error: Cant't find such pilot to delete.");
			}
		}

		public void DeletePlane(int id)
		{
			throw new NotImplementedException();
		}

		public void DeletePlaneType(int id)
		{
			var typeToDelete = unit.PlaneTypesRepo.GetEntityById(id);
			if (typeToDelete != null)
			{
				unit.PlaneTypesRepo.Delete(id);
				unit.SaveChanges();
			}
			else
			{
				throw new Exception("Error: Cant't find such type of plane to delete.");
			}
		}

		public void DeleteStewardess(int id)
		{
			var stewardessToDelete = unit.StewardessesRepo.GetEntityById(id);
			if (stewardessToDelete != null)
			{
				unit.StewardessesRepo.Delete(id);
				unit.SaveChanges();
			}
			else
			{
				throw new Exception("Error: Cant't find such stewardess to delete.");
			}
		}

		public void DeleteTicket(int id)
		{
			
			var itemToDelete = unit.FlightsRepo.GetEntities().Find(p => p.Tickets.Find(i => i.Id == id) != null);
			if (itemToDelete != null)
			{
				itemToDelete.Tickets.RemoveAll(p=>p.Id==id);
				unit.FlightsRepo.Update(itemToDelete);
				unit.SaveChanges();
			}
			else
			{
				throw new Exception("Can't find such ticket!");
			}
		}

		public CrewDTO GetCrewById(int id)
		{
			throw new NotImplementedException();
		}

		public List<CrewDTO> GetCrews()
		{
			throw new NotImplementedException();
		}

		public List<CrewDTO> GetCrewsBy(Predicate<CrewDTO> predicate)
		{
			throw new NotImplementedException();
		}

		public DepartureDTO GetDepartureById(int id)
		{
			throw new NotImplementedException();
		}

		public List<DepartureDTO> GetDepartures()
		{
			throw new NotImplementedException();
		}

		public FlightDTO GetFlightById(int id)
		{
			throw new NotImplementedException();
		}

		public List<FlightDTO> GetFlights()
		{
			throw new NotImplementedException();
		}

		public List<FlightDTO> GetFlightsByArrival(DateTime time)
		{
			throw new NotImplementedException();
		}

		public List<FlightDTO> GetFlightsByDeparture(DateTime time)
		{
			throw new NotImplementedException();
		}

		public List<FlightDTO> GetFlightsByDestination(string destination)
		{
			throw new NotImplementedException();
		}

		public List<FlightDTO> GetFlightsByPoint(string departurePoint)
		{
			throw new NotImplementedException();
		}

		public PilotDTO GetPilotById(int id)
		{
			throw new NotImplementedException();
		}

		public List<PilotDTO> GetPilots()
		{
			throw new NotImplementedException();
		}

		public PlaneDTO GetPlaneById(int id)
		{
			throw new NotImplementedException();
		}

		public List<PlaneDTO> GetPlanes()
		{
			throw new NotImplementedException();
		}

		public PlaneTypeDTO GetPlaneTypeById(int id)
		{
			throw new NotImplementedException();
		}

		public List<PlaneTypeDTO> GetPlaneTypes()
		{
			throw new NotImplementedException();
		}

		public StewardessDTO GetStewardessById(int id)
		{
			throw new NotImplementedException();
		}

		public List<StewardessDTO> GetStewardesses()
		{
			throw new NotImplementedException();
		}

		public List<TicketDTO> GetTickets()
		{
			throw new NotImplementedException();
		}

		public List<TicketDTO> GetTicketsByFlightId(int flightId)
		{
			throw new NotImplementedException();
		}

		public void UpdateCrew(CrewDTO value)
		{
			throw new NotImplementedException();
		}

		public void UpdateDeparture(DepartureDTO departure)
		{
			throw new NotImplementedException();
		}

		public void UpdateFlight(FlightDTO flight)
		{
			throw new NotImplementedException();
		}

		public void UpdatePilot(PilotDTO pilot)
		{
			throw new NotImplementedException();
		}

		public void UpdatePlane(PlaneDTO value)
		{
			throw new NotImplementedException();
		}

		public void UpdateStewardess(StewardessDTO stewardess)
		{
			throw new NotImplementedException();
		}

		public void UpdateTicket(TicketDTO value)
		{
			throw new NotImplementedException();
		}

		public void UpdateType(PlaneTypeDTO planeType)
		{
			throw new NotImplementedException();
		}
	}
}
