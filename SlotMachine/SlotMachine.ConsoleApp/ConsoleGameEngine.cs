using SlotMachine.ConsoleApp.Factory.Contracts;
using SlotMachine.ConsoleApp.IO.Contracts;
using SlotMachine.Core.Contracts;
using SlotMachine.Core.Models.Dto;
using SlotMachine.Core.Models.Symbols;
using System.Collections.Generic;

namespace SlotMachine.ConsoleApp
{
    public class ConsoleGameEngine
    {
        private readonly IReader _reader;
        private readonly IWriter _writer;
        private readonly IPlayerInputRequester _playerInputRequester;
        private readonly IGameControllerFactory _gameControllerFactory;
        private IGameController _gameController;
        private bool _runNewGame = true;

        public ConsoleGameEngine(IReader reader,
            IWriter writer,
            IPlayerInputRequester playerInputRequester,
            IGameControllerFactory gameControllerFactory)
        {
            _reader = reader;
            _writer = writer;
            _playerInputRequester = playerInputRequester;
            _gameControllerFactory = gameControllerFactory;
            _gameController = CreateGameController();
        }

        public void RunGameLoop()
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

        private void DrawSymbols(List<List<Symbol>> rowsOfSymbols)
        {
            foreach (var rowOfSymbols in rowsOfSymbols)
            {
                _writer.WriteLine(string.Join(", ", rowOfSymbols));
            }
        }

        private IGameController CreateGameController()
        {
            var gameController = _gameControllerFactory.Create();
            decimal deposit = _playerInputRequester.RequestPlayerDeposit();
            gameController.CreateNewGame(deposit);

            return gameController;
        }
    }
}
