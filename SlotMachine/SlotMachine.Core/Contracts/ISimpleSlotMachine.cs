using SlotMachine.Core.Models.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace SlotMachine.Core.Contracts
{
    public interface ISimpleSlotMachine
    {
        SlotMachineSpinResultDto Spin(decimal stakeAmount);
    }
}
