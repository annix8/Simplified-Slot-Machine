namespace SlotMachine.ConsoleApp.IO.Contracts
{
    public interface IPlayerInputRequester
    {
        decimal RequestPlayerDeposit();
        decimal RequestStake();
        bool AskForNewGame();
    }
}
