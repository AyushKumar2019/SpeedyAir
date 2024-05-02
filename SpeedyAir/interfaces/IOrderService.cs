using System;
using SpeedyAir.models;

namespace SpeedyAir.interfaces
{
	public interface IOrderService
	{
		List<Order> GetOrdersByDestination(string destination);
	}
}

