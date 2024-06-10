using System.Net.Sockets;
using System.Net;
using System.Text;
using Microsoft.EntityFrameworkCore;
using BitirmeProjesi.DataContext;
using BitirmeProjesi.Models;
using System.Xml;

namespace BitirmeProjesi.TcpServer
{
    public class TcpServer 
    {

        private readonly IServiceProvider _serviceProvider;

        public TcpServer( IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task StartAsync()
        {
            var listener = new TcpListener(IPAddress.Parse("192.168.1.100"), 5005);
            listener.Start();
            Console.WriteLine("TCP server is listening...");

            while (true)
            {
                var client = await listener.AcceptTcpClientAsync();
                _ = HandleClientAsync(client);
            }
        }

        private async Task HandleClientAsync(TcpClient client)
        {
            using var scope = _serviceProvider.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<BitirmeProjesiDbContext>();

            using var networkStream = client.GetStream();
            var buffer = new byte[1024];
            var byteCount = await networkStream.ReadAsync(buffer, 0, buffer.Length);
            var data = Encoding.UTF8.GetString(buffer, 0, byteCount);


            string xmlString = data;

 

        }




    }
}

