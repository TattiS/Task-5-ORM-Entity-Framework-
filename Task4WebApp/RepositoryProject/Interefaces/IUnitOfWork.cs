using System;
using System.Collections.Generic;
using System.Text;
using DALProject.Models;
using DALProject.Repositories;

namespace DALProject.Interefaces
{
    interface IUnitOfWork
    {
		Repository<Flight> FlightsRepo { get;  }
		Repository<Departure> DeparturesRepo { get;  }
		Repository<Stewardess> StewardessesRepo { get; }
		Repository<Pilot> PilotsRepo { get;  }
		Repository<PlaneType> PlaneTypesRepo { get;  }

		void SaveChanges();
	}
}
