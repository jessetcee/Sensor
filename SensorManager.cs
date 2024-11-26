public class SensorManager
{
    public List<Sensor> Sensors { get; private set; } = new List<Sensor>();

    public void LoadConfiguration(string filePath)
    {
        var lines = File.ReadAllLines(filePath);
        foreach (var line in lines)
        {
            var parts = line.Split(',');
            Sensor sensor = new Sensor();
            sensor.InitialiseSensor(parts[0], parts[1], double.Parse(parts[2]), double.Parse(parts[3]));
            Sensors.Add(sensor);
        }
    }
}
