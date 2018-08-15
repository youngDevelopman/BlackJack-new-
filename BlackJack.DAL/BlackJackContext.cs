using BlackJack.DAL.Entities;
using System.Data.Entity;

namespace BlackJack.DAL
{
    public class BlackJackContext : DbContext
    {

        static BlackJackContext()
        {
            Database.SetInitializer<BlackJackContext>(new ContextInitializer());
        }

        public BlackJackContext(string connectionString)
              : base(connectionString)
        {
        }

        public DbSet<Card> Cards { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<PlayerCard> PlayersCards { get; set; }

       
        
    }

    public class ContextInitializer : DropCreateDatabaseAlways<BlackJackContext>
    {
        protected override void Seed(BlackJackContext context)
        {
            context.Cards.Add(new Card() { Suit = "Diamonds", Value = 10 });
            context.Cards.Add(new Card() { Suit = "Spades", Value = 6 });
            context.Cards.Add(new Card() { Suit = "Clubs", Value = 9 });
            context.Cards.Add(new Card() { Suit = "Clubs", Value = 11 });

            context.Players.Add(new Player() { Name = "Bill", Status = "Bot" });
            context.Players.Add(new Player() { Name = "John", Status = "Bot" });

            context.SaveChanges();
            base.Seed(context);
        }
    }
}
