using SlotMachine.Core.Models;
using SlotMachine.Core.Models.Dto;
using SlotMachine.Core.Models.Symbols;
using SlotMachine.Core.Services;
using SlotMachine.Core.Services.Coefficient;
using SlotMachine.Core.Services.Coefficient.Factory;
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

        public SlotMachineSpinResultDto Spin(decimal stakeAmount)
        {
            var rowsOfSymbols = new List<List<Symbol>>();
            double coefficient = 0;
            SymbolCoefficientProvider symbolCoefficientProvider = _symbolCoefficientProviderFactory.Create();
            for (int i = 0; i < Rows; i++)
            {
                List<Symbol> symbols = _randomSymbolGenerator.Generate(NumberOfSymbolsOnARow);
                rowsOfSymbols.Add(symbols);
                coefficient += symbolCoefficientProvider.GetCoefficient(symbols);
            }

            decimal winAmount = (decimal)coefficient * stakeAmount;
            _player.Balance += winAmount;

            return new SlotMachineSpinResultDto
            {
                PlayerBalance = _player.Balance,
                Symbols = rowsOfSymbols,
                WinAmount = winAmount
            };
        }
    }
}
