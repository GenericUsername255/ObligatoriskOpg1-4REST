using System.Collections.Generic;
using ObligatoriskOpg1_4.Models;

namespace ObligatoriskOpg1_4.Managers
{
    public class FootballPlayersManager
    {
        private static int _nextId = 1;
        private static readonly List<FootballPlayer> Data = new List<FootballPlayer>
        {
            new FootballPlayer {Id = _nextId++, Name = "Hans Otto", Age = 22, ShirtNumber = 33 },
            new FootballPlayer {Id = _nextId++, Name = "Jonas Madsen", Age = 66, ShirtNumber = 99 },
        };

        public List<FootballPlayer> GetAll()
        {
            return new List<FootballPlayer>(Data);
        }

        public FootballPlayer GetById(int id)
        {
            return Data.Find(footballPlayer => footballPlayer.Id == id);
        }

        public FootballPlayer Add(FootballPlayer newFootballPlayer)
        {
            newFootballPlayer.Id = _nextId++;
            Data.Add(newFootballPlayer);
            return newFootballPlayer;
        }

        public FootballPlayer Delete(int id)
        {
            FootballPlayer footballPlayer = Data.Find(footballPlayer1 => footballPlayer1.Id == id);
            if (footballPlayer == null) return null;
            Data.Remove(footballPlayer);
            return footballPlayer;
        }

        public FootballPlayer Update(int id, FootballPlayer updates)
        {
            FootballPlayer footballPlayer = Data.Find(footballPlayer1 => footballPlayer1.Id == id);
            if (footballPlayer == null) return null;
            footballPlayer.Name = updates.Name;
            footballPlayer.Age = updates.Age;
            footballPlayer.ShirtNumber = updates.ShirtNumber;
            return footballPlayer;
        }
    }
}