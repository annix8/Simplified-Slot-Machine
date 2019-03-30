using SlotMachine.ConsoleApp.IO.Contracts;

namespace SlotMachine.ConsoleApp.IO
{
    public class PlayerInputRequester : IPlayerInputRequester
    {
        private readonly IReader _reader;
        private readonly IWriter _writer;

        public PlayerInputRequester(
            IReader reader,
            IWriter writer)
        {
            _reader = reader;
            _writer = writer;
        }

        public decimal RequestPlayerDeposit()
        {
            _writer.WriteLine("Please deposit money you would like to play with:");
            bool isMoney = decimal.TryParse(_reader.ReadLine(), out decimal money);

            while (!isMoney || money <= 0)
            {
                _writer.WriteLine("Please enter a valid positive number");
                isMoney = decimal.TryParse(_reader.ReadLine(), out money);
            }

            return money;
        }

        public decimal RequestStake()
        {
            _writer.WriteLine("Enter stake amount:");
            bool isNumber = decimal.TryParse(_reader.ReadLine(), out decimal stakeAmount);
            while (!isNumber || stakeAmount <= 0)
            {
                _writer.WriteLine("Please enter a valid number for stake amount that is bigger than 0");
                isNumber = decimal.TryParse(_reader.ReadLine(), out stakeAmount);
            }

            return stakeAmount;
        }

        public bool AskForNewGame()
        {
            _writer.WriteLine("Your balance is 0. Would you like to insert more to play again? Y/N");
            string result = _reader.ReadLine().ToLower();

            while (result != "y" && result != "n")
            {
                _writer.WriteLine("Your balance is 0. Would you like to insert more to play again? Y/N");
                result = _reader.ReadLine().ToLower();
            }

            return result == "y";
        }
    }
}
