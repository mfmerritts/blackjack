using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkObjects
{
    public class ClientHello
    {
        public string PlayerName { get; set; }

        public int Value { get; set; }
    }

    public class JoinGame
    {
        public string GameToJoin { get; set; }
    }

    public class PlayerListing
    {
        public PlayerListing()
        {
            PlayerNames = new List<string>();
        }

        public List<string> PlayerNames { get; set; }
    }
}
