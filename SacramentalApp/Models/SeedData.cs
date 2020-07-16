using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SacramentalApp.Data;
using SacramentalApp.Models;
using System;
using System.Linq;

namespace SacramentalApp.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new SacramentalAppContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<SacramentalAppContext>>()))
            {
                // Look for any movies.
                if (context.Meeting.Any())
                {
                    return;   // DB has been seeded
                }

                var meetings = new Meeting[]
                {
                new Meeting{Date=DateTime.Parse("2020-07-05"), ConductingLeader="Carson", OpeningSong="Truth Eternal", OpeningPrayer="Jhon", SacramentHymn="Sabbath Day", CloseningPrayer="Rachel", CloseningSong="Lord, We Ask Thee Ere We Part"},
                new Meeting{Date=DateTime.Parse("2020-07-12"), ConductingLeader="Bishop", OpeningSong="The Lord Be with Us", OpeningPrayer="Mary", SacramentHymn="As Now We Take the Sacrament", CloseningPrayer="Brian", CloseningSong="Lord, I Would Follow Thee"},
                };
                foreach (Meeting s in meetings)
                {
                    context.Meeting.Add(s);
                }
                context.SaveChanges();



                var speechees = new Speech[]
                {
            new Speech{NameSpeaker="Peter", Topic="The Scriptures", MeetingId=1},
            new Speech{NameSpeaker="Rick", Topic="Pray everyday", MeetingId=1},
            new Speech{NameSpeaker="Ryan", Topic="Fast Offering", MeetingId=1},
            new Speech{NameSpeaker="Yan", Topic="The Scriptures", MeetingId=2},
            new Speech{NameSpeaker="Peggy", Topic="Pray everyday", MeetingId=2},
            new Speech{NameSpeaker="Laura", Topic="Fast Offering", MeetingId=2}

                };
                foreach (Speech e in speechees)
                {
                    context.Speech.Add(e);
                }
                context.SaveChanges();
            }
        }
    }
}