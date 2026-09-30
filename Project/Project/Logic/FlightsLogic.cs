

//This class is not static so later on we can use inheritance and interfaces
public class FlightsLogic
{

    //Static properties are shared across all instances of the class
    //This can be used to get the current logged in account from anywhere in the program
    //private set, so this can only be set by the class itself
    private FlightsAccess _access = new();

    public FlightsLogic()
    {
        // Could do something here

    }

    public void UpdateFlight(FlightModel flight)
    {
        flight.Origin = flight.Origin.Trim();
        flight.Destination = flight.Destination.Trim();

        // Title Case - to do

        _access.Update(flight);
    }

    public FlightModel GetById(long id)
    {
        FlightModel flight = _access.GetById(id);
        return flight;
    }
}




