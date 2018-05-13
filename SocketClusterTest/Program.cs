using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace SocketClusterTest
{
    class Program
    {
        static async Task Main(string[] args)
        {
            SocketClusterService socketClusterService = new SocketClusterService();



            Console.WriteLine("Hello World!");
            //await Task.Delay(5000);

            socketClusterService.Socket.On("chat", (name, data) =>
            {
                Debug.WriteLine(data);
            });

            while (true)
            {
                await Task.Delay(1000);
                socketClusterService.Socket.Emit("chat", "Hello World!");
            }
        }
    }
}
