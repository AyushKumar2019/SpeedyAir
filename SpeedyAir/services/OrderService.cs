using System;
using SpeedyAir.interfaces;
using SpeedyAir.models;

namespace SpeedyAir.services
{
	public class OrderService:IOrderService
	{
        private List<Order> orders;

        public OrderService(List<Order> orders)
        {
            this.orders = orders;
        }

        public List<Order> GetOrdersByDestination(string destination)
        {
            return orders.Where(o => o.destination == destination).ToList();
        }
    }
}

