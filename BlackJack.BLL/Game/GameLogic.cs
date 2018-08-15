using BlackJack.DAL.Interfaces;
using BlackJack.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.BLL.Game
{
    public static class GameLogic
    {
        internal static void GiveCardsOnStart(IUnitOfWork database)
        {
            var playersList = database.Players.GetAll();
            var cardsList = database.Cards.GetAll();
        }
    }
}
