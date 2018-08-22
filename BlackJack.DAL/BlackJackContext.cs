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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Card>()
                .HasMany<GameHistory>(c => c.GameHistories)
                .WithMany(h => h.Cards)
                .Map(ch =>
                {
                    ch.MapLeftKey("CardRefId");
                    ch.MapRightKey("GameHistoryRefId");
                    ch.ToTable("CardGameHistory");
                });

            base.OnModelCreating(modelBuilder);
        }
    }

    public class ContextInitializer : DropCreateDatabaseAlways<BlackJackContext>
    {
        protected override void Seed(BlackJackContext context)
        {
            //Initializing cards
            context.Cards.Add(new Card() { Suit = "Diamonds", Rank = "Two", Value = 2, ImageSource = "~/CardImages/2D.png"  });
            context.Cards.Add(new Card() { Suit = "Diamonds", Rank = "Three", Value = 3, ImageSource = "~/CardImages/3D.png" });
            context.Cards.Add(new Card() { Suit = "Diamonds", Rank = "Four", Value = 4, ImageSource = "~/CardImages/4D.png" });
            context.Cards.Add(new Card() { Suit = "Diamonds", Rank = "Five", Value = 5, ImageSource = "~/CardImages/5D.png" });
            context.Cards.Add(new Card() { Suit = "Diamonds", Rank = "Six", Value = 6, ImageSource = "~/CardImages/6D.png" });
            context.Cards.Add(new Card() { Suit = "Diamonds", Rank = "Seven", Value = 7,ImageSource = "~/CardImages/7D.png" });
            context.Cards.Add(new Card() { Suit = "Diamonds", Rank = "Eight", Value = 8, ImageSource = "~/CardImages/8D.png" });
            context.Cards.Add(new Card() { Suit = "Diamonds", Rank = "Nine", Value = 9, ImageSource = "~/CardImages/9D.png" });
            context.Cards.Add(new Card() { Suit = "Diamonds", Rank = "Ten", Value = 10, ImageSource = "~/CardImages/10D.png" });
            context.Cards.Add(new Card() { Suit = "Diamonds", Rank = "Jack", Value = 10, ImageSource = "~/CardImages/JD.png" });
            context.Cards.Add(new Card() { Suit = "Diamonds", Rank = "Queen", Value = 10, ImageSource = "~/CardImages/QD.png" });
            context.Cards.Add(new Card() { Suit = "Diamonds", Rank = "King", Value = 10, ImageSource = "~/CardImages/KD.png" });
            context.Cards.Add(new Card() { Suit = "Diamonds", Rank = "Ace", Value = 11, ImageSource = "~/CardImages/AD.png" });


            context.Cards.Add(new Card() { Suit = "Spades", Rank = "Two", Value = 2, ImageSource = "~/CardImages/2S.png" });
            context.Cards.Add(new Card() { Suit = "Spades", Rank = "Three", Value = 3, ImageSource = "~/CardImages/3S.png" });
            context.Cards.Add(new Card() { Suit = "Spades", Rank = "Four", Value = 4, ImageSource = "~/CardImages/4S.png" });
            context.Cards.Add(new Card() { Suit = "Spades", Rank = "Five", Value = 5, ImageSource = "~/CardImages/5S.png" });
            context.Cards.Add(new Card() { Suit = "Spades", Rank = "Six", Value = 6, ImageSource = "~/CardImages/6S.png" });
            context.Cards.Add(new Card() { Suit = "Spades", Rank = "Seven", Value = 7, ImageSource = "~/CardImages/7S.png" });
            context.Cards.Add(new Card() { Suit = "Spades", Rank = "Eight", Value = 8, ImageSource = "~/CardImages/8S.png" });
            context.Cards.Add(new Card() { Suit = "Spades", Rank = "Nine", Value = 9, ImageSource = "~/CardImages/9S.png" });
            context.Cards.Add(new Card() { Suit = "Spades", Rank = "Ten", Value = 10, ImageSource = "~/CardImages/10S.png" });
            context.Cards.Add(new Card() { Suit = "Spades", Rank = "Jack", Value = 10, ImageSource = "~/CardImages/JS.png" });
            context.Cards.Add(new Card() { Suit = "Spades", Rank = "Queen", Value = 10, ImageSource = "~/CardImages/QS.png" });
            context.Cards.Add(new Card() { Suit = "Spades", Rank = "King", Value = 10, ImageSource = "~/CardImages/KS.png" });
            context.Cards.Add(new Card() { Suit = "Spades", Rank = "Ace", Value = 11, ImageSource = "~/CardImages/AS.png" });

            context.Cards.Add(new Card() { Suit = "Hearts", Rank = "Two", Value = 2, ImageSource = "~/CardImages/2H.png" });
            context.Cards.Add(new Card() { Suit = "Hearts", Rank = "Three", Value = 3, ImageSource = "~/CardImages/3H.png" });
            context.Cards.Add(new Card() { Suit = "Hearts", Rank = "Four", Value = 4, ImageSource = "~/CardImages/4H.png" });
            context.Cards.Add(new Card() { Suit = "Hearts", Rank = "Five", Value = 5, ImageSource = "~/CardImages/5H.png" });
            context.Cards.Add(new Card() { Suit = "Hearts", Rank = "Six", Value = 6, ImageSource = "~/CardImages/6H.png" });
            context.Cards.Add(new Card() { Suit = "Hearts", Rank = "Seven", Value = 7, ImageSource = "~/CardImages/7H.png" });
            context.Cards.Add(new Card() { Suit = "Hearts", Rank = "Eight", Value = 8, ImageSource = "~/CardImages/8H.png" });
            context.Cards.Add(new Card() { Suit = "Hearts", Rank = "Nine", Value = 9, ImageSource = "~/CardImages/9H.png" });
            context.Cards.Add(new Card() { Suit = "Hearts", Rank = "Ten", Value = 10, ImageSource = "~/CardImages/10H.png" });
            context.Cards.Add(new Card() { Suit = "Hearts", Rank = "Jack", Value = 10, ImageSource = "~/CardImages/JH.png" });
            context.Cards.Add(new Card() { Suit = "Hearts", Rank = "Queen", Value = 10, ImageSource = "~/CardImages/QH.png" });
            context.Cards.Add(new Card() { Suit = "Hearts", Rank = "King", Value = 10, ImageSource = "~/CardImages/KH.png" });
            context.Cards.Add(new Card() { Suit = "Hearts", Rank = "Ace", Value = 11, ImageSource = "~/CardImages/AH.png" });

            context.Cards.Add(new Card() { Suit = "Clubs", Rank = "Two", Value = 2, ImageSource = "~/CardImages/2C.png" });
            context.Cards.Add(new Card() { Suit = "Clubs", Rank = "Three", Value = 3, ImageSource = "~/CardImages/3C.png" });
            context.Cards.Add(new Card() { Suit = "Clubs", Rank = "Four", Value = 4, ImageSource = "~/CardImages/4C.png" });
            context.Cards.Add(new Card() { Suit = "Clubs", Rank = "Five", Value = 5, ImageSource = "~/CardImages/5C.png" });
            context.Cards.Add(new Card() { Suit = "Clubs", Rank = "Six", Value = 6, ImageSource = "~/CardImages/6C.png" });
            context.Cards.Add(new Card() { Suit = "Clubs", Rank = "Seven", Value = 7, ImageSource = "~/CardImages/7C.png" });
            context.Cards.Add(new Card() { Suit = "Clubs", Rank = "Eight", Value = 8, ImageSource = "~/CardImages/8C.png" });
            context.Cards.Add(new Card() { Suit = "Clubs", Rank = "Nine", Value = 9, ImageSource = "~/CardImages/9C.png" });
            context.Cards.Add(new Card() { Suit = "Clubs", Rank = "Ten", Value = 10, ImageSource = "~/CardImages/10C.png" });
            context.Cards.Add(new Card() { Suit = "Clubs", Rank = "Jack", Value = 10, ImageSource = "~/CardImages/JC.png" });
            context.Cards.Add(new Card() { Suit = "Clubs", Rank = "Queen", Value = 10, ImageSource = "~/CardImages/QC.png" });
            context.Cards.Add(new Card() { Suit = "Clubs", Rank = "King", Value = 10, ImageSource = "~/CardImages/KC.png" });
            context.Cards.Add(new Card() { Suit = "Clubs", Rank = "Ace", Value = 11, ImageSource = "~/CardImages/AC.png" });

            context.SaveChanges();
            base.Seed(context);
        }
    }
}
