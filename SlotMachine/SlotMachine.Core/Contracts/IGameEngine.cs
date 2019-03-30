namespace SlotMachine.Core.Contracts
{
    public interface IGameEngine
    {
        IGameController CreateGameController();
    }
}
