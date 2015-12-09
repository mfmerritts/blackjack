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

        private const int MAX_PLAYERS = 7;
        private NetworkObjects.PlayerListing playerListing;

        public GameServer()
        {
            this.playerListing = new NetworkObjects.PlayerListing();
        }

        public void start()
        {
            server.DataReceived += Server_DataReceived;
            server.Start();

            Console.WriteLine("Blackjack game server now running...");

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
            // Recieve join game message
            if (receivedObject is NetworkObjects.JoinGame)
            {
                Console.WriteLine("Incomming request from " + clientId.ToString());

                NetworkObjects.JoinGame joinMsg = receivedObject as NetworkObjects.JoinGame;

                // Check if game is full
                if (this.playerListing.NumPlayers() >= MAX_PLAYERS)
                {
                    SendPlayerJoinFailedMessage(clientId, "Game is currently full! Please try again later!");
                    return;
                }

                // TODO: Check other things

                // Player successfully joins game:
                AddPlayerToGame(joinMsg.Name, clientId);
            }

            //throw new NotImplementedException();
        }

        private void SendPlayerListingToPlayer(Guid clientId)
        {
            server.Send(this.playerListing, clientId);
        }

        private void SendPlayerJoinFailedMessage(Guid clientId, String reason)
        {
            NetworkObjects.JoinGameResponse response = new NetworkObjects.JoinGameResponse();
            response.Success = false;
            response.ResponseMessage = reason;

            server.Send(response, clientId);
        }

        private void AddPlayerToGame(String name, Guid newClientId)
        {
            this.playerListing.AddPlayer(name, newClientId);

            // Send new player the full player listing
            server.Send(this.playerListing, newClientId);

            // Send new player to all other players
            foreach(NetworkObjects.PlayerListing.Player player in this.playerListing.Players)
            {
                // Don't send message to new client
                if (player.clientId == newClientId)
                    continue;

                NetworkObjects.PlayerJoined newPlayerMsg = new NetworkObjects.PlayerJoined();
                newPlayerMsg.Name = name;

                server.Send(newPlayerMsg, player.clientId);
            }

            Console.WriteLine(name + " has joined the game.");
        }
    }
}