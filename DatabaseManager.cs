public class DatabaseManager
{
    private Dictionary<string, List<double>> database = new Dictionary<string, List<double>>();

    public void StoreData(Sensor sensor, double data)
    {
        if (!database.ContainsKey(sensor.Name))
        {
            database[sensor.Name] = new List<double>();
        }
        database[sensor.Name].Add(data);
    }

    public IEnumerable<double> GetDataHistory(Sensor sensor)
    {
        return database.ContainsKey(sensor.Name) ? database[sensor.Name] : Enumerable.Empty<double>();
    }
}
