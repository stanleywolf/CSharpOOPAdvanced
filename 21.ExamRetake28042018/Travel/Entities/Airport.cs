namespace Travel.Entities
{
	using System;
	using System.Collections.Generic;
	using System.Linq;

	using Contracts;
	
	public class Airport:IAirport
	{
		private readonly List<IBag> checkedInBags;
		private readonly List<IBag> confiscatedBags;
		private readonly List<ITrip> trips;
		private readonly List<IPassenger> passangers;

	    public IReadOnlyCollection<IBag> CheckedInBags => this.checkedInBags.AsReadOnly();
	    public IReadOnlyCollection<IBag> ConfiscatedBags => this.confiscatedBags.AsReadOnly();
	    public IReadOnlyCollection<IPassenger> Passengers => this.passangers.AsReadOnly();
	    public IReadOnlyCollection<ITrip> Trips => this.trips.AsReadOnly();

        public Airport()
	    {
	        this.checkedInBags = new List<IBag>();
            this.confiscatedBags = new List<IBag>();
            this.trips = new List<ITrip>();
            this.passangers = new List<IPassenger>();
	    }

	    public IPassenger GetPassenger(string username)
	    {
	        IPassenger passenger = this.passangers.FirstOrDefault(c => c.Username == username);
	        return passenger;
	    }

	    public ITrip GetTrip(string id)
	    {
	        ITrip trip = this.trips.FirstOrDefault(c => c.Id == id);
	        return trip;
	    }
        
	    public void AddPassenger(IPassenger passenger)
	    {
	        this.passangers.Add(passenger);
	    }

	    public void AddTrip(ITrip trip)
	    {
	        this.trips.Add(trip);
	    }


	    public void AddCheckedBag(IBag bag)
	    {
	        this.checkedInBags.Add(bag);
	    }

	    public void AddConfiscatedBag(IBag bag)
	    {
	        this.confiscatedBags.Add(bag);
	    }
    }
}