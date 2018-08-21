using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using BlackJack.DAL.Entities;
using BlackJack.DAL.Interfaces;

namespace BlackJack.DAL.Repositories
{
    public class GameHistoryRepository : IRepository<GameHistory>
    {
        private BlackJackContext _db;

        public GameHistoryRepository(BlackJackContext context)
        {
            _db = context;
        }

        public void Create(GameHistory roundHistory)
        {
            _db.GameHistories.Add(roundHistory);
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            var round = _db.GameHistories.Find(id);

            if(round == null)
            {
                throw new NullReferenceException();
            }
        }

        public IEnumerable<GameHistory> Find(Func<GameHistory, bool> predicate)
        {
            var roundList = _db.GameHistories.Where(predicate);
            return roundList;
        }

        public GameHistory Get(int id)
        {
           var gameHistory = _db.GameHistories.Find(id);
           return gameHistory;
        }

        public IEnumerable<GameHistory> GetAll()
        {
            var gameHistoryList = _db.GameHistories.ToList();
            return gameHistoryList;
        }

        public void Update(GameHistory gameHistory)
        {
            _db.Entry(gameHistory).State = EntityState.Modified;
            _db.SaveChanges();
        }
    }
}
