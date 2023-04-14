using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ__4
{
    internal class Program
    {
        public static void Main()
        {
            const int CountOfTops = 3;

            FactoryPlayer factoryPlayer = new FactoryPlayer();
            List<Player> players = new List<Player>(factoryPlayer.CreateList());

            Console.WriteLine(new string('_', 40));
            Console.WriteLine("Весь список игроков");
            PrintRecords(players);

            var topsLevel = players.OrderByDescending(player => player.Level).Take(CountOfTops);

            Console.WriteLine(new string('_', 40));
            Console.WriteLine("Топ по Уравню");
            PrintRecords(topsLevel);

            var topsPower = players.OrderByDescending(player => player.PowerPoints).Take(CountOfTops);

            Console.WriteLine(new string('_', 40));
            Console.WriteLine("Топ по очкам силы");
            PrintRecords(topsPower);
        }

        private static void PrintRecords(IEnumerable<Player> players)
        {
            foreach (var player in players)
            {
                player.ShowInfo();
            }
        }
    }

    public class Player
    {

        public Player(int level, int powerPoints, int id)
        {
            Level = level;
            PowerPoints = powerPoints;
            Id = id;
        }

        public int Level { get; }
        public int PowerPoints { get; }
        public int Id { get; }

        public void ShowInfo()
        {
            Console.WriteLine($"уравень {Level} сила {PowerPoints} ID {Id}");
        }
    }

    public class FactoryPlayer
    {
        private static readonly Random _random = new Random();
        private int _ids = 1;

        public List<Player> CreateList()
        {
            int maxLevel = 1000;
            int minLevel = 1;
            int maxPower = 500;
            int minPower = 1;
            int maxCountPlayer = 10;
            int minCountPlayer = 5;
            int randomCountPlayer = _random.Next(minCountPlayer, maxCountPlayer + 1);
            int level;
            int power;
            List<Player> players = new List<Player>();

            for (int i = 0; i < randomCountPlayer; i++)
            {
                level = _random.Next(minLevel, maxLevel + 1);
                power = _random.Next(minPower, maxPower + 1);

                players.Add(new Player(level, power, _ids));
                _ids++;
            }

            return players;
        }
    }
}