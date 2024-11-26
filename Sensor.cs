public class Sensor
{
    public string Name { get; set; }
    public string Location { get; set; }
    public double MinValue { get; set; }
    public double MaxValue { get; set; }
    public List<double> DataHistory { get; set; }

    public void AddToHistory(double value)
    {
        DataHistory.Add(value);
    }

    public bool ValidateData(double value)
    {
        return value >= MinValue && value <= MaxValue;
    }
    public double SmoothData(int windowSize = 5)
    {
        if (DataHistory.Count < windowSize)
        {
            throw new InvalidOperationException("Not enough data to smooth.");
        }

        double sum = 0;
        for (int i = DataHistory.Count - windowSize; i < DataHistory.Count; i++)
        {
            sum += DataHistory[i];
        }

        return sum / windowSize;
    }

    public bool DetectAnomaly(double value)
    {
        if (DataHistory.Count < 5) return false; // Not enough data for anomaly detection

        double average = SmoothData(5);
        return Math.Abs(value - average) > (MaxValue - MinValue) * 0.2; // 20% deviation
    }

    public Sensor(string name, string location, double minValue, double maxValue)
    {
        Name = name;
        Location = location;
        MinValue = minValue;
        MaxValue = maxValue;
        DataHistory = new List<double>();
    }
}
