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
            List<Player> players = new List<Player>(factoryPlayer.Create());

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
        public int Level { get; }
        public int PowerPoints { get; }
        public int Id { get; }

        public Player(int level, int powerPoints, int id)
        {
            Level = level;
            PowerPoints = powerPoints;
            Id = id;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"уравень {Level} сила {PowerPoints} ID {Id}");
        }
    }

    public class FactoryPlayer
    {
        private static readonly Random s_random = new Random();
        private int s_ids = 1;

        public List<Player> Create()
        {
            int maxLevel = 1000;
            int minLevel = 1;
            int maxPower = 500;
            int minPower = 1;
            int maxCountPlayer = 10;
            int minCountPlayer = 5;
            int randomCountPlayer = s_random.Next(minCountPlayer, maxCountPlayer + 1);
            int level;
            int power;
            List<Player> players = new List<Player>();

            for (int i = 0; i < randomCountPlayer; i++)
            {
                level = s_random.Next(minLevel, maxLevel + 1);
                power = s_random.Next(minPower, maxPower + 1);

                players.Add(new Player(level, power, s_ids));
                s_ids++;
            }

            return players;
        }
    }
}