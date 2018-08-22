using BlackJack.BLL.ViewModels;
using BlackJack.DAL.Entities;
using BlackJack.DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace BlackJack.BLL.Mapper
{
    public static class Map
    {
        public static CardViewModel MapCards(Card card)
        {
            var cardViewModel = new CardViewModel()
            {
                Id = card.Id,
                Suit = card.Suit,
                Value = card.Value,
                Rank = card.Rank,
                ImageSource = card.ImageSource
            };

            return cardViewModel;

        }

        public static List<CardViewModel> MapCardsList(List<Card> cardsList)
        {
            var cardsViewModelList = new List<CardViewModel>();

            for (int i = 0; i < cardsList.Count; i++)
            {
                cardsViewModelList.Add(MapCards(cardsList[i]));
            }

            return cardsViewModelList;
        }

        public static PlayerViewModel MapPlayer(Player player)
        {
            var playerViewModel = new PlayerViewModel()
            {
                Id = player.Id,
                Name = player.Name,
                Status = player.Status
            };

            return playerViewModel;
        }

        public static List<PlayerViewModel> MapPlayersList(List<Player> playersList)
        {
            var playersViewModelList = new List<PlayerViewModel>();

            for (int i = 0; i < playersList.Count; i++)
            {
                playersViewModelList.Add(MapPlayer(playersList[i]));
            }

            return playersViewModelList;
        }

        public static PlayerViewModel MapCardsAndList(Player player, List<Card> cards)
        {
            var playerViewModel = new PlayerViewModel()
            {
                Id = player.Id,
                Name = player.Name,
                Status = player.Status,
                Count = cards.Sum(c => c.Value),
                Cards = cards
            };

            return playerViewModel;
        }

        public static List<GameHistoryViewModel> MapGameHistoryList(List<GameHistory> gameHistoryList)
        {
            var gameHistoryViewModels = new List<GameHistoryViewModel>();

            foreach(var h in gameHistoryList)
            {
                var viewModel = new GameHistoryViewModel()
                {
                    Date = h.Date,
                    RoundId = h.RoundId,
                    WinnerId = h.WinnerId,
                    WinnerName = h.WinnerName,
                    WinnerScore = h.WinnerScore,
                    Cards = Map.MapCardsList(h.Cards as List<Card>)
                };
                gameHistoryViewModels.Add(viewModel);
            }

            return gameHistoryViewModels;
        }
    }
}
