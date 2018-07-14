using System;

using DALProject.Interefaces;
using DALProject.Models;
using DALProject.Repositories;

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

		public void SaveChanges()
		{
			mainDB.SaveChanges();
		}

		#region IDisposable Support
		private bool disposedValue = false;
		protected virtual void Dispose(bool disposing)
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
		// Этот код добавлен для правильной реализации шаблона высвобождаемого класса.
		void IDisposable.Dispose()
		{
			// Не изменяйте этот код. Разместите код очистки выше, в методе Dispose(bool disposing).
			Dispose(true);

		}
		#endregion
	}
}
