using Travel.Entities.Airplanes.Contracts;

namespace Travel.Entities.Airplanes
{
	using System;
	using System.Collections;
	using System.Collections.Generic;
	using System.Collections.Immutable;
	using System.Linq;
	using Entities.Contracts;
    
	public abstract class Airplane:IAirplane
    {
        public int Seats { get; }
        public int BaggageCompartments { get; }

        private readonly List<IBag> baggageCompartment;
        private readonly List<IPassenger> passengers;
		protected Airplane(int seats, int baggageCompartments)
        {
			
			this.Seats = seats;
			this.BaggageCompartments = baggageCompartments;
			this.baggageCompartment = new List<IBag>();
            this.passengers = new List<IPassenger>();

		}
		
		public IReadOnlyCollection<IBag> BaggageCompartment => this.baggageCompartment.AsReadOnly();
		public IReadOnlyCollection<IPassenger> Passengers => this.passengers.AsReadOnly();
		public bool IsOverbooked => this.passengers.Count() > this.Seats;

        public void AddPassenger(IPassenger passenger)
        {
            this.passengers.Add(passenger);
        }

        public IPassenger RemovePassenger(int seatIndex)
        {
            IPassenger passenger = this.passengers[seatIndex];
			this.passengers.RemoveAt(seatIndex);

			return passenger;
		}

        public IEnumerable<IBag> EjectPassengerBags(IPassenger passenger)
        {
            var passengerBags = this.baggageCompartment
                .Where(b => b.Owner == passenger)
                .ToArray();

            foreach (var bag in passengerBags)
            {
                this.baggageCompartment.Remove(bag);
            }
            return passengerBags;
		}

		public void LoadBag(IBag bag)
        {
			var isBaggageCompartmentFull = this.BaggageCompartment.Count > this.BaggageCompartments;
			if (isBaggageCompartmentFull)
				throw new InvalidOperationException($"No more bag room in {this.GetType()}!");

			this.baggageCompartment.Add(bag);
		}
	}
}