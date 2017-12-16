﻿using System;
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
            if (context.ShowEvents.Any())
                {
                    return; // DB has been seeded
                }

            // Enumarables

            var breeds = new[]
            {
                new Breed { Name = "Suri", SortOrder = 1 },
                new Breed { Name = "Huacaya", SortOrder = 2 }
            };
            foreach (var breed in breeds)
            {
                context.Breeds.Add(breed);
            }
            context.SaveChanges();

            var sexes = new[]
            {
                new Sex { Name = "Female", SortOrder = 1 },
                new Sex { Name = "Male", SortOrder = 2 },
                new Sex { Name = "Gelding", SortOrder = 3 }
            };
            foreach (var sex in sexes)
            {
                context.Sexes.Add(sex);
            }
            context.SaveChanges();

            var colors = new[]
            {
                new Color { Name = "Fancy", SortOrder = 1 },
                new Color { Name = "Grey", SortOrder = 2 },
                new Color { Name = "Black", SortOrder = 3 },
                new Color { Name = "Brown", SortOrder = 4 },
                new Color { Name = "Fawn", SortOrder = 5 },
                new Color { Name = "Beige", SortOrder = 6 },
                new Color { Name = "Lights", SortOrder = 7 },
                new Color { Name = "White", SortOrder = 8 }
            };
            foreach (var color in colors)
            {
                context.Colors.Add(color);
            }
            context.SaveChanges();

            var ageClasses = new[]
            {
                new AgeClass { Name = "Junior", SortOrder = 1 },
                new AgeClass { Name = "Intermediate", SortOrder = 2 },
                new AgeClass { Name = "Adult", SortOrder = 3 },
                new AgeClass { Name = "Mature", SortOrder = 4 },
                new AgeClass { Name = "Senior", SortOrder = 5 }
            };
            foreach (var ageClass in ageClasses)
            {
                context.AgeClasses.Add(ageClass);
            }
            context.SaveChanges();

            var showTypes = new[]
            {
                new ShowType {Name = "Haltershow"},
                new ShowType {Name = "Fleeceshow"},
                new ShowType {Name = "Male progeny show"},
                new ShowType {Name = "Female progeny show"}
            };
            foreach (var showType in showTypes)
            {
                context.ShowTypes.Add(showType);
            }
            context.SaveChanges();

            //var showEvents = new List<ShowEvent>()
            //{
            //    new ShowEvent
            //    {
            //        Name = "ShowEvent 2",
            //        Judge = "Judge x",
            //        Date = new DateTime(2017, 5, 24),
            //        Location = "Assen",
            //        Archived = false,
            //        ShowEventParticipants = new List<ShowEventParticipant>()
            //        {
            //            new ShowEventParticipant()
            //            {
            //                Owner =

            //                    new Owner
            //                    {
            //                        Name = "Some participant",
            //                        FarmName = "Some farm",
            //                        Animals = new List<Animal>()
            //                        {
            //                            new Animal
            //                            {
            //                                Name = "alpaca 1",
            //                                Sex = context.Sexes.Local.Single(p => p.Name == "female"),
            //                                Breed = context.Breeds.Local.Single(p => p.Name == "huayaca"),
            //                                Dam = "some mother",
            //                                Sire = "some father",
            //                                Dob = new DateTime(2017, 06, 10),
            //                                Chip = "12345",
            //                                Color = context.Colors.Local.Single(p => p.Name == "brown"),
            //                            }
            //                        }
            //                    }
            //            }
            //        }
            //    }

            //};
            //foreach (var showEvent in showEvents)
            //{
            //    context.ShowEvents.Add(showEvent);
            //}
            //context.SaveChanges();

        }
    }
}
