using BlackJack.BLL.GameOptions;
using BlackJack.BLL.ViewModels;
using System.Collections.Generic;

namespace BlackJack.BLL.Interfaces
{
    public interface IGameSession
    {
        void RegisterPlayers(UserGameOptions userGameOptions);
        List<PlayerViewModel> ConfigureGameOnStart();
        List<PlayerViewModel> GiveCards();
        bool CheckIfGameEnded();
        List<PlayerViewModel> DefineWinners();
        List<GameHistoryViewModel> GetGameHistory();
    }
}
