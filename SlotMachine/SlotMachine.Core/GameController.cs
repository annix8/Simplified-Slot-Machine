using SlotMachine.Core.Models;
using SlotMachine.Core.Services;
using SlotMachine.Core.Services.Coefficient.Factory;
using System;
using System.Collections.Generic;
using System.Text;

namespace SlotMachine.Core
{
    public class GameController
    {
        public void RunGameLoop()
        {
            while (true)
            {
                decimal deposit = RequestPlayerDeposit();
                Player player = CreatePlayer(deposit);
                SimpleSlotMachine slotMachine = CreateSlotMachine(player);
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
    }
}
