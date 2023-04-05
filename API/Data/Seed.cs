using API.Domain;
using Microsoft.AspNetCore.Identity;
using ReactivitiesV1.Domain;
namespace ReactivitiesV1.Data
{
    public class Seed
    {
        public static async Task SeedData(DataContext context, UserManager<AppUser> userManager)
        {

            if (!userManager.Users.Any())
            {
                var users = new List<AppUser>
                {
                      new AppUser {UserName = "sidiq",DisplayName = "Sidiiq Cumar", Email = "sidiikpro@gmail.com"},
                        new AppUser {UserName = "ahmed",DisplayName = "ahmed Cumar", Email = "ahmedcumar@gmail.com"}
                };

                foreach (var user in users)
                {
                    await userManager.CreateAsync(user, "Pa$$w0rd");
                }
            }

            if (context.Posts.Any()) return;

            var posts = new List<Post>()
            {
                new Post {
                 Id = 1,
                 Title = "The first post",
                 Content = "Some first post content",
                 CreatedAt = DateTime.UtcNow.AddDays(-7),
                 LastUpdatedAt =  DateTime.UtcNow.AddDays(-7),
                 IsPublished = true
                   },
                    new Post {
                 Id = 2,
                 Title = "The Second post",
                 Content = "Some Second post content",
                 CreatedAt = DateTime.UtcNow.AddDays(-3),
                 LastUpdatedAt =  DateTime.UtcNow.AddDays(-1),
                 IsPublished = false
                   }
            };
            await context.AddRangeAsync(posts);
            await context.SaveChangesAsync();
        }
    }
}