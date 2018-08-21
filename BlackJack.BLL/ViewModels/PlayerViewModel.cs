using BlackJack.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.BLL.ViewModels
{
    public class PlayerViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public int Count { get; set; }

        public List<Card> Cards { get; set; }

        public PlayerViewModel()
        {
            Cards = new List<Card>();
        }
    }
}
