using BlackJack.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IPlayerRepository<Player> Players { get; }
        IRepository<Card> Cards { get;  }
        IRepository<GameHistory> GameHistory { get; }
        void Save();
    }
}
