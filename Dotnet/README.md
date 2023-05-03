# MQTT Web Client Example

This is a simple example of an MQTT web client using the MQTTnet library in C#.

## Requirements

- [.NET 6 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)

## Usage

1. Clone this repository to your local machine.
2. Open a terminal window and navigate to the directory where the project is located: ../Mqtt-Web/Dotnet/mqtt.
3. Modify the `Program.cs` file to listen to your desired MQTT broker and topic.
4. Run the command `dotnet run` to start the application.
5. Press any key to exit the application.

## Configuration

The MQTT client is configured in the `Program.cs` file. Here are the options you can modify:

```csharp
// Set the MQTT broker endpoint
    .WithWebSocketServer("localhost:15675/ws") 

// Subscribe to the "invoice/*" topic with quality of service at most once
    .WithTopic("invoice/*")
