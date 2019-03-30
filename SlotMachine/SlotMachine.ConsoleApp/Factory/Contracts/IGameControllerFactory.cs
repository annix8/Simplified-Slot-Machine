using SlotMachine.Core.Contracts;

namespace SlotMachine.ConsoleApp.Factory.Contracts
{
    public interface IGameControllerFactory
    {
        IGameController Create();
    }
}
