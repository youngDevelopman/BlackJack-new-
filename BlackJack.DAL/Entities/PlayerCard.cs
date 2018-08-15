using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.DAL.Entities
{
    public class PlayerCard
    {
        [Key]
        public int Id { get; set; }

        //[ForeignKey("Player")]
        public int PlayerId { get; set; }
        //[ForeignKey("Card")]
        public int CardId { get; set; }
    }
}
