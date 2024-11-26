class Program
{
    static void Main(string[] args)
    {
        SensorManager sensorManager = new SensorManager();
        SimulationEngine simulationEngine = new SimulationEngine();
        Logger logger = new Logger("SensorLogs.txt");
        DatabaseManager databaseManager = new DatabaseManager();
        AnomalyDetector anomalyDetector = new AnomalyDetector();

        sensorManager.LoadConfiguration("ConfigFilePath.txt");

        while (true)
        {
            foreach (var sensor in sensorManager.Sensors)
            {
                Console.WriteLine($"Simulating for sensor: {sensor.Name}");
                double simulatedData = simulationEngine.SimulateData(sensor);

                if (simulationEngine.ValidateData(sensor, simulatedData))
                {
                    Console.WriteLine($"Valid data: {simulatedData}");
                    logger.LogData($"Sensor {sensor.Name}: {simulatedData} °C");
                    databaseManager.StoreData(sensor, simulatedData);
                    sensor.DataHistory.Add(simulatedData);
                    

                    if (anomalyDetector.DetectAnomaly(sensor, simulatedData))
                    {
                        logger.LogData($"Anomaly detected for Sensor {sensor.Name}: {simulatedData} °C");
                        Console.WriteLine($"Anomaly detected for Sensor {sensor.Name}");
                    }
                }
                else
                {
                    Console.WriteLine($"Invalid data detected for Sensor {sensor.Name}");
                }
            }

            Thread.Sleep(1000); // Wait for 1 second
        }
    }
}
