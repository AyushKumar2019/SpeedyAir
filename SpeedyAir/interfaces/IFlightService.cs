using System;
using SpeedyAir.models;

namespace SpeedyAir.interfaces
{
    public interface IFlightService
    {
        List<Order> ScheduleFlights(List<Order> orders);
    }
}

