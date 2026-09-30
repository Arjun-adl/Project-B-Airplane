using Dapper;
using Microsoft.Data.Sqlite;

public class FlightsAccess
{
    private readonly SqliteConnection _connection = new("Data Source=DataSources/project.db");
    private const string Table = "Flights";

    public FlightsAccess()
    {
        string sql = $"CREATE TABLE IF NOT EXISTS {Table} (id INTEGER PRIMARY KEY AUTOINCREMENT, origin TEXT NOT NULL, destination TEXT NOT NULL, departuretime TEXT NOT NULL, arrivaltime TEXT NOT NULL, price REAL NOT NULL)";
        _connection.Execute(sql);
    }

    public void Write(FlightModel flight)
    {
        string sql = $"INSERT INTO {Table} (origin, destination, departuretime, arrivaltime, price) VALUES (@Origin, @Destination, @DepartureTime, @ArrivalTime, @Price)";
        _connection.Execute(sql, flight);
    }

    public FlightModel? GetById(long id)
    {
        string sql = $"SELECT * FROM {Table} WHERE id = @Id";
        return _connection.QueryFirstOrDefault<FlightModel>(sql, new { Id = id });
    }

    public IEnumerable<FlightModel> GetAll()
    {
        string sql = $"SELECT * FROM {Table}";
        return _connection.Query<FlightModel>(sql);
    }

    public void Update(FlightModel flight)
    {
        string sql = $"UPDATE {Table} SET origin = @Origin, destination = @Destination, departuretime = @DepartureTime, arrivaltime = @ArrivalTime, price = @Price WHERE id = @Id";
        _connection.Execute(sql, flight);
    }

    public void Delete(FlightModel flight)
    {
        string sql = $"DELETE FROM {Table} WHERE id = @Id";
        _connection.Execute(sql, new { Id = flight.Id });
    }
}