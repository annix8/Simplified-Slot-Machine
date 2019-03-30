using SlotMachine.Core.Models.Symbols;
using SlotMachine.Core.Services.Coefficient.Contracts;
using System;
using System.Collections.Generic;

namespace SlotMachine.Core.Services.Coefficient
{
    internal abstract class SymbolCoefficientProvider : ISymbolCoefficientProvider
    {
        protected ISymbolCoefficientProvider _successor;

        public void SetSuccessor(ISymbolCoefficientProvider symbolCoefficientProvider)
        {
            _successor = symbolCoefficientProvider;
        }

        public double GetCoefficient(List<Symbol> symbols)
        {
            double coefficient = 0;
            int countOfSameItems = 0;

            foreach (var symbol in symbols)
            {
                if (symbol.GetType() == GetSymbolType() || symbol is Wildcard)
                {
                    countOfSameItems++;
                    coefficient += symbol.Coefficient;
                }
            }

            if (countOfSameItems == symbols.Count)
            {
                return coefficient;
            }

            if (_successor != null)
            {
                return _successor.GetCoefficient(symbols);
            }

            return 0;
        }

        protected abstract Type GetSymbolType();
    }
}
