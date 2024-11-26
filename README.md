Temperature Sensor Simulation - README
Project Overview

This application simulates a temperature sensor system for a data centre, generating temperature readings, validating them, detecting anomalies, logging data, and simulating sensor faults like spikes or failures.
Setup Instructions
Prerequisites

    .NET 6.0 or later
    Visual Studio (or any C# IDE)

Installation

    Clone the repository:

git clone https://github.com/your-username/temperature-sensor-simulation.git

Restore NuGet packages:

dotnet restore

Add config.txt with sensor data (e.g. Sensor1, Data Centre Room 1, 22, 24).
Run the app:

    dotnet run

Functions
1. InitialiseSensor

Initializes a sensor with a name, location, and range.

Sensor sensor1 = sensorManager.InitialiseSensor("Sensor1", "Room 1", 22, 24);

2. SimulateData

Generates a simulated temperature reading with noise.

double simulatedData = simulationEngine.SimulateData(sensor1);

3. ValidateData

Validates if the data is within the acceptable range.

if (simulationEngine.ValidateData(sensor1, simulatedData))
{
    Console.WriteLine("Valid data.");
}

4. DetectAnomaly

Detects anomalies like sudden spikes.

if (anomalyDetector.DetectAnomaly(sensor1, simulatedData))
{
    Console.WriteLine("Anomaly detected!");
}

5. LogData

Logs a message to the console or file.

logger.LogData($"Sensor {sensor1.Name} generated data: {simulatedData}");

6. StoreData

Stores sensor data for analysis.

sensor1.DataHistory.Add(simulatedData);

Testing
Unit Testing

Each method was tested. For example, SimulateData ensures readings are within range.
Integration Testing

Full system tests ensure data flows correctly from simulation to validation and logging.

This README provides an overview, setup instructions, function descriptions, and testing procedures for the temperature sensor simulation application.
