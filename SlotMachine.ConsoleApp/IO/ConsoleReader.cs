using SlotMachine.ConsoleApp.IO.Contracts;
using System;

namespace SlotMachine.ConsoleApp.IO
{
    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
