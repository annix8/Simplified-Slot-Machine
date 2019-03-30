using SlotMachine.Core.Models.Symbols;
using System.Collections.Generic;

namespace SlotMachine.Core.Services.Contracts
{
    public interface IRandomSymbolGenerator
    {
        List<Symbol> Generate(int symbolsCount);
    }
}
