using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlotMachine.Console
{
    public class SlotMachine
    {
        private const int Rows = 4;
        private readonly Player _player;

        public SlotMachine(Player player)
        {
            _player = player;
        }

        public void Spin()
        {
            // generate random symbols
            // perform checks and get coefficient
            // multiply by stake
        }

        private decimal AskForStake()
        {
            return 0;
        }
    }
}
