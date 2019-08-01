using EfDemo.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Type = EfDemo.DataAccess.Entities.Type;

namespace EfDemo.App
{
    static class Program
    {
        // Entity Framework Core
        // database-first approach steps...
        /*
         * 1. have a data access library project separate from the startup application project.
         *    (with a project reference from the latter to the former.
         * 2. install Microsoft.EntityFrameworkCore.Design to both projects,
         *    and Microsoft.EntityFrameworkCore.SqlServer to the startup project.
         * 3. using Git Bash / terminal, from the data access project folder run (split into several lines for clarity):
         *    dotnet ef dbcontext scaffold <connection-string-in-quotes>
         *      Microsoft.EntityFrameworkCore.SqlServer
         *      --startup-project <path-to-startup-project-folder>
         *      --force
         *      --output-dir Entities
         *    https://docs.microsoft.com/en-us/ef/core/miscellaneous/cli/dotnet#dotnet-ef-dbcontext-scaffold
         * 4. delete the DbContext.OnConfiguring method from the scaffolded code.
         *    (so that the connection string is not put on the public internet)
         * 5. any time you change the structure of the tables (DDL), go to step 3.
         */

        static void Main()
        {
            var connectionString = SecretConfig.ConnectionString;

            var options = new DbContextOptionsBuilder<PokemonDBContext>()
                .UseSqlServer(connectionString)
                .Options;

            Pokemon Charazard = new Pokemon();
            Charazard.Name = "Charazard";
            Charazard.Height = 300;
            
            


            DisplayPokemon(options);
            AddNewPokemon(options);
            //EditSomePokemon();

            DisplayPokemon(options);
            //DeleteSomePokemon();

            //DisplayPokemon();

        }

        private static void DeleteSomePokemon(DbContextOptions<PokemonDBContext> options)
        {
            using (var dbContext = new PokemonDBContext(options))
            {
                if(dbContext.Pokemon.FirstOrDefault(x => x.Name == "Charmander") is Pokemon charmander)
                {

                }
            }
        }

        private static void EditSomePokemon(DbContextOptions<PokemonDBContext> options)
        {
            // in between dbContext creation and each savechnages call is a transactoon
            using (var dbContext = new PokemonDBContext(options))
            {
                //ef "tracks the" object you pull out of it
                Pokemon charmander = dbContext.Pokemon.Include(x => x.Type)
                                                       .First(x => x.Name == "charmander");

                var grass = dbContext.Type.First(x => x.Name == "Grass");
                var fire = dbContext.Type.First(x => x.Name == "Fire");

                if (charmander.Type == fire)
                {

                }






            }
        }

        private static void AddNewPokemon(DbContextOptions<PokemonDBContext> options)
        {
            
            using (var dbContext = new PokemonDBContext(options))
            {
                if (!dbContext.Pokemon.Any(x => x.Name == "Charmander"))
                {


                    var newPokemon = new Pokemon
                    {
                        Name = "Charmander",
                        Height = 36,
                        Type = new Type
                        {
                            Name = "Fire"
                        }
                    };
                    dbContext.Pokemon.Add(newPokemon);

                    dbContext.SaveChanges();
                } else
                {
                    Pokemon p = dbContext.Pokemon.First(x => x.Name == "charmander");
                    Console.WriteLine($"You already have a {p.Name}....dont be greedy");
                }
            }
        }

        private static void DisplayPokemon(DbContextOptions<PokemonDBContext> options)
        {
            using (var dbContext = new PokemonDBContext(options))
            {
                if (!dbContext.Pokemon.Any())
                {
                    Console.WriteLine("No Pokemon Found... GO Catch Some");
                }
                else
                {
                    foreach (Pokemon p in dbContext.Pokemon.Include(x => x.Type))
                    {
                        var str = $"{p.PokemonId}:{p.Name} ({p.Height})";
                        if(p.Evolution != null)
                        {
                            str += $"[{p.Evolution}]";
                        }
                        //foreach( Type type in dbContext.Type)
                        //{
                        //    if(p.TypeId == type.TypeId)
                        //    str += $"[{type.Name}]";
                        //}

                        str += $"[{p.Type.Name}]";

                        Console.WriteLine(str);
                    }
                }

            }
        }
    }
}
