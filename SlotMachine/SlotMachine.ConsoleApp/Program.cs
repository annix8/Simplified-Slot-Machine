using SlotMachine.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlotMachine.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var gameController = new GameController();
            decimal deposit = RequestPlayerDeposit();
            gameController.CreateNewGame(deposit);
        }

        //public void RunGameLoop()
        //{
        //    bool startNewGame = true;
        //    while (startNewGame)
        //    {
        //        decimal deposit = RequestPlayerDeposit();
        //        Player player = CreatePlayer(deposit);
        //        SimpleSlotMachine slotMachine = CreateSlotMachine(player);
        //        slotMachine.RunMachineLoop();
        //        startNewGame = AskForNewGame();
        //    }
        //}

        private static decimal RequestPlayerDeposit()
        {
            Console.WriteLine("Please deposit money you would like to play with:");
            bool isMoney = decimal.TryParse(Console.ReadLine(), out decimal money);

            while (!isMoney || money <= 0)
            {
                Console.WriteLine("Please enter a valid positive number");
                isMoney = decimal.TryParse(Console.ReadLine(), out money);
            }

            return money;
        }

        private static decimal RequestStake()
        {
            Console.WriteLine("Enter stake amount:");
            bool isNumber = decimal.TryParse(Console.ReadLine(), out decimal stakeAmount);
            while (!isNumber || stakeAmount <= 0)
            {
                Console.WriteLine("Please enter a valid number for stake amount that is bigger than 0");
                isNumber = decimal.TryParse(Console.ReadLine(), out stakeAmount);
            }

            return stakeAmount;
        }

        private static bool AskForNewGame()
        {
            Console.WriteLine("Your balance is 0. Would you like to insert more to play again? Y/N");
            string result = Console.ReadLine().ToLower();

            return result == "y";
        }
    }
}
