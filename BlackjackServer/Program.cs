using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackjackServer
{
    class Program
    {
        static void Main(string[] args)
        {
            GameServer server = new GameServer();

            Console.CancelKeyPress += delegate
            {
                Console.WriteLine("Ctrl+C caught, stopping server...");
                server.Stop();
            };

            
            server.start();
        }
    }
}
