using System;
using SpeedyAir.interfaces;
using SpeedyAir.models;

namespace SpeedyAir.services
{
	public class FlightService :IFlightService
	{
		private List<Flight> flights;
		public FlightService(List<Flight>flights)
		{
			this.flights = flights;
		}

		public List<Order> ScheduleFlights(List<Order> orders)
		{
			var ordersNS = new List<Order>();
			foreach (var order in orders)
			{
				var flight = flights.FirstOrDefault(f => f.orders.Count<f.capacity && f.destination == order.destination);
				if (flight == null)
				{
					//Add the order in orders List
					ordersNS.Add(order);
					//throw new InvalidOperationException("There is no Flight Available for this order");
				}
				else
				{
					flight.AddOrder(order);
				}

			}
			return ordersNS;
		}
	}
}

