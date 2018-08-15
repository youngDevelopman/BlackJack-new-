using BlackJack.DAL.Entities;
using BlackJack.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace BlackJack.DAL.Repositories
{
    public class CardRepository : IRepository<Card>
    {
        private BlackJackContext _db;

        public CardRepository(BlackJackContext context)
        {
            _db = context;
        }

        public void Create(Card card)
        {
            _db.Cards.Add(card);
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            var card = _db.Cards.Find(id);

            if(card != null)
            {
                _db.Cards.Remove(card);
                _db.SaveChanges();
            }
        }

        public IEnumerable<Card> Find(Func<Card, bool> predicate)
        {
            var cardsList = _db.Cards.Where(predicate);
            return cardsList;
        }

        public Card Get(int id)
        {
            var card = _db.Cards.Find(id);
            return card;
        }

        public IEnumerable<Card> GetAll()
        {
            var cardsList = _db.Cards.ToList();
            return cardsList;
        }

        public void Update(Card card)
        {
            _db.Entry(card).State = EntityState.Modified;
            _db.SaveChanges();
        }
    }
}
