using BlackJack.BLL.ViewModels;
using BlackJack.DAL.Entities;
using System.Collections.Generic;

namespace BlackJack.BLL.Interfaces
{
    public interface IGameLogic
    {
        void GiveCardsOnStart();
        void SaveGameHistory(List<PlayerViewModel> winnerList, int roundId);
        void GiveCardsToAllPlayers();
    }
}
