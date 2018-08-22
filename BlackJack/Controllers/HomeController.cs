using BlackJack.BLL.GameOptions;
using BlackJack.BLL.Interfaces;
using BlackJack.BLL.ViewModels;
using System.Collections.Generic;
using System.Web.Mvc;

namespace BlackJack.Controllers
{
    public class HomeController : Controller
    {
        private readonly IGameSession _gameSession;

        public HomeController(IGameSession session)
        {
            _gameSession = session;
        }

        [HttpGet]
        public ActionResult GameStartMenu()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(UserGameOptions gameOptions)
        {
            _gameSession.RegisterPlayers(gameOptions);

            return RedirectToAction("StartNewRound");
        }


        public ActionResult StartNewRound()
        {
            List<PlayerViewModel> playersViewModel = _gameSession.ConfigureGameOnStart();
            return View("Index", playersViewModel);
        }

        public ActionResult DrawCard()
        {
            if (_gameSession.CheckIfGameEnded())
            {
                return JavaScript("window.location = '" + Url.Action("Hit", "Home") + "'");
            }

            List<PlayerViewModel> playersViewModelList = _gameSession.GiveCards();
            return PartialView("_PlayersTable", playersViewModelList);

        }

        public ActionResult Hit()
        {
            List<PlayerViewModel> winnerList = _gameSession.DefineWinners();
            return View("Winner", winnerList);
        }

        public ActionResult CheckGameHistory()
        {
            List<GameHistoryViewModel> gameHistory = _gameSession.GetGameHistory();
            return View(gameHistory);
        }
    }
}
