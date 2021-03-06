﻿using SlotMachine.Core.Contracts;
using SlotMachine.Core.Factory.Contracts;
using SlotMachine.Core.Models;
using SlotMachine.Core.Models.Dto;

namespace SlotMachine.Core
{
    internal class GameController : IGameController
    {
        private const string InsufficientBalanceMessage = "Deposit more money to play. Current balance is {0}";

        private readonly ISimpleSlotMachineFactory _simpleSlotMachineFactory;
        private ISimpleSlotMachine _slotMachine;
        private Player _player;

        public GameController(ISimpleSlotMachineFactory simpleSlotMachineFactory)
        {
            _simpleSlotMachineFactory = simpleSlotMachineFactory;
        }

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
            _slotMachine = _simpleSlotMachineFactory.Create(_player);

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
    }
}
