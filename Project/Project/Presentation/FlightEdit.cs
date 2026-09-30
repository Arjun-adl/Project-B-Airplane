public class FlightEdit
{
    private FlightsLogic _logic = new FlightsLogic();
    public void start()
    {
        Console.WriteLine($"Enter the flight ID to edit");
        string search = Console.ReadLine();

        FlightModel flight = _logic.GetById(int.Parse(search));

        if (flight != null)
        {
            flight = EditFlight(flight);
            _logic.UpdateFlight(flight);
            Console.WriteLine($"Flight with ID {search} has been updated.");
        }
        else
        {
            Console.WriteLine($"Flight with ID {search} not found.");
        }
    }

    public FlightModel EditFlight(FlightModel flight)
    {
        Console.WriteLine($"Enter new origin (current: {flight.Origin}):");
        string newOrigin = Console.ReadLine();
        Console.WriteLine($"Enter new destination (current: {flight.Destination}):");
        string newDestination = Console.ReadLine();
        Console.WriteLine($"Enter new departure time (current: {flight.DepartureTime}):");
        string newDepartureTime = Console.ReadLine();
        Console.WriteLine($"Enter new arrival time (current: {flight.ArrivalTime}):");
        string newArrivalTime = Console.ReadLine();
        Console.WriteLine($"Enter new price (current: {flight.Price}):");
        double newPrice = double.Parse(Console.ReadLine());

        flight.Origin = newOrigin;
        flight.Destination = newDestination;
        flight.DepartureTime = newDepartureTime;
        flight.ArrivalTime = newArrivalTime;
        flight.Price = (double)newPrice;

        return flight;
    }
}