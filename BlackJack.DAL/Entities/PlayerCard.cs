using System.ComponentModel.DataAnnotations;

namespace BlackJack.DAL.Entities
{
    public class PlayerCard
    {
        [Key]
        public int Id { get; set; }

        public int PlayerId { get; set; }

        public int CardId { get; set; }

        public string ImageSource { get; set; }
    }
}
