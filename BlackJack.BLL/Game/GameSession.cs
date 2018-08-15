using BlackJack.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.BLL.Game
{
    public class GameSession
    {
        IUnitOfWork _database { get; set; }
        
        public GameSession(IUnitOfWork uow)
        {
            _database = uow;
        }

        public void ConfigureGameOnStart()
        {
            GameLogic.GiveCardsOnStart(_database);
        }

        
    }
}
