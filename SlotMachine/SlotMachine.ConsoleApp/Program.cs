using SlotMachine.ConsoleApp.Factory;
using SlotMachine.ConsoleApp.Factory.Contracts;
using SlotMachine.ConsoleApp.IO;
using SlotMachine.ConsoleApp.IO.Contracts;

namespace SlotMachine.ConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            ConsoleGameEngine consoleGameEngine = CreateConsoleGameEngine();
            consoleGameEngine.RunGameLoop();
        }

        private static ConsoleGameEngine CreateConsoleGameEngine()
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();
            IPlayerInputRequester playerInputRequester = new PlayerInputRequester(reader, writer);
            IGameControllerFactory gameControllerFactory = new GameControllerFactory();

            return new ConsoleGameEngine(reader, writer, playerInputRequester, gameControllerFactory);
        }
    }
}
