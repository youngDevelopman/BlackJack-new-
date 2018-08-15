using BlackJack.DAL;
using BlackJack.DAL.Interfaces;
using BlackJack.DAL.Repositories;
using Ninject.Modules;

namespace BlackJack.BLL.Infrastructure
{
    public class ServiceModule : NinjectModule
    {
        private string _connectionString;
        public ServiceModule(string connectionString)
        {
            _connectionString = connectionString;
        }
        public override void Load()
        {
            Bind<IUnitOfWork>().To<EFUnitOfWork>().WithConstructorArgument(_connectionString);
        }
    }
}
