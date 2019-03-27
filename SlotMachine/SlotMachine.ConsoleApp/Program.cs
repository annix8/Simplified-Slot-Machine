using SlotMachine.ConsoleApp.IO;
using SlotMachine.ConsoleApp.IO.Contracts;
using SlotMachine.Core;
using SlotMachine.Core.Models.Dto;
using SlotMachine.Core.Models.Symbols;
using System.Collections.Generic;

namespace SlotMachine.ConsoleApp
{
    class Program
    {
        private static IReader _reader;
        private static IWriter _writer;
        private static GameController _gameController;
        private static PlayerInputRequester _playerInputRequester;

        private static bool _runNewGame = true;

        static void Main(string[] args)
        {
            Initialize();
            RunGameLoop();
        }

        private static void Initialize()
        {
            _reader = new ConsoleReader();
            _writer = new ConsoleWriter();
            _playerInputRequester = new PlayerInputRequester(_reader, _writer);
            _gameController = CreateGameController();
        }

        private static void RunGameLoop()
        {
            while (_runNewGame)
            {
                decimal stake = _playerInputRequester.RequestStake();
                SlotMachineSpinResultDto result = _gameController.SpinMachine(stake);

                if (!result.IsSuccess)
                {
                    _writer.WriteLine(result.ResultMessage);
                    continue;
                }

                DrawSymbols(result.Symbols);
                _writer.WriteLine($"You have won: {result.WinAmount:f2}");
                _writer.WriteLine($"Current balance is: {result.PlayerBalance:f2}");

                if (!_gameController.PlayerCanPlay())
                {
                    _runNewGame = _playerInputRequester.AskForNewGame();

                    if (_runNewGame)
                    {
                        _gameController = CreateGameController();
                    }
                }
            }
        }

        private static GameController CreateGameController()
        {
            var gameController = new GameController();
            decimal deposit = _playerInputRequester.RequestPlayerDeposit();
            gameController.CreateNewGame(deposit);

            return gameController;
        }

        private static void DrawSymbols(List<List<Symbol>> rowsOfSymbols)
        {
            foreach (var rowOfSymbols in rowsOfSymbols)
            {
                _writer.WriteLine(string.Join(", ", rowOfSymbols));
            }
        }
    }
}
