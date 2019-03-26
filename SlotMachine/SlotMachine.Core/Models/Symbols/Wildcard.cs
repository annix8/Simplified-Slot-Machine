using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlotMachine.Core.Models.Symbols
{
    public class Wildcard : Symbol
    {
        public override char Sign => throw new NotImplementedException();

        public override double Coefficient => throw new NotImplementedException();

        public override int Probability => throw new NotImplementedException();
    }
}
