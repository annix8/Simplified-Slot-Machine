using SlotMachine.Core.Models.Symbols;
using System.Collections.Generic;

namespace SlotMachine.Core.Services.Coefficient.Contracts
{
    public interface ISymbolCoefficientProvider
    {
        void SetSuccessor(ISymbolCoefficientProvider symbolCoefficientProvider);
        double GetCoefficient(List<Symbol> symbols);
    }
}
