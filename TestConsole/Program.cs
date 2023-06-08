using LoggerService;
using RemoteAccessService;

void OnMessageReceived(RemoteAccessMessage message)
{
    if (message == null)
        return;

    var senderFriendlyName = message.GetSenderFriendlyName();

    if (message.command == "Hello")
    {
        Console.WriteLine("Hello, World!");
    } else
    {
        Console.WriteLine("Unknown message");
    }
}

var ip = "10.0.0.2";
var port = 35598;
var key = "abrakadabra";

var remoteAccesssServer = new RemoteAccessService.RemoteAccessService(new BasicLoggingService());
remoteAccesssServer.SetConnection(ip, port, key);
remoteAccesssServer.StartListening(OnMessageReceived, "Server");

var remoteAccesssClient = new RemoteAccessService.RemoteAccessService(new BasicLoggingService());
remoteAccesssClient.SetConnection(ip, port, key);
remoteAccesssClient.SendMessage(new RemoteAccessMessage()
{
     command = "Hello"
});