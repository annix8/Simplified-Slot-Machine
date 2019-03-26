using SlotMachine.Core;

namespace SlotMachine.Console
{
    public class Program
    {
        static void Main(string[] args)
        {
            new GameController().RunGameLoop();
        }
    }
}
