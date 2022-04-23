using System;

namespace Ankn_Morpork.NPCsInterface
{
    public interface IPlayer
    {
        bool isAlive { get; set; }

        decimal moneyQuantity { get; set; }

        bool playerAction { get; set; }
    }
}
