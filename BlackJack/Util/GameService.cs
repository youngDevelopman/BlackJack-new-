﻿using BlackJack.BLL.Game;
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
            Bind<GameSession>().ToSelf();
        }
    }
}