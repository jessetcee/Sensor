using Xunit;

public class SensorTests
{
    [Fact]
    public void TestValidateData_WithinRange_ReturnsTrue()
    {
        Sensor sensor = new Sensor("Test", "Test Location", 20, 30);
        Assert.True(sensor.ValidateData(25));
    }

    [Fact]
    public void TestDetectAnomaly_SpikeDetected_ReturnsTrue()
    {
        Sensor sensor = new Sensor("Test", "Test Location", 20, 30);
        sensor.AddToHistory(22);
        sensor.AddToHistory(23);
        sensor.AddToHistory(24);
        sensor.AddToHistory(25);
        sensor.AddToHistory(26);


        bool anomaly = sensor.DetectAnomaly(27); // Spike
        Assert.True(anomaly);
    }
}
