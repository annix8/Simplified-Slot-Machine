﻿using SlotMachine.Core.Models;
using SlotMachine.Core.Models.Dto;
using SlotMachine.Core.Services;
using SlotMachine.Core.Services.Coefficient.Factory;
using System;

namespace SlotMachine.Core
{
    public class GameController
    {
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
            if (_player.Balance < stakeAmount)
            {
                return new SlotMachineSpinResultDto()
                {
                    IsSuccess = false,
                    ResultMessage = "Insufficient balance"
                };
            }

            SlotMachineSpinResultDto spinResult = _slotMachine.Spin(stakeAmount);

            return spinResult;
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
