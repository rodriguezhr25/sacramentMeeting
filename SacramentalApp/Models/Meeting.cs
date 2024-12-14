using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SacramentalApp.Models
{
    public class Meeting
    {
        public int Id { get; set; }


        [DataType(DataType.Date)]
        [Required]
        public DateTime Date { get; set; }

        [StringLength(100, MinimumLength = 10)]
        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$", ErrorMessage = "Insert only Letters, first letter Uppercase")]
        [Display(Name = "Conducting Leader")]
        public string ConductingLeader { get; set; }

        // Foreign key for Sacrament Hymn
        public int? OpeningSongId { get; set; }
        public MusicSelection OpeningSong { get; set; }
        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$", ErrorMessage = "Insert only Letters, first letter Uppercase")]
        [StringLength(100, MinimumLength = 10)]
        [Display(Name = "Opening Prayer")]
        public string OpeningPrayer { get; set; }

        // Foreign key for Sacrament Hymn
        public int? SacramentHymnId { get; set; }
        public MusicSelection SacramentHymn { get; set; }

        // Foreign key for Intermediate Hymn
        public int? IntermediateHymnId { get; set; }
        public MusicSelection IntermediateHymn { get; set; }

        // Foreign key for Closening Song
        public int? CloseningSongId { get; set; }
        public MusicSelection CloseningSong { get; set; }
       
        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$", ErrorMessage = "Insert only Letters, first letter Uppercase")]
        [StringLength(100, MinimumLength = 10)]
        [Display(Name = "Benediction")]
        public string CloseningPrayer { get; set; }

        public ICollection<Speech> Speeches { get; set; }

        // New properties
        [Range(0, int.MaxValue, ErrorMessage = "Attendance must be a non-negative number.")]
        [Display(Name = "Attendance")]
        public int? Attendance { get; set; } // Optional attendance field


        [DataType(DataType.MultilineText)]
        [StringLength(1000, ErrorMessage = "Announcements cannot exceed 1000 characters.")]
        [Display(Name = "Announcements")]
        public string Announcements { get; set; } // Large text for announcements
 

        [DataType(DataType.MultilineText)]
        [StringLength(1000, ErrorMessage = "Acknowledgements cannot exceed 1000 characters.")]
        [Display(Name = "Acknowledgements")]
        public string Acknowledgements { get; set; } // Large text for acknowledgements
 
    }

}
