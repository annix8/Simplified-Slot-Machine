using SlotMachine.Core.Models;
using SlotMachine.Core.Models.Dto;
using SlotMachine.Core.Services;
using SlotMachine.Core.Services.Coefficient.Factory;
using System;

namespace SlotMachine.Core
{
    public class GameController
    {
        private SimpleSlotMachine _slotMachine;
        private Player _player;

        public bool CreateNewGame(decimal playerDeposit)
        {
            if (playerDeposit <= 0)
            {
                return false;
            }

            _player = new Player()
            {
                Balance = playerDeposit
            };
            _slotMachine = CreateSlotMachine(_player);

            return true;
        }

        public SlotMachineSpinResultDto SpinMachine(decimal stakeAmount)
        {
            if (_player.Balance < stakeAmount)
            {
                return new SlotMachineSpinResultDto()
                {
                    IsSuccess = false,
                    ResultMessage = "Insufficient balance"
                };
            }

            SlotMachineSpinResultDto spinResult = _slotMachine.Spin(stakeAmount);

            return spinResult;
        }

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

            while (!isMoney || money <= 0)
            {
                Console.WriteLine("Please enter a valid positive number");
                isMoney = decimal.TryParse(Console.ReadLine(), out money);
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
