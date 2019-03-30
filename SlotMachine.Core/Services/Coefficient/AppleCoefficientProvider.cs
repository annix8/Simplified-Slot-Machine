using SlotMachine.Core.Models.Symbols;
using System;

namespace SlotMachine.Core.Services.Coefficient
{
    internal class AppleCoefficientProvider : SymbolCoefficientProvider
    {
        protected override Type GetSymbolType()
        {
            return typeof(Apple);
        }
    }
}
