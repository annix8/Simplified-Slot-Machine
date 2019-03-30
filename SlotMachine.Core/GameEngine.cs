using SlotMachine.Core.Contracts;
using SlotMachine.Core.Factory;

namespace SlotMachine.Core
{
    public class GameEngine : IGameEngine
    {
        public IGameController CreateGameController()
        {
            return new GameController(new SimpleSlotMachineFactory());
        }
    }
}
