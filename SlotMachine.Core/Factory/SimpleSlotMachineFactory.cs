using SlotMachine.Core.Contracts;
using SlotMachine.Core.Factory.Contracts;
using SlotMachine.Core.Models;
using SlotMachine.Core.Services;
using SlotMachine.Core.Services.Coefficient.Factory;
using System;

namespace SlotMachine.Core.Factory
{
    internal class SimpleSlotMachineFactory : ISimpleSlotMachineFactory
    {
        public ISimpleSlotMachine Create(Player player)
        {
            return new SimpleSlotMachine(
               player,
               new RandomSymbolGenerator(new Random()),
               new SymbolCoefficientProviderFactory());
        }
    }
}
