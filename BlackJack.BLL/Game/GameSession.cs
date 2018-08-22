using BlackJack.BLL.GameOptions;
using BlackJack.BLL.Interfaces;
using BlackJack.BLL.Mapper;
using BlackJack.BLL.ViewModels;
using BlackJack.DAL.Entities;
using BlackJack.DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace BlackJack.BLL.Game
{
    public class GameSession : IGameSession
    {
        private  IUnitOfWork _database { get; set; }
        private  IGameLogic _gameLogic { get; set; }
        static int roundId;

        public GameSession(IUnitOfWork uow, IGameLogic gameLogic)
        {
            _database = uow;
            _gameLogic = gameLogic;
        }

        // Registers players depending on user input
        public void RegisterPlayers(UserGameOptions userGameOptions)
        {
            roundId = 0;

            _database.Players.RemoveAllPlayers();

            var botNames = new List<string>() { "Bill", "John", "Trevor", "Mike", "Frank" };

            var user = new Player()
            {
                Name = userGameOptions.PlayerName,
                Status = "Player"
            };

            var dealer = new Player()
            {
                Name = "Jack",
                Status = "Dealer"
            };

            _database.Players.Create(user);
            _database.Players.Create(dealer);

            for (int i = 0; i < userGameOptions.NumberOfPlayers; i++)
            {
                var bot = new Player()
                {
                    Name = botNames[i],
                    Status = "Bot"
                };

                _database.Players.Create(bot);
            }

            
        }

        //Configures everything for game to start
        public List<PlayerViewModel> ConfigureGameOnStart()
        {
            roundId++;

            _database.Players.ClearPlayerCards();
            _gameLogic.GiveCardsOnStart();

            List<PlayerViewModel> playerViewModels = GetPlayerViewModels();

            return playerViewModels;
        }

        // Give cards to all players
        public List<PlayerViewModel> GiveCards()
        {

            _gameLogic.GiveCardsToAllPlayers();
            List<PlayerViewModel> playerViewModels = GetPlayerViewModels();

            return playerViewModels;
        }

        // Checks whether game has already ended
        public bool CheckIfGameEnded()
        {
            // Conditions for ending the game:

            // 1 If actual player's score more or equals 21

            // 2 If all players have more than 21

            // 3 If actual player click the 'stand' button

            bool isGameEnded = false;

            List<Player> playersList = _database.Players.GetAll().ToList();
            IEnumerable<Player> botsList = playersList.Where(p => !(p.Status == "Player"));
            Player actualPlayer = playersList.Where(p => p.Status == "Player").SingleOrDefault();

            var botsCount = new List<int>();

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
                int actualPlayerCount = _database.Players.GetAllCardsFromPlayer(actualPlayer.Id).Sum(c => c.Value);
                isGameEnded = (actualPlayerCount >= 21) ? true : false;
            }

            return isGameEnded;
        }

        // Returns a winners' list of player view model 
        public List<PlayerViewModel> DefineWinners()
        {
            List<Player> players = _database.Players.GetAll().ToList();
            var playerViewModels = new List<PlayerViewModel>();
           
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
            List<PlayerViewModel> winnerList = playerViewModels.Where(p => p.Count == maxCount).ToList();

            _gameLogic.SaveGameHistory(winnerList, roundId);
                       
            return winnerList;
        }

        
        // Returns list of player view model using static Map class
        private List<PlayerViewModel> GetPlayerViewModels()
        {
            List<Player> playersList = _database.Players.GetAll().ToList();

            var playerViewModels = new List<PlayerViewModel>();

            for (int i = 0; i < playersList.Count; i++)
            {
                Player currentPlayer = playersList.ElementAt(i);
                IEnumerable<Card> currentPlayerCards = _database.Players.GetAllCardsFromPlayer(currentPlayer.Id);

                PlayerViewModel playerVM = Map.MapCardsAndList(currentPlayer, currentPlayerCards as List<Card>);
                playerViewModels.Add(playerVM);
            }

            return playerViewModels;
        }

        // Returns game history list
        public List<GameHistoryViewModel> GetGameHistory()
        {
            IEnumerable<GameHistory> gameHistoryList = _database.GameHistories.GetAll();
            List<GameHistoryViewModel> gameHistoryViewModel = Map.MapGameHistoryList(gameHistoryList as List<GameHistory>);

            return gameHistoryViewModel;
        }
    }
}
