using SlotMachine.Core.Models.Symbols;
using System;
using System.Collections.Generic;

namespace SlotMachine.Core.Services.Coefficient
{
    public class NullCoefficientProvider : SymbolCoefficientProvider
    {
        public override double GetCoefficient(List<Symbol> symbols)
        {
            // if code reaches this provider, no winning row was found
            return 0;
        }

        protected override Type GetSymbolType()
        {
            throw new NotImplementedException();
        }
    }
}
