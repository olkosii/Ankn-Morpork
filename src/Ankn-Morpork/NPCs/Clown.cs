using System;
using System.Collections.Generic;

namespace Ankn_Morpork.NPCs
{
    public class Clown : GuildNPC
    {
        public ClownType name;
        public override decimal PlayerRewardForNPC { get; set; }

        private static Dictionary<int, decimal> clownsDictionary = SetClowns();

        private static Dictionary<int, decimal> SetClowns()
        {
            Dictionary<int, decimal> clowns = new Dictionary<int, decimal>(9);

            clowns.Add(1, 0.5m);
            clowns.Add(2, 1);
            clowns.Add(3, 2);
            clowns.Add(4, 3);
            clowns.Add(5, 5);
            clowns.Add(6, 6);
            clowns.Add(7, 7);
            clowns.Add(8, 8);
            clowns.Add(9, 10);

            return clowns;
        }

        private ClownType GetClownName()
        {
            Random rand = new Random();
            int clownId = rand.Next(1, 10);

            ClownType clown = (ClownType)clownId;
            return clown;
        }

        public Clown()
        {
            name = GetClownName();
            PlayerRewardForNPC = clownsDictionary[(int)name];
        }
        internal override void NPCPhrase()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"You meet : {name}, your old friend from Clown guild\nHe offers you a little extra money\n" +
                $"(If you don't need extra money you can skip)");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public override void PlayerMeetGuildNPC(Player player, GuildNPC npc, decimal reward)
        {
            Clown clown = (Clown)npc;

            player.moneyQuantity += reward;
        }
    }
    public enum ClownType
    {
        Muggins,
        Gull,
        Dupe,
        Butt,
        Fool,
        Tomfool,
        StupidFool,
        ArchFool,
        CompleteFool
    }
}
