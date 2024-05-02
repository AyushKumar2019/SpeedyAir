using SpeedyAir.interfaces;
using SpeedyAir.models;
using SpeedyAir.services;
using Newtonsoft.Json;
using System.Linq;
using System.Net.Http.Json;

class Program
{
    static void Main(string[] args)
    {
        userstory1();
        userstory2();
    }

    public static List<Flight> LoadFlightsData()
    {

        var flights = new List<Flight>();
        string[] Destinations = { "YYZ", "YYC", "YVR","YYZ","YYC","YVR" };

        for (int i=0;i<Destinations.Count();i++)
        {
            var flight = new Flight();
            flight.Id = i+1;
            flight.departure = "YUL";
            flight.destination = Destinations[i];
            if(i>2)
            {
                flight.day++;
            }
            flights.Add(flight);
        }

        return flights;

    }

    public static void userstory1()
    {

        var flights = new List<Flight>();
        flights = LoadFlightsData();
        foreach (var flight in flights)
        {
            Console.WriteLine($"Flight:{flight.Id}, departure:{flight.departure}, arrival:{flight.destination} ,day:{flight.day}");
        }
    }
    public static void userstory2()
    {
        string filePath = @"coding-assigment-orders.json";
        var orders = new List<Order>();
        try
        {
            //Read the File & load into string
            string json = File.ReadAllText(filePath);

            //Desearlize the JSON String.
            var orders_ = JsonConvert.DeserializeObject<Dictionary<string, Order>>(json);
            if (orders_ != null)
            {   //cast the dictonary object into orders object.
                orders = orders_.Select(x => new Order { orderId = x.Key, destination = x.Value.destination }).ToList();
            }

        }
        catch (Exception ex)
        {
            Console.WriteLine("An Error Occured while loading Orders json file" + ex.Message);
        }


        var flights = new List<Flight>();
        flights = LoadFlightsData();
        OrderService orderService = new OrderService(orders);
        FlightService flightService = new FlightService(flights);
        var ordersNS = flightService.ScheduleFlights(orders); //it will schedule the flights and return the flights that are not being scheduled
        foreach (var flight in flights)
        {
            foreach (var order in flight.orders)
            {
                Console.WriteLine($"Order:{order.orderId}, flightNumber:{flight.Id},departure:{flight.departure} arrival:{flight.destination} ,day:{flight.day}");

            }
        }
        if (ordersNS.Count > 0)
        {
            foreach (var order in ordersNS)
            {
                Console.WriteLine($"order:{order.orderId},flightNumber:not scheduled");
            }
        }
    }

}