using SlotMachine.Core.Models.Dto;

namespace SlotMachine.Core.Contracts
{
    internal interface ISimpleSlotMachine
    {
        SlotMachineSpinResultDto Spin(decimal stakeAmount);
    }
}
