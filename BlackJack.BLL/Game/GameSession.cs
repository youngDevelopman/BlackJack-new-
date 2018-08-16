using BlackJack.BLL.ViewModels;
using BlackJack.DAL.Entities;
using BlackJack.DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace BlackJack.BLL.Game
{
    public class GameSession
    {
        IUnitOfWork _database { get; set; }
        GameLogic _gameLogic;

        public GameSession(IUnitOfWork uow, GameLogic gameLogic)
        {
            _database = uow;
            _gameLogic = gameLogic;
        }

        public List<PlayerViewModel> ConfigureGameOnStart()
        {
            _gameLogic.GiveCardsOnStart();
            var playersList = _database.Players.GetAll().ToList();

            List<PlayerViewModel> playerViewModels = new List<PlayerViewModel>();

            for (int i = 0; i < playersList.Count; i++)
            {
                var currentPlayer = playersList.ElementAt(i);
                var currentPlayerCards = _database.Players.GetAllCardsFromPlayer(currentPlayer.Id);

                var playerVM = Mapper.Map.MapCardsAndList(currentPlayer, currentPlayerCards as List<Card>);
                playerViewModels.Add(playerVM);
            }

            return playerViewModels;
        }

        
    }
}
