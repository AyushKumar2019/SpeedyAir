using System;
namespace SpeedyAir.models
{
	public class Flight
	{
		public int Id { get; set; }
		public string? destination { get; set; }
		public int day { get; set; } = 1;
        public string? departure { get; set; }
        public int capacity { get; } = 20;
		public List<Order> orders { get; set; } = new List<Order>();
		public bool AddOrder(Order order) {
			if (orders.Count < capacity)
			{
				orders.Add(order);
				return true;
			}
			return false;
		}
	}
}

