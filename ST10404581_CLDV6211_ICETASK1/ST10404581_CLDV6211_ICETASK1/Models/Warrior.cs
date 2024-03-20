using System.ComponentModel.DataAnnotations;

namespace ST10404581_CLDV6211_ICETASK1.Models
{
    public class Warrior
    {
        public int Id {  get; set; }
        [Required(ErrorMessage = "The Name of the Warrior is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "The date this Warrior joined is required for the ledger")]
        public string DateJoined { get; set; }
        public int TimesSummoned { get; set; }
    }
}
