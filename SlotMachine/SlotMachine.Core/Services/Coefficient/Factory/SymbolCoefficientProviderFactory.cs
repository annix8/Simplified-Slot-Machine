using SlotMachine.Core.Services.Coefficient.Contracts;
using SlotMachine.Core.Services.Coefficient.Factory.Contracts;

namespace SlotMachine.Core.Services.Coefficient.Factory
{
    internal class SymbolCoefficientProviderFactory : ISymbolCoefficientProviderFactory
    {
        public ISymbolCoefficientProvider Create()
        {
            var pineappleCoefficientProvider = new PineapleCoefficientProvider();
            var bananaCoefficientProvider = new BananaCoefficientProvider();
            var appleCoefficientProvider = new AppleCoefficientProvider();

            pineappleCoefficientProvider.SetSuccessor(bananaCoefficientProvider);
            bananaCoefficientProvider.SetSuccessor(appleCoefficientProvider);

            return pineappleCoefficientProvider;
        }
    }
}
