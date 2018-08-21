using BlackJack.BLL.Game;
using BlackJack.BLL.GameOptions;
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

        [HttpGet]
        public ActionResult GameStartMenu()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(UserGameOptions gameOptions)
        {
            gameSession.RegisterPlayers(gameOptions);
            var playersViewModel = gameSession.ConfigureGameOnStart();
            return View(playersViewModel);
        }

        [HttpPost]
        public ActionResult DrawCard()
        {
            if (gameSession.CheckIfGameEnded())
            {
                return JavaScript("window.location = '" + Url.Action("Hit", "Home") + "'");
            }

            var playersViewModelList = gameSession.GiveCards();
            return PartialView("_PlayersTable", playersViewModelList);

        }

        public ActionResult Hit()
        {
            var winnerList = gameSession.DefineWinners();
            return View("Winner", winnerList);
        }

        public ActionResult CheckGameHistory()
        {
            var gameHistory = gameSession.GetGameHistory();
            return View(gameHistory);
        }
    }
}
