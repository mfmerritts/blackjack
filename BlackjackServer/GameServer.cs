using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackjackServer
{
    class GameServer
    {
        private EasyNetwork.Server server = new EasyNetwork.Server("tcp://*:3000");
        private bool isRunning = true;

        public void start()
        {
            server.DataReceived += Server_DataReceived;
            server.Start();

            while (isRunning)
            {
                System.Threading.Thread.Sleep(1000);
            }

            server.Stop();
        }

        public void Stop()
        {
            isRunning = false;
        }

        private void Server_DataReceived(object receivedObject, Guid clientId)
        {
            throw new NotImplementedException();
        }
    }
}