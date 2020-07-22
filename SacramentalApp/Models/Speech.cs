using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SacramentalApp.Models
{
    public class Speech
    {
        public int Id { get; set; }
        public int MeetingId { get; set; }
        [Display(Name = "Name Speaker")]
        [StringLength(100, MinimumLength = 10)]
        public string NameSpeaker { get; set; }
        [StringLength(100, MinimumLength = 10)]
        [Display(Name = "Topic")]
        public string Topic { get; set; }
    }
}
