﻿using BlackJack.BLL.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlackJack.Controllers
{
    public class HomeController : Controller
    {

        private GameSession gameSession;

        public HomeController(GameSession session)
        {
            gameSession = session;
        }

        public ActionResult Index()
        {
            gameSession.ConfigureGameOnStart();
            return View();
        }
    }
}
