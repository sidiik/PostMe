using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ReactivitiesV1.Domain;
namespace ReactivitiesV1.Data
{
    public class Seed
    {
        public static async Task SeedData(DataContext context)
        {
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