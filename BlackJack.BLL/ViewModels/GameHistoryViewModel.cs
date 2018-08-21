using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.BLL.ViewModels
{
    public class GameHistoryViewModel
    {
        public int RoundId { get; set; }
        public int WinnerId { get; set; }
        public string WinnerName { get; set; }
        public int WinnerScore { get; set; }
        public DateTime Date { get; set; }
    }
}
