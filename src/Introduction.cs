using System;

namespace Ankn_Morpork
{
    public static class Introduction
    {
        public static void GameIntroduction()
        {
            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine("\t\t\t\t\t\tWELCOME TO 'ANKN MORPORK'!!!!\n\n");
            Console.WriteLine("\t\t\t\tHere you can find lots of interesting people and a lot of dangerous.....\n");
            Console.WriteLine("\t\t\t\tYou should earn enough money in order to buy a ticket from this city");
            Console.WriteLine("\t\t\t\tBut until you, my friend, did't do it, be careful, good luck to you!!!\n\n");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.ForegroundColor = ConsoleColor.Green;
            
            Console.WriteLine("\tDuring the game you will meet members of different guilds,\nEach of them has its own rules and rewards for their services");
            Console.WriteLine("Initially, your money account is 100 Ankh-Morpork dollars\nYou should have 200 Ankh-Morpork dollars in order to leave this city\n");

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("\nYou can meet :");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\t-Assasins' guild");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("\nIs a school for professional killers,\nthis guild takes payment in the range of 5 to 30" +
                "\nbut each assasin has their own payment range\n- - - - -");

            Console.ForegroundColor= ConsoleColor.Blue;
            Console.WriteLine("\t-Beggars' Guild");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("\nIs the oldest, largest and (perhaps surprisingly) richest of the city's many guilds." +
                "\nIt has a very strict code of practice and enforced hierarchy\neach beggar has its own payment\n- - - - -");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\t-Guild of Thieves");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("\nBeing completely legal Guild of Thieves is responsible for ensuring a socially acceptable number of thefts." +
                "\nPlayer can get robbed anytime and will have to pay a standard fee\n in amount 10 AM$ to the guild member.\n" +
                "But total number of thefts during the game\n can’t be greater then socially acceptable number of thefts.\n- - - - -");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\t-Clown guild");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("\nWalking the city you may meet one of a very good friends," +
                "\nthey won't kill you and give you a chance to earn some money\n\n\n");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\t\t\t\t\t\t\tGAME STARTED\n\t\t\t\t\t\t\t------------\n");

            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
