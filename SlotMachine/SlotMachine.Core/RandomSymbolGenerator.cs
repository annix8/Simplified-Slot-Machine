using SlotMachine.Core.Models.Symbols;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SlotMachine.Core
{
    public class RandomSymbolGenerator
    {
        private readonly Random _random;
        private List<Symbol> _symbols;

        public RandomSymbolGenerator(Random random)
        {
            _random = random;

            InitializeSymbols();
        }

        public List<Symbol> Generate(int symbolsCount)
        {
            var result = new List<Symbol>();
            for (int i = 0; i < symbolsCount; i++)
            {
                result.Add(GetRandomSymbol());
            }

            return result;
        }

        private Symbol GetRandomSymbol()
        {
            double randomNumber = _random.NextDouble();

            double cumulative = 0.0;
            for (int i = 0; i < _symbols.Count; i++)
            {
                cumulative += _symbols[i].Probability;
                if (randomNumber <= cumulative)
                {
                    Symbol selectedSymbol = _symbols[i];
                    return selectedSymbol;
                }
            }

            // return symbol with highest probability if, by any chance, a random one is not created
            return _symbols.Last();
        }

        private void InitializeSymbols()
        {
            _symbols = new List<Symbol>
            {
                new Apple(),
                new Banana(),
                new Pear(),
                new Wildcard()
            };
            _symbols = _symbols
                .OrderBy(x => x.Probability)
                .ToList();
        }
    }
}
