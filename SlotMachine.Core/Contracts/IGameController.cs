using SlotMachine.Core.Models.Dto;

namespace SlotMachine.Core.Contracts
{
    public interface IGameController
    {
        bool CreateNewGame(decimal playerDeposit);
        SlotMachineSpinResultDto SpinMachine(decimal stakeAmount);
        bool PlayerCanPlay();
    }
}
