using System;

namespace Ankn_Morpork.NPCs
{
    public class Player
    {
        public bool isAlive = true;

        public decimal moneyQuantity { get; set; }

        public bool playerAction { get; set; }

        public Player()
        {
            moneyQuantity = 100;
        }

    }
}
