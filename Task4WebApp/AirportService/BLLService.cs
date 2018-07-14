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
			throw new NotImplementedException();
		}

		public void CreateDeparture(DepartureDTO departure)
		{
			throw new NotImplementedException();
		}

		public void CreateFlight(FlightDTO flight)
		{
			throw new NotImplementedException();
		}

		public void CreatePilot(PilotDTO pilot)
		{
			throw new NotImplementedException();
		}

		public void CreatePlane(int departId, PlaneDTO value)
		{
			throw new NotImplementedException();
		}

		public void CreatePlaneType(PlaneTypeDTO planeType)
		{
			throw new NotImplementedException();
		}

		public void CreateStewardess(StewardessDTO stewardess)
		{
			throw new NotImplementedException();
		}

		public void CreateTicket(int flightId, TicketDTO value)
		{
			throw new NotImplementedException();
		}

		public void DeleteCrew(int id)
		{
			throw new NotImplementedException();
		}

		public void DeleteDeparture(int id)
		{
			throw new NotImplementedException();
		}

		public void DeleteFlight(int id)
		{
			throw new NotImplementedException();
		}

		public void DeletePilot(int id)
		{
			throw new NotImplementedException();
		}

		public void DeletePlane(int id)
		{
			throw new NotImplementedException();
		}

		public void DeletePlaneType(int id)
		{
			throw new NotImplementedException();
		}

		public void DeleteStewardess(int id)
		{
			throw new NotImplementedException();
		}

		public void DeleteTicket(int id)
		{
			throw new NotImplementedException();
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
