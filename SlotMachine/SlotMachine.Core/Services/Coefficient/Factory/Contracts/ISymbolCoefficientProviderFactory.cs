using SlotMachine.Core.Services.Coefficient.Contracts;

namespace SlotMachine.Core.Services.Coefficient.Factory.Contracts
{
    internal interface ISymbolCoefficientProviderFactory
    {
        ISymbolCoefficientProvider Create();
    }
}
