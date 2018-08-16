using BlackJack.DAL.Entities;
using BlackJack.DAL.Interfaces;
using System;
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

            GiveCards();
            GiveCards();
            
        }

        private  bool CheckUniqueCardId(int id)
        {
            var cardIds = _database.Players.GetCardsIdInDeck();
            bool isUnique = !cardIds.Contains(id);

            return isUnique;
        }
        
        public  void GiveCards()
        {
            var playersArray = _database.Players.GetAll().ToList();
            var cardsList = _database.Cards.GetAll().ToList();

            for (int i = 0; i < playersArray.Count; i++)
            {
                bool isNotOver = true;

                do
                {

                    int randomCardId = random.Next(1, cardsList.Count);

                    if (CheckUniqueCardId(randomCardId))
                    {
                        _database.Players.AddCard(playersArray[i], cardsList[randomCardId]);
                        isNotOver = false;
                    }

                } while (isNotOver);
                        
            }
        }
    }
}
