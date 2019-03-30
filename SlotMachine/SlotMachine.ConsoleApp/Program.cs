using SlotMachine.ConsoleApp.IO;

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
            var reader = new ConsoleReader();
            var writer = new ConsoleWriter();
            var playerInputRequester = new PlayerInputRequester(reader, writer);
            var consoleGameEngine = new ConsoleGameEngine(reader, writer, playerInputRequester);

            return consoleGameEngine;
        }
    }
}
