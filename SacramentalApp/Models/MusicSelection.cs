using System.ComponentModel.DataAnnotations;

namespace SacramentalApp.Models
{
    public class MusicSelection
    {
        public int Id { get; set; } // Unique identifier for each music selection

        [Required]
        public int HymnNumber { get; set; } // Number of the hymn

        [Required]
        [StringLength(100)]
        public string Name { get; set; } // Name of the hymn
    }

}
