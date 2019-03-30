using SlotMachine.Core.Models;
using SlotMachine.Core.Models.Dto;
using SlotMachine.Core.Models.Symbols;
using SlotMachine.Core.Services.Coefficient.Contracts;
using SlotMachine.Core.Services.Coefficient.Factory.Contracts;
using SlotMachine.Core.Services.Contracts;
using System.Collections.Generic;

namespace SlotMachine.Core
{
    internal class SimpleSlotMachine
    {
        private const int Rows = 4;
        private const int NumberOfSymbolsOnARow = 3;

        private readonly Player _player;
        private readonly IRandomSymbolGenerator _randomSymbolGenerator;
        private readonly ISymbolCoefficientProviderFactory _symbolCoefficientProviderFactory;

        public SimpleSlotMachine(Player player,
            IRandomSymbolGenerator randomSymbolGenerator,
            ISymbolCoefficientProviderFactory symbolCoefficientProviderFactory)
        {
            _player = player;
            _randomSymbolGenerator = randomSymbolGenerator;
            _symbolCoefficientProviderFactory = symbolCoefficientProviderFactory;
        }

        public SlotMachineSpinResultDto Spin(decimal stakeAmount)
        {
            var rowsOfSymbols = new List<List<Symbol>>();
            double coefficient = 0;
            ISymbolCoefficientProvider symbolCoefficientProvider = _symbolCoefficientProviderFactory.Create();
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
                WinAmount = winAmount,
                IsSuccess = true
            };
        }
    }
}
