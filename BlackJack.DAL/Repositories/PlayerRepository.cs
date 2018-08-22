using BlackJack.DAL.Entities;
using BlackJack.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace BlackJack.DAL.Repositories
{
    public class PlayerRepository : IPlayerRepository<Player>
    {
        private BlackJackContext _db;

        public PlayerRepository(BlackJackContext context)
        {
            _db = context; 
        }

        public void AddCard(Player player, Card card)
        {
            var tmpPlayer = Get(player.Id);
            var tmpCard = _db.Cards.Find(card.Id);

            _db.PlayersCards.Add(new PlayerCard()
            {
                PlayerId = tmpPlayer.Id,
                CardId = tmpCard.Id,
                ImageSource = tmpCard.ImageSource
            });

            _db.SaveChanges();
        }

        public void Create(Player player)
        {
            _db.Players.Add(player);
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            var player = _db.Players.Find(id);

            if(player != null)
            {
                _db.Players.Remove(player);
                _db.SaveChanges();
            }
        }

        public IEnumerable<Player> Find(Func<Player, bool> predicate)
        {
            var playersList = _db.Players.Where(predicate);
            return playersList;
        }

        public Player Get(int id)
        {
            var player = _db.Players.Find(id);

            return player;
        }
    

        public IEnumerable<Player> GetAll()
        {
            var playersList = _db.Players;
            return playersList;
        }

        public void Update(Player player)
        {
            _db.Entry(player).State = EntityState.Modified;
            _db.SaveChanges();

        }

        public IEnumerable<Card> GetAllCardsFromPlayer(int id)
        {
            var playerCardsList = _db.PlayersCards.Where(p => p.PlayerId == id).ToList();
            var cardList = new List<Card>();

            foreach (var item in playerCardsList.ToList())
            {
                Card card = _db.Cards.Find(item.CardId);
                cardList.Add(card);
            }

            return cardList;
        }

        public IEnumerable<int> GetCardsIdInDeck()
        {
            var cardList = _db.PlayersCards.Select(p => p.CardId).ToList();
            return cardList;
        }

        public void ClearPlayerCards()
        {
            _db.PlayersCards.RemoveRange(_db.PlayersCards);
            _db.SaveChanges();
        }

        public void RemoveAllPlayers()
        {
            _db.Players.RemoveRange(_db.Players.ToList());
            _db.SaveChanges();
        }

        
    }
}
