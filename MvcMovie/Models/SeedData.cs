using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcMovie.Data;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace MvcMovie.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MvcMovieContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MvcMovieContext>>()))
            {
                // Look for any movies.
                if (context.Movie.Any())
                {
                    return;   // DB has been seeded
                }

                context.Genre.AddRange(
                    new Genre { GenreName = "Action" },
                    new Genre { GenreName = "Drama" },
                    new Genre { GenreName = "Comedy" },
                    new Genre { GenreName = "Animated" },
                    new Genre { GenreName = "Adventure" },
                    new Genre { GenreName = "Music" },
                    new Genre { GenreName = "Documentary" },
                    new Genre { GenreName = "Biographical" }
                );

                context.SaveChanges();

                context.Movie.AddRange(
                    new Movie
                    {
                        Title = "The R.M.",
                        ReleaseDate = DateTime.Parse("2003-1-31"),
                        Genre = context.Genre.Where(e => e.GenreName == "Comedy").FirstOrDefault(),
                        Price = 7.99M,
                        Rating = "PG",
                        ImageUrl = "https://m.media-amazon.com/images/M/MV5BMTI4NzQ1OTMyNV5BMl5BanBnXkFtZTYwMTE1NzQ3._V1_UY1200_CR92,0,630,1200_AL_.jpg"
                    },

                    new Movie
                    {
                        Title = "The Other Side of Heaven",
                        ReleaseDate = DateTime.Parse("2001-12-14"),
                        Genre = context.Genre.Where(e => e.GenreName == "Adventure").FirstOrDefault(),
                        Price = 6.99M,
                        Rating = "PG",
                        ImageUrl = "https://upload.wikimedia.org/wikipedia/en/thumb/1/11/The_Other_Side_of_Heaven_theatrical_poster.png/220px-The_Other_Side_of_Heaven_theatrical_poster.png"
                    },

                    new Movie
                    {
                        Title = "Meet the Mormons",
                        ReleaseDate = DateTime.Parse("2014-10-10"),
                        Genre = context.Genre.Where(e => e.GenreName == "Documentary").FirstOrDefault(),
                        Price = 8.99M,
                        Rating = "PG",
                        ImageUrl = "https://upload.wikimedia.org/wikipedia/en/1/17/Meet_the_Mormons_poster.jpg"
                    }
                );

                context.SaveChanges();
            }
        }
    }
}