using System.Collections.Generic;
using Travel.Entities.Contracts;

namespace Travel.Entities.Airplanes.Contracts
{
	public interface IAirplane
	{
	    int Seats { get; }
        int BaggageCompartments { get; }

		IReadOnlyCollection<IBag> BaggageCompartment { get; }
	    IReadOnlyCollection<IPassenger> Passengers { get; }

        bool IsOverbooked { get; }
        

		void AddPassenger(IPassenger passenger);

		IPassenger RemovePassenger(int seat);

		IEnumerable<IBag> EjectPassengerBags(IPassenger passenger);

		void LoadBag(IBag bag);
	}
}