using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

class Server
{
    private TcpListener listener;
    private int port;
    string command;
    string latestCommand;

    public Server(int port)
    {
        this.port = port;
    }

    public async Task Start()
    {
        listener = new TcpListener(IPAddress.Loopback, port);
        listener.Start();
        Console.WriteLine("Server started.");

        while (true)
        {
            Console.WriteLine("Waiting for a client...");
            TcpClient client = await listener.AcceptTcpClientAsync();
            Console.WriteLine("Client connected.");

            NetworkStream stream = client.GetStream();

            while (client.Connected)
            {
                byte[] data = new byte[client.Available];
                await stream.ReadAsync(data, 0, data.Length);
                string command = Encoding.ASCII.GetString(data);

            }

            Console.WriteLine("Client disconnected.");
        }
    }
    public bool HasCommand()
    {
        latestCommand = command;
        return !string.IsNullOrEmpty(latestCommand);
    }

    public string GetCommand()
    {
        latestCommand = null;
        return command;
    }

    public void Stop()
    {
        listener.Stop();
        Console.WriteLine("Server stopped.");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Server server = new Server(8888);
        Task.Run(async () => await server.Start());
    }
}
