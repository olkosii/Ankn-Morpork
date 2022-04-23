using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ankn_Morpork.GameMessages
{
    public class EndGameReason
    {
        public const string winMessage = "\t\t\t\tCONGRATULATIONS!!!\n\t\tYou have earned enough money to leave Ankn Morpork";
        public const string diedMessage = "YOU DIED...";
        public const string notSuitablePlayerRewardMessage = "YOU DIED...\nThis Assassin wouldn't accept reward of that amount";
        public const string assasinKillMessage = "YOU DIED...\nAssasin killed you";
        public const string thiefKillMessage = "YOU DIED...\nYou resisted and thief killed you";
        public const string beggarKillMessage = "YOU DIED...\nBeggar chase you to death";
        public const string playerDidNotHaveEnoughMoneyForBeggarMessage = "YOU DIED...\nYou didn't have enough money in order to pay Beggar guild";
        public const string playerDidNotHaveEnoughMoneyForAssasinMessage = "YOU DIED...\nYou didn't have enough money in order to pay Assasin guild";
        public const string playerDidNotHaveEnoughMoneyForThiefMessage = "YOU DIED...\nYou didn't have enough money in order to pay Thief guild";
    }
}
