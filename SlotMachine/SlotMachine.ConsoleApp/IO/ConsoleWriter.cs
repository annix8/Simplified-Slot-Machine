using SlotMachine.ConsoleApp.IO.Contracts;
using System;

namespace SlotMachine.ConsoleApp.IO
{
    public class ConsoleWriter : IWriter
    {
        public void WriteLine(string line)
        {
            Console.WriteLine(line);
        }
    }
}
