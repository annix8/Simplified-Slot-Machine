namespace SlotMachine.Core.Services.Coefficient.Factory
{
    public class SymbolCoefficientProviderFactory
    {
        public SymbolCoefficientProvider Create()
        {
            var pineappleCoefficientProvider = new PineapleCoefficientProvider();
            var bananaCoefficientProvider = new BananaCoefficientProvider();
            var appleCoefficientProvider = new AppleCoefficientProvider();
            var nullCoefficientProvider = new NullCoefficientProvider();

            pineappleCoefficientProvider.SetSuccessor(bananaCoefficientProvider);
            bananaCoefficientProvider.SetSuccessor(appleCoefficientProvider);
            appleCoefficientProvider.SetSuccessor(nullCoefficientProvider);

            return pineappleCoefficientProvider;
        }
    }
}
