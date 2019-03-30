using SlotMachine.Core.Models.Symbols;
using System;

namespace SlotMachine.Core.Services.Coefficient
{
    internal class PineapleCoefficientProvider : SymbolCoefficientProvider
    {
        protected override Type GetSymbolType()
        {
            return typeof(Pineaple);
        }
    }
}
