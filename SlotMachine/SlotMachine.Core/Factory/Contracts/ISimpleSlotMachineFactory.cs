using SlotMachine.Core.Contracts;
using SlotMachine.Core.Models;

namespace SlotMachine.Core.Factory.Contracts
{
    public interface ISimpleSlotMachineFactory
    {
        ISimpleSlotMachine Create(Player player);
    }
}
