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
        public DbSet<GameHistory> GameHistories { get; set; }


    }

    public class ContextInitializer : DropCreateDatabaseAlways<BlackJackContext>
    {
        protected override void Seed(BlackJackContext context)
        {
            //Initializing cards
            context.Cards.Add(new Card() { Suit = "Diamonds", Rank = "Two", Value = 2 });
            context.Cards.Add(new Card() { Suit = "Diamonds", Rank = "Three", Value = 3 });
            context.Cards.Add(new Card() { Suit = "Diamonds", Rank = "Four", Value = 4 });
            context.Cards.Add(new Card() { Suit = "Diamonds", Rank = "Five", Value = 5 });
            context.Cards.Add(new Card() { Suit = "Diamonds", Rank = "Six", Value = 6 });
            context.Cards.Add(new Card() { Suit = "Diamonds", Rank = "Seven", Value = 7 });
            context.Cards.Add(new Card() { Suit = "Diamonds", Rank = "Eight", Value = 8 });
            context.Cards.Add(new Card() { Suit = "Diamonds", Rank = "Nine", Value = 9 });
            context.Cards.Add(new Card() { Suit = "Diamonds", Rank = "Ten", Value = 10 });
            context.Cards.Add(new Card() { Suit = "Diamonds", Rank = "Jack", Value = 10 });
            context.Cards.Add(new Card() { Suit = "Diamonds", Rank = "Queen", Value = 10 });
            context.Cards.Add(new Card() { Suit = "Diamonds", Rank = "King", Value = 10 });
            context.Cards.Add(new Card() { Suit = "Diamonds", Rank = "Ace", Value = 11 });


            context.Cards.Add(new Card() { Suit = "Spades", Rank = "Two", Value = 2 });
            context.Cards.Add(new Card() { Suit = "Spades", Rank = "Three", Value = 3 });
            context.Cards.Add(new Card() { Suit = "Spades", Rank = "Four", Value = 4 });
            context.Cards.Add(new Card() { Suit = "Spades", Rank = "Five", Value = 5 });
            context.Cards.Add(new Card() { Suit = "Spades", Rank = "Six", Value = 6 });
            context.Cards.Add(new Card() { Suit = "Spades", Rank = "Seven", Value = 7 });
            context.Cards.Add(new Card() { Suit = "Spades", Rank = "Eight", Value = 8 });
            context.Cards.Add(new Card() { Suit = "Spades", Rank = "Nine", Value = 9 });
            context.Cards.Add(new Card() { Suit = "Spades", Rank = "Ten", Value = 10 });
            context.Cards.Add(new Card() { Suit = "Spades", Rank = "Jack", Value = 10 });
            context.Cards.Add(new Card() { Suit = "Spades", Rank = "Queen", Value = 10 });
            context.Cards.Add(new Card() { Suit = "Spades", Rank = "King", Value = 10 });
            context.Cards.Add(new Card() { Suit = "Spades", Rank = "Ace", Value = 11 });

            context.Cards.Add(new Card() { Suit = "Hearts", Rank = "Two", Value = 2 });
            context.Cards.Add(new Card() { Suit = "Hearts", Rank = "Three", Value = 3 });
            context.Cards.Add(new Card() { Suit = "Hearts", Rank = "Four", Value = 4 });
            context.Cards.Add(new Card() { Suit = "Hearts", Rank = "Five", Value = 5 });
            context.Cards.Add(new Card() { Suit = "Hearts", Rank = "Six", Value = 6 });
            context.Cards.Add(new Card() { Suit = "Hearts", Rank = "Seven", Value = 7 });
            context.Cards.Add(new Card() { Suit = "Hearts", Rank = "Eight", Value = 8 });
            context.Cards.Add(new Card() { Suit = "Hearts", Rank = "Nine", Value = 9 });
            context.Cards.Add(new Card() { Suit = "Hearts", Rank = "Ten", Value = 10 });
            context.Cards.Add(new Card() { Suit = "Hearts", Rank = "Jack", Value = 10 });
            context.Cards.Add(new Card() { Suit = "Hearts", Rank = "Queen", Value = 10 });
            context.Cards.Add(new Card() { Suit = "Hearts", Rank = "King", Value = 10 });
            context.Cards.Add(new Card() { Suit = "Hearts", Rank = "Ace", Value = 11 });

            context.Cards.Add(new Card() { Suit = "Clubs", Rank = "Two", Value = 2 });
            context.Cards.Add(new Card() { Suit = "Clubs", Rank = "Three", Value = 3 });
            context.Cards.Add(new Card() { Suit = "Clubs", Rank = "Four", Value = 4 });
            context.Cards.Add(new Card() { Suit = "Clubs", Rank = "Five", Value = 5 });
            context.Cards.Add(new Card() { Suit = "Clubs", Rank = "Six", Value = 6 });
            context.Cards.Add(new Card() { Suit = "Clubs", Rank = "Seven", Value = 7 });
            context.Cards.Add(new Card() { Suit = "Clubs", Rank = "Eight", Value = 8 });
            context.Cards.Add(new Card() { Suit = "Clubs", Rank = "Nine", Value = 9 });
            context.Cards.Add(new Card() { Suit = "Clubs", Rank = "Ten", Value = 10 });
            context.Cards.Add(new Card() { Suit = "Clubs", Rank = "Jack", Value = 10 });
            context.Cards.Add(new Card() { Suit = "Clubs", Rank = "Queen", Value = 10 });
            context.Cards.Add(new Card() { Suit = "Clubs", Rank = "King", Value = 10 });
            context.Cards.Add(new Card() { Suit = "Clubs", Rank = "Ace", Value = 11 });

            context.SaveChanges();
            base.Seed(context);
        }
    }
}
