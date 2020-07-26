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
                        Message = "First day of the week!",
                        ImageUri = "https://i.picsum.photos/id/691/500/300.jpg?hmac=jV1DCIjt_dPUH1LwsdD4JWxwNJsGXw17kwNPigT-uHU"
                    },
                    new MessageOfTheDay
                    {
                        Day = "tuesday",
                        Message = "Second day of the week!",
                        ImageUri = "https://i.picsum.photos/id/744/300/200.jpg?hmac=KE76JBBoTBvHSXvn41S-YPRIKZKdk7UofatxWuvM8ZI"
                    },
                    new MessageOfTheDay
                    {
                        Day = "wednesday",
                        Message = "Third day of the week!",
                        ImageUri = "https://i.picsum.photos/id/300/500/300.jpg?hmac=MONeDb-b0gZOF9WHzNhkHju-LZW5djrHndHkXWZu328"
                    },
                    new MessageOfTheDay
                    {
                        Day = "thursday",
                        Message = "Fourth day of the week!",
                        ImageUri = "https://i.picsum.photos/id/70/500/300.jpg?hmac=M-kj-0xbybkKSimOHYJ4d1koPfy4YVzALc8aUGPsX38"
                    },
                    new MessageOfTheDay
                    {
                        Day = "friday",
                        Message = "Fifth day of the week!",
                        ImageUri = "https://i.picsum.photos/id/583/500/300.jpg?hmac=z6dJFBj44YB2PmAVP6CIy4V-8xxIUY1-U8qGg5hP2mw"
                    },
                    new MessageOfTheDay
                    {
                        Day = "saturday",
                        Message = "Sixth day of the week!",
                        ImageUri = "https://i.picsum.photos/id/167/500/300.jpg?hmac=RZt0UnFmltQCOGTCe6UrfaC0QhBhy3DxNy8ZKgVLdY4"
                    },
                    new MessageOfTheDay
                    {
                        Day = "sunday",
                        Message = "Seventh day of the week!",
                        ImageUri = "https://i.picsum.photos/id/916/500/300.jpg?hmac=chGglQIkK0_TKrNvejbLQYd0xhW4PyM3PHHAJxoewxY"
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
