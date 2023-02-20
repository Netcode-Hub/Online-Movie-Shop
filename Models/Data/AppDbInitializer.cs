using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using MovieShop.Models.Data.Enum;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MovieShop.Models.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();
                context.Database.EnsureCreated();

                //Cinemas
                if (!context.Cinemas.Any())
                {
                    context.Cinemas.AddRange(new List<Cinema>()
                {
                    new Cinema()
                    {
                    Name = "Cinema 1",
                    Logo = "http://dotnethow.net/images/cinemas/cinema-1.jpeg",
                    Desc = "This is the description for the first cinema"
                    },
                    new Cinema()
                    {
                        Name = "Cinema 2",
                        Logo = "http://dotnethow.net/images/cinemas/cinema-2.jpeg",
                        Desc = "This is the description for the second cinema"
                    },
                    new Cinema()
                    {
                        Name = "Cinema 3",
                        Logo = "http://dotnethow.net/images/cinemas/cinema-3.jpeg",
                        Desc = "This is the description for the third cinema"
                    },
                    new Cinema()
                    {
                        Name = "Cinema 4",
                        Logo = "http://dotnethow.net/images/cinemas/cinema-4.jpeg",
                        Desc = "This is the description for the forth cinema"
                    }
                });
                    context.SaveChanges();
                }



                //Actors
                if (!context.Actors.Any())
                {
                    context.Actors.AddRange(new List<Actor>()
                {
                    new Actor()
                    {
                        FullName = "Producer 1",
                        ProfilePictureURL = "http://dotnethow.net/images/actors/actor-1.jpeg",
                        Bio =" Ut enim ad minim veniam,nquis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat"
                    },
                    new Actor()
                    {
                        FullName = "Producer 2",
                        ProfilePictureURL = "http://dotnethow.net/images/actors/actor-2.jpeg",
                        Bio ="Pproident, sunt in culpa qui officia deserunt mollit anim id est laborum."
                    },
                    new Actor()
                    {
                        FullName = "Actor 3",
                        ProfilePictureURL = "http://dotnethow.net/images/actors/actor-3.jpeg",
                        Bio ="Duis aute irure dolor in reprehenderit in voluptate velit esse ncillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non."
                    },
                    new Actor()
                    {
                        FullName = "Actor 4",
                        ProfilePictureURL = "http://dotnethow.net/images/actors/actor-4.jpeg",
                        Bio ="Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua."
                    }
                });
                    context.SaveChanges();
                }

                //Producers
                if (!context.Producers.Any())
                {
                    context.Producers.AddRange(new List<Producer>()
                {
                    new Producer()
                    {
                        FullName = "Producer 1",
                        ProfilePictureURL = "http://dotnethow.net/images/producers/producer-1.jpeg",
                        Bio ="This is the Bio for the first  Pproident, sunt in culpa qui officia deserunt mollit anim id est laborum. actor"
                    },
                    new Producer()
                    {
                        FullName = "Producer 2",
                        ProfilePictureURL = "http://dotnethow.net/images/producers/producer-2.jpeg",
                        Bio ="This is the Bio for the second Producer Pproident, sunt in culpa qui officia deserunt mollit anim id est laborum."
                    },
                    new Producer()
                    {
                        FullName = "Producer 3",
                        ProfilePictureURL = "http://dotnethow.net/images/producers/producer-3.jpeg",
                        Bio ="Pproident, sunt in culpa qui officia deserunt mollit anim id est laborum. This is the Bio for the third Producer"
                    },
                    new Producer()
                    {
                        FullName = "Producer 4",
                        ProfilePictureURL = "http://dotnethow.net/images/producers/producer-4.jpeg",
                        Bio ="This is the Bio for Pproident, sunt in culpa qui officia deserunt mollit anim id est laborum. the forth Producer"
                    }
                });
                    context.SaveChanges();
                }

                //Movies
                if (!context.Movies.Any())
                {
                    context.Movies.AddRange(new List<Movie>()
                {
                    new Movie()
                    {
                        Name = "Scoob",
                        Desc ="This is the Scoob Movie description",
                        Price = 39.50,
                        Image = "http://dotnethow.net/images/movies/movie-1.jpeg",
                        StartDate = DateTime.Now.AddDays(-10),
                        EndDate = DateTime.Now.AddDays(-2),
                        CinemaId = 1,
                        ProducerId = 3,
                        MovieCategory = MovieCategory.Cartoon
                    },
                    new Movie()
                    {
                        Name = "Cold Soles",
                        Desc ="This is the Cold Soles description",
                        Price = 90.50,
                        Image = "http://dotnethow.net/images/movies/movie-2.jpeg",
                        StartDate = DateTime.Now.AddDays(3),
                        EndDate = DateTime.Now.AddDays(20),
                        CinemaId = 3,
                        ProducerId = 3,
                        MovieCategory = MovieCategory.Drama
                    },
                    new Movie()
                    {
                        Name = "Winter",
                        Desc ="This is the Winter description",
                        Price = 29.90,
                        Image = "http://dotnethow.net/images/movies/movie-3.jpeg",
                        StartDate = DateTime.Now.AddDays(-1),
                        EndDate = DateTime.Now.AddDays(20),
                        CinemaId = 1,
                        ProducerId = 4,
                        MovieCategory = MovieCategory.Actions
                    },
                    new Movie()
                    {
                        Name = "Sword",
                        Desc ="This is the Sword description",
                        Price = 59.10,
                        Image = "http://dotnethow.net/images/movies/movie-4.jpeg",
                        StartDate = DateTime.Now.AddDays(5),
                        EndDate = DateTime.Now.AddDays(25),
                        CinemaId = 1,
                        ProducerId = 2,
                        MovieCategory = MovieCategory.Actions
                    }
                });
                    context.SaveChanges();
                }

                //Actors_Movies
                if (!context.Actors_Movies.Any())
                {
                    context.Actors_Movies.AddRange(new List<Actor_Movie>()
                {
                    new Actor_Movie()
                    {
                        ActorId = 1,
                        MovieId = 2
                    },
                    new Actor_Movie()
                    {
                        ActorId = 3,
                        MovieId = 2
                    },
                    new Actor_Movie()
                    {
                        ActorId = 2,
                        MovieId = 1
                    },
                    new Actor_Movie()
                    {
                        ActorId = 3,
                        MovieId = 4
                    }
                });
                    context.SaveChanges();
                }

            }
        }
    }
}
