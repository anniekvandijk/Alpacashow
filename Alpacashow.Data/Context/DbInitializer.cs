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
            if (context.HaltershowEvents.Any())
                {
                    return; // DB has been seeded
                }

            // Enumarables

            var breeds = new[]
            {
                new Breed { Name = "Suri" },
                new Breed { Name = "Huacaya" }
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
                new Sex { Name = "Female" },
                new Sex { Name = "Male" },
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
                new Color { Name = "Multi" },
                new Color { Name = "Grey" },
                new Color { Name = "Black" },
                new Color { Name = "Brown" },
                new Color { Name = "Fawn" },
                new Color { Name = "Beige" },
                new Color { Name = "Lights" },
                new Color { Name = "White" }
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
                new AgeClass { Name = "Junior" },
                new AgeClass { Name = "Intermediate" },
                new AgeClass { Name = "Adult" },
                new AgeClass { Name = "Mature" },
                new AgeClass { Name = "Senior" }
            };
            foreach (var ageClass in ageClasses)
            {
                var db = context.AgeClasses.SingleOrDefault(s => s.Name == ageClass.Name);
                if (db == null)
                {
                    context.AgeClasses.Add(ageClass);
                }
            }

            // Testdata

            var haltershowEvents = new[]
            {
                new HaltershowEvent
                {
                    Name = "ShowEvent 1",
                    Judge = "Judge x",
                    Date = new DateTime(2017, 5, 24),
                    Location = "Assen",
                    Archived = false,
                },
                new HaltershowEvent
                {
                    Name = "ShowEvent 2",
                    Judge = "Judge y",
                    Date = new DateTime(2017, 5, 24),
                    Location = "Boekel",
                    Archived = false,
                }
            };
            foreach (var showEvent in haltershowEvents)
            {
                var db = context.HaltershowEvents.SingleOrDefault(s =>
                    s.Name == showEvent.Name);
                if (db == null)
                {
                    context.HaltershowEvents.Add(showEvent);
                }
            }

            var haltershowAnimals = new[]
            {
                new HaltershowAnimal
                {
                    Name = "alpaca 1",
                    Sex = context.Sexes.Local.Single(p => p.Name == "Female"),
                    Breed = context.Breeds.Local.Single(p => p.Name == "Huacaya"),
                    Dam = "some mother",
                    Sire = "some father",
                    Dob = new DateTime(2017, 06, 10),
                    Chip = "12345",
                    Color = context.Colors.Local.Single(p => p.Name == "Brown"),
                    FarmName = "The owner",
                    HaltershowEvent = context.HaltershowEvents.Local.Single(x => x.Name == "ShowEvent 1")
                },
                new HaltershowAnimal
                {
                    Name = "alpaca 2",
                    Sex = context.Sexes.Local.Single(p => p.Name == "Female"),
                    Breed = context.Breeds.Local.Single(p => p.Name == "Huacaya"),
                    Dam = "some mother",
                    Sire = "some father",
                    Dob = new DateTime(2017, 06, 10),
                    Chip = "12345",
                    Color = context.Colors.Local.Single(p => p.Name == "Brown"),
                    FarmName = "The owner",
                    HaltershowEvent = context.HaltershowEvents.Local.Single(x => x.Name == "ShowEvent 1")
                },
                new HaltershowAnimal
                {
                    Name = "alpaca 3",
                    Sex = context.Sexes.Local.Single(p => p.Name == "Female"),
                    Breed = context.Breeds.Local.Single(p => p.Name == "Huacaya"),
                    Dam = "some mother",
                    Sire = "some father",
                    Dob = new DateTime(2017, 06, 10),
                    Chip = "12345",
                    Color = context.Colors.Local.Single(p => p.Name == "Brown"),
                    FarmName = "Another owner",
                    HaltershowEvent = context.HaltershowEvents.Local.Single(x => x.Name == "ShowEvent 1")
                },
                new HaltershowAnimal
                {
                    Name = "alpaca 4",
                    Sex = context.Sexes.Local.Single(p => p.Name == "Female"),
                    Breed = context.Breeds.Local.Single(p => p.Name == "Huacaya"),
                    Dam = "some mother",
                    Sire = "some father",
                    Dob = new DateTime(2017, 06, 10),
                    Chip = "12345",
                    Color = context.Colors.Local.Single(p => p.Name == "Brown"),
                    FarmName = "Another owner",
                    HaltershowEvent = context.HaltershowEvents.Local.Single(x => x.Name == "ShowEvent 2")
                },
                new HaltershowAnimal
                {
                    Name = "alpaca 5",
                    Sex = context.Sexes.Local.Single(p => p.Name == "Female"),
                    Breed = context.Breeds.Local.Single(p => p.Name == "Huacaya"),
                    Dam = "some mother",
                    Sire = "some father",
                    Dob = new DateTime(2017, 06, 10),
                    Chip = "12345",
                    Color = context.Colors.Local.Single(p => p.Name == "Brown"),
                    FarmName = "Another owner",
                    HaltershowEvent = context.HaltershowEvents.Local.Single(x => x.Name == "ShowEvent 2")
                }

            };
            foreach (var animal in haltershowAnimals)
            {
                var db = context.HaltershowAnimals.SingleOrDefault(s => s.Name == animal.Name );
                if (db == null)
                {
                    context.HaltershowAnimals.Add(animal);
                }
            }
            context.SaveChanges();
        }
    }
}
