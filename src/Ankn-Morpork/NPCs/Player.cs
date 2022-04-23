using Ankn_Morpork.NPCsInterface;
using System;

namespace Ankn_Morpork.NPCs
{
    public class Player : IPlayer
    {
        public decimal moneyQuantity { get; set; }

        public bool playerAction { get; set; }

        public bool isAlive { get; set; } = true;

        public Player()
        {
            moneyQuantity = 100;
        }
    }
}
