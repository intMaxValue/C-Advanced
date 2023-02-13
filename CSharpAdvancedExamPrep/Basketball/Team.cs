using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Basketball
{
    public class Team
    {
        public Team(string name, int openPositions, char group)
        {
            Name = name;
            OpenPositions = openPositions;
            Group = group;
            Players = new List<Player>();
        }

        public List<Player> Players { get; set; }
        public string Name { get; set; }
        public int OpenPositions { get; set; }
        public char Group { get; set; }

        public int Count { get => Players.Count; }

        public string AddPlayer(Player player)
        {
            if (OpenPositions <= 0)
            {
                return "There are no more open positions.";
            }

            if (player.Name == null || player.Position == null)
            {
                return "Invalid player's information.";
            }

            if (player.Rating < 80)
            {
                return "Invalid player's rating.";
            }

            Players.Add(player);
            OpenPositions -= 1;
            return $"Successfully added {player.Name} to the team. Remaining open positions: {OpenPositions}.";
        }

        public bool RemovePlayer(string name)
        {
            Player playerToRemove = Players.FirstOrDefault(p => p.Name == name);

            if (playerToRemove != null)
            {
                Players.Remove(playerToRemove);
                OpenPositions++;
                return true;
            }
            return false;
        }

        public int RemovePlayerByPosition(string position)
        {
            int initialCount = Players.Count();

            int removedPlayers = 0;

            Players.RemoveAll(p => p.Position == position);

            removedPlayers = initialCount - Players.Count;

            OpenPositions += removedPlayers;

            if (removedPlayers > 0)
            {
                return removedPlayers;
            }
            return 0;
        }

        public Player RetirePlayer(string name)
        {
            Player player = Players.FirstOrDefault(p=>p.Name == name);

            if (player != null)
            {
                player.Retired = true;
                return player;
            }
            return null;
        }

        public List<Player> AwardPlayers(int games)
        {
            List<Player> list = Players.Where(p=>p.Games >= games).ToList();

            return list;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Active players competing for Team {Name} from Group {Group}:");
            foreach (var player in Players.Where(p=>p.Retired == false))
            {
                sb.AppendLine(player.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}
