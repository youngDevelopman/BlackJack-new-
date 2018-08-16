using BlackJack.DAL.Interfaces;
using System.Linq;

namespace BlackJack.BLL.Game
{
    public static class GameLogic
    {
        internal static void GiveCardsOnStart(IUnitOfWork database)
        {
            var playersArray = database.Players.GetAll().ToList();
            var cardsList = database.Cards.GetAll().ToList();

            int cardCount = 0;
            for (int i = 0; i < playersArray.Count; i++)
            {
                database.Players.AddCard(playersArray[i], cardsList[cardCount]);
                cardCount++;
                if(cardCount >= cardsList.Count)
                {
                    cardCount = 0;
                }
            }
        }
    }
}
