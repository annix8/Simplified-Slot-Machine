namespace SlotMachine.Core.Models.Symbols
{
    public class Wildcard : Symbol
    {
        public override char Sign => '*';
        public override double Coefficient => 0;
        public override int Probability => 5;
    }
}
