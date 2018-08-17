using BlackJack.DAL.Entities;
using BlackJack.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlackJack.BLL.Game
{
    public class GameLogic
    {
        static Random random;

        private IUnitOfWork _database { get; set; }

        public GameLogic(IUnitOfWork database)
        {
            _database = database;
        }


        static GameLogic()
        {
            random = new Random();
        }

        public  void GiveCardsOnStart()
        {
            var playersArray = _database.Players.GetAll().ToList();
            var cardsList = _database.Cards.GetAll().ToList();

            GiveCardsToAllPlayers();
            GiveCardsToAllPlayers();

        }

        private  bool CheckUniqueCardId(int id)
        {
            var cardIds = _database.Players.GetCardsIdInDeck().ToList();
            bool isUnique = !cardIds.Contains(id);

            return isUnique;
        }
        
        public  void GiveCardsToAllPlayers()
        {
            var playersArray = _database.Players.GetAll().ToList();
            var cardsList = _database.Cards.GetAll().ToList();

            for (int i = 0; i < playersArray.Count; i++)
            {
                var currentPlayer = playersArray[i];
                var currentPlayerCount = _database.Players.GetAllCardsFromPlayer(currentPlayer.Id).Sum(c => c.Value);

                if ((currentPlayer.Status == "Bot" || currentPlayer.Status == "Dealer")
                    && currentPlayerCount <= 17)
                {
                    GiveCards(currentPlayer, cardsList);
                }

                else if(currentPlayer.Status == "Player" && currentPlayerCount < 21)
                {
                    GiveCards(currentPlayer, cardsList);
                }

            }
        }

        private void GiveCards(Player player, List<Card> cardsList)
        {

            bool isNotOver = true;

            do
            {

                int randomCardId = random.Next(1, cardsList.Count);

                if (CheckUniqueCardId(randomCardId))
                {
                    _database.Players.AddCard(player, cardsList[randomCardId - 1]);
                    isNotOver = false;
                }

            } while (isNotOver);
        }

        
    }
}
