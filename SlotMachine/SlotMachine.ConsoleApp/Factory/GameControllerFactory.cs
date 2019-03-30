using SlotMachine.ConsoleApp.Factory.Contracts;
using SlotMachine.Core;
using SlotMachine.Core.Contracts;

namespace SlotMachine.ConsoleApp.Factory
{
    public class GameControllerFactory : IGameControllerFactory
    {
        public IGameController Create()
        {
            return new GameController();
        }
    }
}
