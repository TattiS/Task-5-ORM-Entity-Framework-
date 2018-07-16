using System;
using System.Linq;
using System.Linq.Expressions;
using DALProject.Interefaces;
using DALProject.Models;
using DALProject.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DALProject.UnitOfWork
{
	public class UnitOfWork:IUnitOfWork, IDisposable
    {
		private MainDBContext mainDB;
		private Repository<Flight> flights;
		private Repository<Departure> departures;
		private Repository<Stewardess> stewardesses;
		private Repository<Pilot> pilots;
		private Repository<PlaneType> planeTypes;
		private CrewRepository crewRepository;

		public UnitOfWork(MainDBContext dBContext)
		{
			mainDB = dBContext;
		}

		public Repository<Flight> FlightsRepo
		{
			get {
				if (this.flights == null)
				{
					this.flights = new Repository<Flight>(mainDB);
				}
				return this.flights;
			}
		}
		public Repository<Departure> DeparturesRepo
		{
			get
			{
				if (this.departures == null)
				{
					this.departures = new Repository<Departure>(mainDB);
				}
				return this.departures;
			}
		}
		public Repository<Stewardess> StewardessesRepo
		{
			get
			{
				if (this.stewardesses == null)
				{
					this.stewardesses = new Repository<Stewardess>(mainDB);
				}
				return this.stewardesses;
			}
		}
		public Repository<Pilot> PilotsRepo
		{
			get
			{
				if (this.pilots == null)
				{
					this.pilots = new Repository<Pilot>(mainDB);
				}
				return this.pilots;
			}
		}
		public Repository<PlaneType> PlaneTypesRepo
		{
			get
			{
				if (this.planeTypes == null)
				{
					this.planeTypes = new Repository<PlaneType>(mainDB);
				}
				return this.planeTypes;
			}
		}
		public CrewRepository CrewRepository
		{
			get
			{
				if (this.crewRepository == null)
				{
					this.crewRepository = new CrewRepository(mainDB);
				}
				return this.crewRepository;
			}
		}

		public void SaveChanges()
		{
			mainDB.SaveChanges();
		}

		
		#region IDisposable Support
		private bool disposedValue = false;
		public virtual void Dispose(bool disposing)
		{
			if (!disposedValue)
			{
				if (disposing)
				{
					mainDB.Dispose();
				}

				disposedValue = true;
			}
		}
		
		void IDisposable.Dispose()
		{
			Dispose(true);

		}
		#endregion
	}
}
