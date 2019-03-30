namespace SlotMachine.Core.Services.Coefficient.Factory
{
    public class SymbolCoefficientProviderFactory
    {
        public SymbolCoefficientProvider Create()
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
