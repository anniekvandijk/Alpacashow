using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Alpacashow.Models;

namespace Alpacashow.Data
{
    public class DbInitializer
    {
        public static void Initialize(AlpacashowContext context)
        {
            // Look for any students.
            if (context.ShowEvents.Any())
            {
                return; // DB has been seeded
            }

            var showEvents = new ShowEvent[]
            {
                new ShowEvent
                {
                    Name = "ShowEvent 1",
                    Judge = "Judge x",
                    Date = new DateTime(2017, 5, 24),
                    Location = "Assen",
                    Archived = false
                }

            };
            foreach (var showEvent in showEvents)
            {
                context.ShowEvents.Add(showEvent);
            }
            context.SaveChanges();

            // Enumarables

            var breeds = new Breed[]
            {
                new Breed
                {
                    Name = "Suri",
                    SortOrder = 1
                },
                new Breed
                {
                    Name = "Huacaya",
                    SortOrder = 2
                }
            };
            foreach (var breed in breeds)
            {
                context.Breeds.Add(breed);
            }
            context.SaveChanges();

            var sexes = new Sex[]
            {
                new Sex
                {
                    Name = "Female",
                    SortOrder = 1
                },
                new Sex
                {
                    Name = "Male",
                    SortOrder = 2
                },
                new Sex
                {
                    Name = "Gelding",
                    SortOrder = 3
                }
            };
            foreach (var sex in sexes)
            {
                context.Sexes.Add(sex);
            }
            context.SaveChanges();

            var colors = new Color[]
            {
                new Color
                {
                    Name = "Fancy",
                    SortOrder = 1
                },
                new Color
                {
                    Name = "Grey",
                    SortOrder = 2
                },
                new Color
                {
                    Name = "Black",
                    SortOrder = 3
                },
                new Color
                {
                    Name = "Brown",
                    SortOrder = 4
                },
                new Color
                {
                    Name = "Fawn",
                    SortOrder = 5
                },
                new Color
                {
                    Name = "Beige",
                    SortOrder = 6
                },
                new Color
                {
                    Name = "Lights",
                    SortOrder = 7
                },
                new Color
                {
                    Name = "White",
                    SortOrder = 8
                }
            };
            foreach (var color in colors)
            {
                context.Colors.Add(color);
            }
            context.SaveChanges();

            var ageClasses = new AgeClass[]
            {
                new AgeClass
                {
                    Name = "Junior",
                    SortOrder = 1
                },
                new AgeClass
                {
                    Name = "Intermediate",
                    SortOrder = 2
                },
                new AgeClass
                {
                    Name = "Adult",
                    SortOrder = 3
                },
                new AgeClass
                {
                    Name = "Mature",
                    SortOrder = 4
                },
                new AgeClass
                {
                    Name = "Senior",
                    SortOrder = 5
                },
            };
            foreach (var ageClass in ageClasses)
            {
                context.AgeClasses.Add(ageClass);
            }
            context.SaveChanges();
        }
    }
}
