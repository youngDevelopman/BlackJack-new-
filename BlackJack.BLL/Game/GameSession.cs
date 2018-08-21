using BlackJack.BLL.GameOptions;
using BlackJack.BLL.Mapper;
using BlackJack.BLL.ViewModels;
using BlackJack.DAL.Entities;
using BlackJack.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlackJack.BLL.Game
{
    public class GameSession
    {
        IUnitOfWork _database { get; set; }
        GameLogic _gameLogic;
        static int roundId;


        public GameSession(IUnitOfWork uow, GameLogic gameLogic)
        {
            _database = uow;
            _gameLogic = gameLogic;
        }

        public void RegisterPlayers(UserGameOptions userGameOptions)
        {
            _database.Players.RemoveAllPlayers();
            List<string> botNames = new List<string>() { "Bill", "John", "Trevor", "Mike", "Frank" };

            Player user = new Player()
            {
                Name = userGameOptions.PlayerName,
                Status = "Player"
            };

            Player dealer = new Player()
            {
                Name = "Jack",
                Status = "Dealer"
            };

            _database.Players.Create(user);
            _database.Players.Create(dealer);

            for (int i = 0; i < userGameOptions.NumberOfPlayers; i++)
            {
                Player bot = new Player()
                {
                    Name = botNames[i],
                    Status = "Bot"
                };

                _database.Players.Create(bot);
            }

            
        }
        public List<PlayerViewModel> ConfigureGameOnStart()
        {
            roundId++;

            _database.Players.ClearPlayerCards();
            _gameLogic.GiveCardsOnStart();

            var playerViewModels = GetPlayerViewModels();

            return playerViewModels;
        }

        public List<PlayerViewModel> GiveCards()
        {

            _gameLogic.GiveCardsToAllPlayers();
            var playerViewModels = GetPlayerViewModels();

            return playerViewModels;
        }

        public bool CheckIfGameEnded()
        {
            // Conditions for ending the game:

            // 1 If actual player's score more or equals 21

            // 2 If all players have more than 21

            // 3 If actual player click the 'stand' button

            bool isGameEnded = false;
            var playersList = _database.Players.GetAll().ToArray();
            var botsList = playersList.Where(p => !(p.Status == "Player"));
            var actualPlayer = playersList.Where(p => p.Status == "Player").SingleOrDefault();

            List<int> botsCount = new List<int>();

            // Checking whether all bots have count more than 21
            foreach (var b in botsList)
            {
                botsCount.Add(_database.Players.GetAllCardsFromPlayer(b.Id).Sum(c => c.Value));
            }

            isGameEnded = botsCount.TrueForAll(c => c > 21);

            if (isGameEnded)
            {
                return isGameEnded;
            }
            else
            {
                var actualPlayerCount = _database.Players.GetAllCardsFromPlayer(actualPlayer.Id).Sum(c => c.Value);
                isGameEnded = (actualPlayerCount >= 21) ? true : false;
            }

            return isGameEnded;
        }

        public List<PlayerViewModel> DefineWinners()
        {
            var players = _database.Players.GetAll().ToList();
            List<PlayerViewModel> playerViewModels = new List<PlayerViewModel>();
           
            foreach (var p in players)
            {
                var currentPlayerCards = _database.Players.GetAllCardsFromPlayer(p.Id) as List<Card>;
                int currentPlayerCount = currentPlayerCards.Sum(c => c.Value);

                playerViewModels.Add(new PlayerViewModel()
                {
                    Id = p.Id,
                    Name = p.Name,
                    Status = p.Status,
                    Count = currentPlayerCount,
                    Cards = currentPlayerCards
                });
            }

            int maxCount = playerViewModels.Where(p => p.Count <= 21).ToList().Max(p => p.Count);
            var winnerList = playerViewModels.Where(p => p.Count == maxCount).ToList();

            _gameLogic.SaveGameHistory(winnerList, roundId);
                       
            return winnerList;
        }

        

        private List<PlayerViewModel> GetPlayerViewModels()
        {
            var playersList = _database.Players.GetAll().ToList();

            List<PlayerViewModel> playerViewModels = new List<PlayerViewModel>();

            for (int i = 0; i < playersList.Count; i++)
            {
                var currentPlayer = playersList.ElementAt(i);
                var currentPlayerCards = _database.Players.GetAllCardsFromPlayer(currentPlayer.Id);

                var playerVM = Map.MapCardsAndList(currentPlayer, currentPlayerCards as List<Card>);
                playerViewModels.Add(playerVM);
            }

            return playerViewModels;
        }

        public List<GameHistoryViewModel> GetGameHistory()
        {
            var gameHistoryList = _database.GameHistories.GetAll();
            var gameHistoryViewModel = Map.MapGameHistoryList(gameHistoryList as List<GameHistory>);

            return gameHistoryViewModel;
        }
    }
}
