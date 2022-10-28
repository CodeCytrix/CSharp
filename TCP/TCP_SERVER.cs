using System.Net.Sockets;

Int32 port = 13337;
IPAddress localAddr = IPAddress.Parse("127.0.0.1");

TcpListener server = new TcpListener(localAddr, port);
server.Start();

Byte[] bytes = new Byte[256];
String data = null;

while(true)
{
    using TcpClient client = server.AcceptTcpClient();
    Console.WriteLine("Connected!");
    data = null;

    NetworkStream stream = client.GetStream();
    int i;
    while((i = stream.Read(bytes, 0, bytes.Length))!=0)
    {
        data = System.Text.Encoding.ASCII.GetString(bytes, 0, i);
        Console.WriteLine("Received: {0}", data);

        string message = "hello client" 
        byte[] msg = System.Text.Encoding.ASCII.GetBytes(message);
        stream.Write(msg, 0, msg.Length);
        Console.WriteLine("Sent: {0}", data);
    }
    client.Close();
}
server.Stop();