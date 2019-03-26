using SlotMachine.Core.Models.Symbols;
using System.Collections.Generic;

namespace SlotMachine.Core
{
    public class RandomSymbolGenerator
    {
        private readonly List<Symbol> _symbols;

        public RandomSymbolGenerator()
        {
            _symbols = new List<Symbol>
            {
                new Apple()
            };
        }
    }
}
