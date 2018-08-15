using BlackJack.DAL.Entities;
using BlackJack.DAL.Interfaces;
using System;

namespace BlackJack.DAL.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private BlackJackContext _db;
        private CardRepository _cardRepository;
        private PlayerRepository _playerRepository;

        public EFUnitOfWork(string connectionString)
        {
            _db = new BlackJackContext(connectionString);
        }

        public IPlayerRepository<Player> Players
        {
            get
            {
                if(_playerRepository == null)
                {
                    _playerRepository = new PlayerRepository(_db);
                }
                return _playerRepository;
            }
        }

        public IRepository<Card> Cards
        {
            get
            {
                if(_cardRepository == null)
                {
                    _cardRepository = new CardRepository(_db);
                }
                return _cardRepository;
            }
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
