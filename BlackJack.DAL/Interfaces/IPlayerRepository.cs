using BlackJack.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.DAL.Interfaces
{
    public interface IPlayerRepository<T> : IRepository<T> where T : class
    {
        void AddCard(Player player, Card card);
        IEnumerable<Card> GetAllCardsFromPlayer(int id);
        IEnumerable<int> GetCardsIdInDeck();
    }
    
}
