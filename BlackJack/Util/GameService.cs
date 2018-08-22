using BlackJack.BLL.Game;
using BlackJack.BLL.Interfaces;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlackJack.Util
{
    public class GameService : NinjectModule
    {
        public override void Load()
        {
            Bind<IGameSession>().To<GameSession>();
            Bind<IGameLogic>().To<GameLogic>();
        }
    }
}