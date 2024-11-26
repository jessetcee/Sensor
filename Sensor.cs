public class Sensor
{
    public string Name { get; private set; }
    public string Location { get; private set; }
    public double MinValue { get; private set; }
    public double MaxValue { get; private set; }
    public List<double> DataHistory { get; private set; }

    // Constructor initializes only the DataHistory
    public Sensor()
    {
        DataHistory = new List<double>();
    }

    // Function to initialize sensor properties
    public void InitialiseSensor(string name, string location, double minValue, double maxValue)
    {
        Name = name;
        Location = location;
        MinValue = minValue;
        MaxValue = maxValue;
    }
}
