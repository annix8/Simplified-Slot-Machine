using SlotMachine.Core.Contracts;
using SlotMachine.Core.Models;

namespace SlotMachine.Core.Factory.Contracts
{
    internal interface ISimpleSlotMachineFactory
    {
        ISimpleSlotMachine Create(Player player);
    }
}
