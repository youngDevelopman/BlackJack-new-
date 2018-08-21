using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.DAL.Entities
{
    public class GameHistory
    {
        [Key]
        public int Id { get; set; }
        public int RoundId { get; set; }
        public int WinnerId { get; set; }
        public string WinnerName { get; set; }
        public int WinnerScore { get; set; }
        public DateTime Date { get; set; }

        public List<Card> Cards { get; set; }

        public GameHistory()
        {
            Cards = new List<Card>();
        }
    }
}
