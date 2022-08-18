using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Basketball
{
    public class Team
    {
        private readonly List<Player> players;

        public Team(string name, int openPositions, char group)
        {
            players = new List<Player>();
            Name = name;
            OpenPositions = openPositions;
            Group = group;
        }

        public string Name { get; set; }
        public int OpenPositions { get; set; }
        public char Group { get; set; }
        public int Count { get => players.Count; }

        public string AddPlayer(Player player)
        {
            if (OpenPositions > 0)
            {
                if (String.IsNullOrEmpty(player.Name) || String.IsNullOrEmpty(player.Position))
                {
                    return "Invalid player's information.";
                }
                else if (player.Rating < 80)
                {
                    return "Invalid player's rating.";
                }
                else
                {
                    players.Add(player);
                    OpenPositions--;
                    return $"Successfully added {player.Name} to the team. Remaining open positions: {OpenPositions}.";
                }
            }
            else
            {
                return "There are no more open positions.";
            }
        }

        public bool RemovePlayer(string name)
        {
            var playerToRemove = players.FirstOrDefault(x => x.Name == name);

            if (playerToRemove != null)
            {
                OpenPositions++;
            }
            return players.Remove(playerToRemove);
        }

        public int RemovePlayerByPosition(string position)
        { 
            var count = players.RemoveAll(x => x.Position == position);

            OpenPositions += count;
            return count;
        }

        public Player RetirePlayer(string name)
        {
            var playerToRetire = players.FirstOrDefault(x => x.Name == name);

            if (playerToRetire != null)
            {
                playerToRetire.Retired = true;
            }
            
            return playerToRetire;
        }

        public List<Player> AwardPlayers(int games)
        {
            List<Player> awardList = players.FindAll(x => x.Games >= games).ToList();
            return awardList;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Active players competing for Team {Name} from Group {Group}:");
            foreach (var player in players)
            {
                if (!player.Retired)
                {
                    sb.AppendLine(player.ToString());
                }
            }

            return sb.ToString().Trim();
        }
    }
}
