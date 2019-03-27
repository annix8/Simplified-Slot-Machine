using SlotMachine.Core;

namespace SlotMachine.Console
{
    public class Program
    {
        static void Main(string[] args)
        {
            var gameController = new GameController();
            gameController.CreateNewGame();
        }

        private static decimal RequestPlayerDeposit()
        {
            Console.WriteLine("Please deposit money you would like to play with:");
            bool isMoney = decimal.TryParse(Console.ReadLine(), out decimal money);

            while (!isMoney || money <= 0)
            {
                Console.WriteLine("Please enter a valid positive number");
                isMoney = decimal.TryParse(Console.ReadLine(), out money);
            }

            return money;
        }
    }
}
