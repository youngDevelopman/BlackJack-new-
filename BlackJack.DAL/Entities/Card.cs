using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BlackJack.DAL.Entities
{
    public class Card
    {
        [Key]
        public int Id { get; set; }
        public int Value { get; set; }
        public string Rank { get; set; }
        public string Suit { get; set; }

        public virtual ICollection<GameHistory> GameHistories { get; set; }

        public Card()
        {
            GameHistories = new List<GameHistory>();
        }
    }
}
