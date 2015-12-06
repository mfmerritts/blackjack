using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkObjects
{
    public class JoinGame
    {
        public string Name { get; set; }
    }

    public class JoinGameResponse
    {
        public bool Success { get; set; }
        public string ResponseMessage { get; set; }
    }

    public class PlayerJoined
    {
        public string Name { get; set; }
    }

    public class PlayerListing
    {
        public class Player
        {
            public String Name { get; set; }
            public Guid clientId { get; set; }
        }

        public PlayerListing()
        {
            Players = new List<Player>();
        }

        public int NumPlayers()
        {
            return Players.Count;
        }

        public void AddPlayer(String name, Guid _clientId)
        {
            Player p = new Player();
            p.Name = name;
            p.clientId = _clientId;

            Players.Add(p);
        }

        public List<Player> Players { get; set; }
    }
}
