public class SimulationEngine
{
    private static Random random = new Random();

    public double SimulateData(Sensor sensor)
    {
        if (random.NextDouble() < 0.05) // 5% fault probability
        {
            return GenerateFaultyData();
        }

        double baseReading = random.NextDouble() * (sensor.MaxValue - sensor.MinValue) + sensor.MinValue;
        double noise = random.NextDouble() * 0.4 - 0.2; // Noise between -0.2 and 0.2
        return baseReading + noise;
    }

    public double GenerateFaultyData()
    {
        return random.Next(30, 51); // Generate a spike between 30 and 50 degrees
    }

    public bool ValidateData(Sensor sensor, double data)
    {
        return data >= sensor.MinValue && data <= sensor.MaxValue;
    }
}
