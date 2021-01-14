
using System.ComponentModel.DataAnnotations;

namespace QuizTime.Shared.Data
{
    public class Player
    {
        public Player Copy()
        {   
            return (Player) this.MemberwiseClone();
        }

        [Required]
        [StringLength(25, ErrorMessage = "Name is too long.")]
        public string Name {get; set;}

        public uint MinLevel {get; set;}

        public uint MaxLevel {get; set;}

        public ThemeColor Color {get; set;}
    }
}