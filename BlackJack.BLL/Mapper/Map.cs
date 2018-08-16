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
            CardViewModel cardViewModel = new CardViewModel()
            {
                Id = card.Id,
                Suit = card.Suit,
                Value = card.Value
            };

            return cardViewModel;

        }

        public static List<CardViewModel> MapCardsList(List<Card> cardsList)
        {
            List<CardViewModel> cardsViewModelList = new List<CardViewModel>();

            for (int i = 0; i < cardsList.Count; i++)
            {
                cardsViewModelList.Add(MapCards(cardsList[i]));
            }

            return cardsViewModelList;
        }

        public static PlayerViewModel MapPlayer(Player player)
        {
            PlayerViewModel playerViewModel = new PlayerViewModel()
            {
                Id = player.Id,
                Name = player.Name,
                Status = player.Status
            };

            return playerViewModel;
        }

        public static List<PlayerViewModel> MapPlayersList(List<Player> playersList)
        {
            List<PlayerViewModel> playersViewModelList = new List<PlayerViewModel>();

            for (int i = 0; i < playersList.Count; i++)
            {
                playersViewModelList.Add(MapPlayer(playersList[i]));
            }

            return playersViewModelList;
        }

        public static PlayerViewModel MapCardsAndList(Player player, List<Card> cards)
        {
            PlayerViewModel playerViewModel = new PlayerViewModel()
            {
                Id = player.Id,
                Name = player.Name,
                Status = player.Status,
                Count = cards.Sum(c => c.Value)
            };

            return playerViewModel;
        }
    }
}
