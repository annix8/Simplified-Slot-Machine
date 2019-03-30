using SlotMachine.Core.Services.Coefficient.Contracts;

namespace SlotMachine.Core.Services.Coefficient.Factory.Contracts
{
    public interface ISymbolCoefficientProviderFactory
    {
        ISymbolCoefficientProvider Create();
    }
}
