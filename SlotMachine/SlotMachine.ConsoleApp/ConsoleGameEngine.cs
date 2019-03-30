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
        private IGameController _gameController;
        private bool _runNewGame = true;

        public ConsoleGameEngine(IReader reader,
            IWriter writer,
            IPlayerInputRequester playerInputRequester,
            IGameController gameController)
        {
            _reader = reader;
            _writer = writer;
            _playerInputRequester = playerInputRequester;
            _gameController = gameController;
        }

        public void RunGameLoop()
        {
            CreateNewGame();
            PlayGame();
        }

        private void CreateNewGame()
        {
            decimal deposit = _playerInputRequester.RequestPlayerDeposit();
            _gameController.CreateNewGame(deposit);
        }

        private void PlayGame()
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
                        decimal deposit = _playerInputRequester.RequestPlayerDeposit();
                        _gameController.CreateNewGame(deposit);
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
    }
}
