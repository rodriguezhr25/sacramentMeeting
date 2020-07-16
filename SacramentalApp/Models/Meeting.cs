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
        public DateTime Date { get; set; }

        [StringLength(100, MinimumLength = 10)]
        [Display(Name = "Conducting Leader")]
        public string ConductingLeader { get; set; }

        [StringLength(100, MinimumLength = 10)]
        [Display(Name = "Opening Song")]        
        public string OpeningSong { get; set; }

        [StringLength(100, MinimumLength = 10)]
        [Display(Name = "Opening Prayer")]
        public string OpeningPrayer { get; set; }

        [StringLength(100, MinimumLength = 10)]
        [Display(Name = "Sacrament Hymn")]
        public string SacramentHymn { get; set; }

        [StringLength(100, MinimumLength = 10)]
        public string Speaker { get; set; }

        [StringLength(100, MinimumLength = 10)]
        [Display(Name = "Closening Song")]
        public string CloseningSong { get; set; }

        [StringLength(100, MinimumLength = 10)]
        [Display(Name = "Closening Prayer")]
        public string CloseningPrayer { get; set; }

        
    }

}
