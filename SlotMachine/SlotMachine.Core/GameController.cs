using SlotMachine.Core.Contracts;
using SlotMachine.Core.Models;
using SlotMachine.Core.Models.Dto;
using SlotMachine.Core.Services;
using SlotMachine.Core.Services.Coefficient.Factory;
using System;

namespace SlotMachine.Core
{
    public class GameController : IGameController
    {
        private const string InsufficientBalanceMessage = "Deposit more money to play. Current balance is {0}.";

        private SimpleSlotMachine _slotMachine;
        private Player _player;

        public bool CreateNewGame(decimal playerDeposit)
        {
            if (playerDeposit <= 0)
            {
                return false;
            }

            _player = new Player()
            {
                Balance = playerDeposit
            };
            _slotMachine = CreateSlotMachine(_player);

            return true;
        }

        public SlotMachineSpinResultDto SpinMachine(decimal stakeAmount)
        {
            if (_player == null || _player.Balance <= 0 || _player.Balance < stakeAmount)
            {
                return new SlotMachineSpinResultDto()
                {
                    IsSuccess = false,
                    ResultMessage = string.Format(InsufficientBalanceMessage, _player?.Balance)
                };
            }

            _player.Balance -= stakeAmount;
            SlotMachineSpinResultDto spinResult = _slotMachine.Spin(stakeAmount);

            return spinResult;
        }

        public bool PlayerCanPlay()
        {
            if(_player == null)
            {
                return false;
            }

            return _player.Balance > 0;
        }

        private SimpleSlotMachine CreateSlotMachine(Player player)
        {
            return new SimpleSlotMachine(
                player,
                new RandomSymbolGenerator(new Random()),
                new SymbolCoefficientProviderFactory());
        }
    }
}
