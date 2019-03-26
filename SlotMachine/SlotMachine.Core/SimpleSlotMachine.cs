using SlotMachine.Core.Models;
using SlotMachine.Core.Models.Symbols;
using System.Collections.Generic;

namespace SlotMachine.Core
{
    public class SimpleSlotMachine
    {
        private const int Rows = 4;
        private const int NumberOfSymbolsOnARow = 3;
        private readonly Player _player;
        private readonly RandomSymbolGenerator _randomSymbolGenerator;

        public SimpleSlotMachine(Player player,
            RandomSymbolGenerator randomSymbolGenerator)
        {
            _player = player;
            _randomSymbolGenerator = randomSymbolGenerator;
        }

        public void Spin()
        {
            for (int i = 0; i < Rows; i++)
            {
                List<Symbol> symbols = _randomSymbolGenerator.Generate(NumberOfSymbolsOnARow);
                System.Console.WriteLine(string.Join(", ", symbols));
            }
            // generate random symbols
            // perform checks and get coefficient
            // multiply by stake
        }

        private decimal AskForStake()
        {
            return 0;
        }
    }
}
