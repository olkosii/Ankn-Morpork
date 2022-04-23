using Ankn_Morpork.NPCs;
using Ankn_Morpork.NPCsInterface;
using System;

namespace Ankn_Morpork.GameMessages
{
    public class MeetNPCMessages
    {
        internal static void NPCPhrase(IGuildNPC npc)
        {
            if(npc is Assasin)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You meet : Assasin guild, it means somebody in the city ordered your death\n" +
                    "Can you pay more than your enemies?) (assasins don't tell their reward, you have to guess it)");
                Console.WriteLine("(If you pay more than your enemy you will stay alive,if you skip you will die)");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else if(npc is Beggar beggar)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                if (beggar.name == BeggarType.Drinker)
                {
                    Console.WriteLine($"You meet : {beggar.name} from Beggar guild\nHe will not chase you to death(you can continue or skip and stay alive)");
                    Console.ForegroundColor = ConsoleColor.White;
                    return;
                }
                Console.WriteLine($"You meet : {beggar.name} from Beggar guild\nGive him some money or he will chase you to death\n" +
                    $"(If you skip ,you will not be able to do anything, so you will die)");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else if(npc is Clown clown)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"You meet : {clown.name}, your old friend from Clown guild\nHe offers you a little extra money\n" +
                    $"(If you don't need extra money you can skip)");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else if(npc is Thief thief)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                if (thief.acceptableAmountOfThefts < Thief.currentAmountOfThief)
                {
                    Console.WriteLine("You meet : Thief guild, but thieves have exceeded the socially acceptable number of thefts : 6\n" +
                        "So if you skip, they won't take the money and you will stay alive");
                    Console.ForegroundColor = ConsoleColor.White;

                    return;
                }
                Console.WriteLine("You meet : Thief guild, be careful, If you resist, you might get hurt");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }
}
