using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SacramentalApp.Data;
using SacramentalApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

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
                // Seed MusicSelections from JSON
                if (!context.MusicSelection.Any())
                {
                    SeedMusicSelections(context);
                }

                // Seed Meetings if the database is empty
                if (context.Meeting.Any())
                {
                    return;   // DB has been seeded
                }

                // Seed Meetings
                var meetings = new Meeting[]
                {
                    new Meeting
                    {
                        Date = DateTime.Parse("2020-07-05"),
                        ConductingLeader = "Carson",
                        OpeningSongId = 1, // Truth Eternal
                        OpeningPrayer = "John",
                        SacramentHymnId = 2, // Sabbath Day
                        CloseningPrayer = "Rachel",
                        CloseningSongId = 5, // Lord, We Ask Thee Ere We Part
                        Attendance = 150,
                        Announcements = "1. Don't forget the upcoming charity event.\n" +
                                    "2. Relief Society will meet this Wednesday.\n" +
                                    "3. Sign up for the Christmas party in the foyer.",
                        Acknowledgements = "We would like to thank everyone who helped with last week's service.\n" +
                                       "Special thanks to the youth group for their hard work in organizing the food drive.\n" +
                                       "Your efforts are greatly appreciated!",
                    },
                    new Meeting
                    {
                        Date = DateTime.Parse("2020-07-12"),
                        ConductingLeader = "Bishop",
                        OpeningSongId = 3, // The Lord Be with Us
                        OpeningPrayer = "Mary",
                        SacramentHymnId = 4, // As Now We Take the Sacrament
                        CloseningPrayer = "Brian",
                        CloseningSongId = 6,  // Lord, I Would Follow Thee
                                  Announcements = "1. Don't forget the upcoming charity event.\n" +
                                    "2. Relief Society will meet this Wednesday.\n" +
                                    "3. Sign up for the Christmas party in the foyer.",
                        Acknowledgements = "We would like to thank everyone who helped with last week's service.\n" +
                                       "Special thanks to the youth group for their hard work in organizing the food drive.\n" +
                                       "Your efforts are greatly appreciated!",
                    }
                };

                foreach (Meeting meeting in meetings)
                {
                    context.Meeting.Add(meeting);
                }
                context.SaveChanges();

                // Seed Speeches
                var speeches = new Speech[]
                {
                    new Speech { NameSpeaker = "Peter Parker", Topic = "The Scriptures", MeetingId = 1 },
                    new Speech { NameSpeaker = "Rick Rojas", Topic = "Pray Every Day", MeetingId = 1 },
                    new Speech { NameSpeaker = "Ryan Oconor", Topic = "Fast Offering", MeetingId = 1 },
                    new Speech { NameSpeaker = "Yan Lee Ju", Topic = "The Scriptures", MeetingId = 2 },
                    new Speech { NameSpeaker = "Peggy Peggy", Topic = "Pray Every Day", MeetingId = 2 },
                    new Speech { NameSpeaker = "Laura Porter", Topic = "Fast Offering", MeetingId = 2 }
                };

                foreach (Speech speech in speeches)
                {
                    context.Speech.Add(speech);
                }
                context.SaveChanges();
            }
        }

        private static void SeedMusicSelections(SacramentalAppContext context)
        {
            var jsonFilePath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "hymns.json");
            var jsonData = File.ReadAllText(jsonFilePath);
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping // For handling special characters
            };

            var hymns = JsonSerializer.Deserialize<List<MusicSelection>>(jsonData, options);

            if (hymns != null)
            {
                try
                {
                    context.MusicSelection.AddRange(hymns);
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    // Log or inspect the exception message
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }
    }
}