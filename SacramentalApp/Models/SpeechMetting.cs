using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SacramentalApp.Models
{
    public class SpeechMeeting
    {
        public Meeting MeetingData { get; set; }
        public Speech SpeechData { get; set; }
    }
}
