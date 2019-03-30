using SlotMachine.Core.Models.Symbols;
using System;
using System.Collections.Generic;

namespace SlotMachine.Core.Services.Coefficient
{
    public abstract class SymbolCoefficientProvider
    {
        protected SymbolCoefficientProvider _successor;

        public void SetSuccessor(SymbolCoefficientProvider symbolCoefficientProvider)
        {
            _successor = symbolCoefficientProvider;
        }

        public virtual double GetCoefficient(List<Symbol> symbols)
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
