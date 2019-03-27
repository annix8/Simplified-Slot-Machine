using SlotMachine.Core.Models;
using SlotMachine.Core.Models.Symbols;
using SlotMachine.Core.Services;
using SlotMachine.Core.Services.Coefficient;
using SlotMachine.Core.Services.Coefficient.Factory;
using System;
using System.Collections.Generic;

namespace SlotMachine.Core
{
    internal class SimpleSlotMachine
    {
        private const int Rows = 4;
        private const int NumberOfSymbolsOnARow = 3;

        private readonly Player _player;
        private readonly RandomSymbolGenerator _randomSymbolGenerator;
        private readonly SymbolCoefficientProviderFactory _symbolCoefficientProviderFactory;

        public SimpleSlotMachine(Player player,
            RandomSymbolGenerator randomSymbolGenerator,
            SymbolCoefficientProviderFactory symbolCoefficientProviderFactory)
        {
            _player = player;
            _randomSymbolGenerator = randomSymbolGenerator;
            _symbolCoefficientProviderFactory = symbolCoefficientProviderFactory;
        }

        // TODO: remove calls to Console and implement reader and writers
        public void RunMachineLoop()
        {
            while(_player.Balance > 0)
            {
                RequestStake();
            }
        }

        private void RequestStake()
        {
            Console.WriteLine("Enter stake amount:");
            bool isNumber = decimal.TryParse(Console.ReadLine(), out decimal stakeAmount);
            while (!isNumber || stakeAmount <= 0)
            {
                Console.WriteLine("Please enter a valid number for stake amount that is bigger than 0");
                isNumber = decimal.TryParse(Console.ReadLine(), out stakeAmount);
            }

            if (_player.Balance < stakeAmount)
            {
                Console.WriteLine("You don't have enough balance.");
                RequestStake();
                return;
            }

            _player.Balance -= stakeAmount;

            Spin(stakeAmount);

            Console.WriteLine($"Current balance is: {_player.Balance}");
        }

        private void Spin(decimal stakeAmount)
        {
            double coefficient = 0;
            SymbolCoefficientProvider symbolCoefficientProvider = _symbolCoefficientProviderFactory.Create();
            for (int i = 0; i < Rows; i++)
            {
                List<Symbol> symbols = _randomSymbolGenerator.Generate(NumberOfSymbolsOnARow);
                Console.WriteLine(string.Join(", ", symbols));

                coefficient += symbolCoefficientProvider.GetCoefficient(symbols);
            }

            decimal winAmount = (decimal)coefficient * stakeAmount;
            _player.Balance += winAmount;

            Console.WriteLine($"You have won: {winAmount}");
        }
    }
}
