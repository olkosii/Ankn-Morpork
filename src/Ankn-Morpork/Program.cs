using Ankn_Morpork.Controllers;
using Ankn_Morpork.GameIntroduction;
using Ankn_Morpork.NPCs;
using System;

namespace Ankn_Morpork
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Introduction.GameIntroduction();

            Player player = new Player();
            GameController controller = new GameController();

            controller.GameStart(player);
            Console.WriteLine(controller.GameEnd(player, controller._currentNPC, controller.playerAction));

            Console.Read();
        }
    }
}
