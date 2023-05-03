using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Extensions.ManagedClient;
using MQTTnet.Protocol;

class Program
{
	static async Task Main(string[] args)
	{
		// Create an instance of the MQTT client factory
		var factory = new MqttFactory();

		// Create and manage an instance of the MQTT client
		// Note the use of 'using' to ensure proper disposal of resources
		using var mqttClient = factory.CreateManagedMqttClient();

		// Define the MQTT client options
		var options = new ManagedMqttClientOptionsBuilder()
			.WithAutoReconnectDelay(TimeSpan.FromSeconds(10)) // Set the delay for automatic reconnection
			.WithClientOptions(new MqttClientOptionsBuilder()
			.WithWebSocketServer($"192.168.140.70:31090/ws") // Set the MQTT broker endpoint
			.WithCleanSession() // Specify a clean session
			.Build())
			.Build();

		// Handle application messages received by the MQTT client
		mqttClient.ApplicationMessageReceivedAsync += e =>
		{
			Console.WriteLine("Received message:");
			Console.WriteLine($"\tTopic: {e.ApplicationMessage.Topic}");
			Console.WriteLine($"\tPayload: {e.ApplicationMessage.ConvertPayloadToString()}");

			return Task.CompletedTask;
		};

		mqttClient.ConnectingFailedAsync += e =>
		{
			Console.WriteLine($"Connection Failed: {e.Exception.Message}");
			return Task.CompletedTask;
		};

		mqttClient.ConnectedAsync += e =>
		{
			Console.WriteLine($"Connection Succeeded");
			return Task.CompletedTask;
		};

		// Start the MQTT client
		await mqttClient.StartAsync(options);

        // Subscribe to the "invoice/*" topic with quality of service at most once
        await mqttClient.SubscribeAsync(new[] { new MqttTopicFilterBuilder()
			.WithTopic("#")
			.WithQualityOfServiceLevel(MqttQualityOfServiceLevel.AtMostOnce)
			.Build() });

		// Wait for the user to press a key before stopping the MQTT client
		Console.WriteLine("Press any key to exit");
		Console.ReadKey();
	}
}
