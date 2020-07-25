using e_Days.DataLayer.DbContexts;
using e_Days.DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace e_Days.DataLayer.DataGenerator
{
    public class InMemoryDb
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new EDaysDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<EDaysDbContext>>()))
            {
                if (context.MessageOfTheDays.Any())
                {
                    return;
                }

                context.MessageOfTheDays.AddRange(
                    new MessageOfTheDay
                    {
                        Day = "monday",
                        Message = "First day of the week!"
                    },
                    new MessageOfTheDay
                    {
                        Day = "tuesday",
                        Message = "Second day of the week!"
                    },
                    new MessageOfTheDay
                    {
                        Day = "wednesday",
                        Message = "Third day of the week!"
                    },
                    new MessageOfTheDay
                    {
                        Day = "thursday",
                        Message = "Fourth day of the week!"
                    },
                    new MessageOfTheDay
                    {
                        Day = "friday",
                        Message = "Fifth day of the week!"
                    },
                    new MessageOfTheDay
                    {
                        Day = "saturday",
                        Message = "Sixth day of the week!"
                    },
                    new MessageOfTheDay
                    {
                        Day = "sunday",
                        Message = "Seventh day of the week!"
                    });

                context.SaveChanges();
            }
        }

        public static DbContextOptions<EDaysDbContext> GetInMemoryDbContextOptions(string dbName = "EDaysMessageOfTheDay")
        {
            var options = new DbContextOptionsBuilder<EDaysDbContext>()
                .UseInMemoryDatabase(databaseName: dbName)
                .Options;

            return options;
        }
    }
}
