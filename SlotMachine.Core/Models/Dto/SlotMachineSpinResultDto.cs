using SlotMachine.Core.Models.Symbols;
using System.Collections.Generic;

namespace SlotMachine.Core.Models.Dto
{
    public class SlotMachineSpinResultDto
    {
        public List<List<Symbol>> Symbols { get; set; }
        public decimal PlayerBalance { get; set; }
        public decimal WinAmount { get; set; }
        public bool IsSuccess { get; set; }
        public string ResultMessage { get; set; }
    }
}
