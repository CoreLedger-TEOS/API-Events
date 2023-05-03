# MQTT Web Protocol Demo

This is a simple example of an MQTT web client that connects to an MQTT broker and subscribes to the `invoice/*` topic. 

## Getting Started

To use this demo, you will need to have an MQTT broker running and accessible via a WebSocket endpoint. You can change the broker endpoint in the following line of code:

```js
const client = mqtt.connect('ws:localhost:15675/ws');
```

Replace `192.168.140.70:31090` with the address and port of your MQTT broker.
To change the topic that the client subscribes to, you can modify the following line of code:

```js
client.subscribe('invoice/', function (err) {
  if (!err) {
    postMessage('Successfully subscribed to invoice/ topic', 'success');
  } else {
    postMessage(Failed to subscribe to invoice/* topic: ${err.message}, 'error');
  }
});
```

Replace `invoice/*` with the topic that you want to subscribe to. 

## Usage

Once you have the MQTT broker endpoint and topic configured, you can simply open the `index.html` file in a web browser. The page will automatically connect to the broker and subscribe to the specified topic. Any messages received on this topic will be displayed on the page.
