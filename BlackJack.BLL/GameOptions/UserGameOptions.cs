using System.ComponentModel.DataAnnotations;

namespace BlackJack.BLL.GameOptions
{
    public class UserGameOptions
    {
        [Display(Name = "Number of bots")]
        public int? NumberOfPlayers { get; set; }

        [Display(Name = "Your name")]
        public string PlayerName { get; set; }
    }
}
