using System;

namespace SlotMachine.Core.Models
{
    public class Player
    {
        private decimal _balance;
        public decimal Balance
        {
            get => _balance;
            set => _balance = Math.Round(value, 2);
        }
    }
}
