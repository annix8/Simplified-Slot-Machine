using SlotMachine.Core.Models;
using SlotMachine.Core.Services;
using SlotMachine.Core.Services.Coefficient.Factory;
using System;

namespace SlotMachine.Core
{
    public class GameController
    {
        public void RunGameLoop()
        {
            bool startNewGame = true;
            while (startNewGame)
            {
                decimal deposit = RequestPlayerDeposit();
                Player player = CreatePlayer(deposit);
                SimpleSlotMachine slotMachine = CreateSlotMachine(player);
                slotMachine.RunMachineLoop();
                startNewGame = AskForNewGame();
            }
        }

        private decimal RequestPlayerDeposit()
        {
            Console.WriteLine("Please deposit money you would like to play with:");
            bool isMoney = decimal.TryParse(Console.ReadLine(), out decimal money);

            if (!isMoney)
            {
                // error
            }

            return money;
        }

        private Player CreatePlayer(decimal deposit)
        {
            var player = new Player()
            {
                Balance = deposit
            };

            return player;
        }

        private SimpleSlotMachine CreateSlotMachine(Player player)
        {
            return new SimpleSlotMachine(
                player,
                new RandomSymbolGenerator(new Random()),
                new SymbolCoefficientProviderFactory());
        }

        private bool AskForNewGame()
        {
            Console.WriteLine("Your balance is 0. Would you like to insert more to play again? Y/N");
            string result = Console.ReadLine().ToLower();

            return result == "y";
        }
    }
}
