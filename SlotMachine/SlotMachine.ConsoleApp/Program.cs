using SlotMachine.ConsoleApp.IO;
using SlotMachine.ConsoleApp.IO.Contracts;
using SlotMachine.Core;
using SlotMachine.Core.Contracts;

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
            IGameEngine gameEngine = new GameEngine();
            IGameController gameController = gameEngine.CreateGameController();

            return new ConsoleGameEngine(reader, writer, playerInputRequester, gameController);
        }
    }
}
