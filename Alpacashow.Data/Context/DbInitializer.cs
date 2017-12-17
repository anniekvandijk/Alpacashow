using System;
using System.Linq;
using Alpacashow.Data.Models;
using Alpacashow.Data.Models.Enums;

namespace Alpacashow.Data.Context
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
                var db = context.Breeds.SingleOrDefault(s => s.Name == breed.Name);
                if (db == null)
                {
                    context.Breeds.Add(breed);
                }
            }

            var sexes = new[]
            {
                new Sex { Name = "Female", SortOrder = 1 },
                new Sex { Name = "Male", SortOrder = 2 },
                new Sex { Name = "Gelding", SortOrder = 3 }
            };
            foreach (var sex in sexes)
            {
                var db = context.Sexes.SingleOrDefault(s => s.Name == sex.Name);
                if (db == null)
                {
                    context.Sexes.Add(sex);
                }
            }

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
                var db = context.Colors.SingleOrDefault(s => s.Name == color.Name);
                if (db == null)
                {
                    context.Colors.Add(color);
                }
            }

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
                var db = context.AgeClasses.SingleOrDefault(s => s.Name == ageClass.Name);
                if (db == null)
                {
                    context.AgeClasses.Add(ageClass);
                }
            }

            var showTypes = new[]
            {
                new ShowType {Name = "Haltershow"},
                new ShowType {Name = "Fleeceshow"},
                new ShowType {Name = "Male progeny show"},
                new ShowType {Name = "Female progeny show"}
            };
            foreach (var showType in showTypes)
            {
                var db = context.ShowTypes.SingleOrDefault(s => s.Name == showType.Name);
                if (db == null)
                {
                    context.ShowTypes.Add(showType);
                }
            }

            // Testdata

            var owners = new[]
            {
                new Owner {Name = "The owner", FarmName = "farmname"}
            };
            foreach (var owner in owners)
            {
                var db = context.Owners.SingleOrDefault(s => s.Name == owner.Name);
                if (db == null)
                {
                    context.Owners.Add(owner);
                }
            }

            var animals = new[]
            {
                new Animal
                {
                    Name = "alpaca 1",
                    Sex = context.Sexes.Local.Single(p => p.Name == "Female"),
                    Breed = context.Breeds.Local.Single(p => p.Name == "Huacaya"),
                    Dam = "some mother",
                    Sire = "some father",
                    Dob = new DateTime(2017, 06, 10),
                    Chip = "12345",
                    Color = context.Colors.Local.Single(p => p.Name == "Brown"),
                    Owner = context.Owners.Local.Single(p => p.Name == "The owner"),
                }
            };
            foreach (var animal in animals)
            {
                var db = context.Animals.SingleOrDefault(s => s.Name == animal.Name );
                if (db == null)
                {
                    context.Animals.Add(animal);
                }
            }

            var showEvents = new[]
            {
                new ShowEvent
                {
                    Name = "ShowEvent 2",
                    Judge = "Judge x",
                    Date = new DateTime(2017, 5, 24),
                    Location = "Assen",
                    Archived = false,
                    ShowType = context.ShowTypes.Local.Single(p => p.Name == "Haltershow")
                }
            };
            foreach (var showEvent in showEvents)
            {
                var db = context.ShowEvents.SingleOrDefault(s => 
                s.Name == showEvent.Name && s.ShowType == showEvent.ShowType);
                if (db == null)
                {
                    context.ShowEvents.Add(showEvent);
                }
            }

            var showEventAnimals = new[]
            {
                new ShowEventAnimal
                {
                    Animal = context.Animals.Local.Single(p => p.Name == "alpaca 1"),
                    ShowEvent = context.ShowEvents.Local.Single(p => p.Name == "ShowEvent 2")
                }
            };
            foreach (var showEventAnimal in showEventAnimals)
            {
                var db = context.ShowEventAnimals.SingleOrDefault(s => 
                s.ShowEventId == showEventAnimal.ShowEventId && s.AnimalId == showEventAnimal.AnimalId);
                if (db == null)
                {
                    context.ShowEventAnimals.Add(showEventAnimal);
                }
            }
            context.SaveChanges();

        }
    }
}
