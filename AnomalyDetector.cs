public class AnomalyDetector
{
    public double SmoothData(IEnumerable<double> data, int windowSize)
    {
        if (data.Count() < windowSize)
        {
            return data.Average();
        }

        var recentData = data.Skip(Math.Max(0, data.Count() - windowSize));
        return recentData.Average();
    }

    public bool DetectAnomaly(Sensor sensor, double currentData)
    {
        var smoothedValue = SmoothData(sensor.DataHistory, 5);
        return Math.Abs(currentData - smoothedValue) > 2; // Example threshold
    }
}
