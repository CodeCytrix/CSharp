using System.Net.Sockets;

String server = "127.0.0.1";
Int32 port = 13337;
String message = "hello server";

TcpClient client = new TcpClient(server, port);
NetworkStream stream = client.GetStream();

Byte[] data = System.Text.Encoding.ASCII.GetBytes(message);
stream.Write(data, 0, data.Length);

data = new Byte[256];
String responseData = String.Empty;
Int32 bytes = stream.Read(data, 0, data.Length);
responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes);

Console.WriteLine(responseData);
