using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieSite.Data
{
    public class MovieContext : DbContext
    {
        /*
         * three ways to configure the model in EF Core -
         * 1. convention (e.g. if there is a property named "Id" or "<classname>Id",
         *     by default it will be a primary key)
         * 2. fluent API (make method calls in the DbContext.OnModelCreating method)
         * 3. DataAnnotations on the entity classes themselves
         * 
         * #2 is preferred
         */
        // Entity Framework Core
        // code-first approach steps...
        /*
         * 1. have a data access library project separate from the startup application project.
         *    (with a project reference from the latter to the former.)
         * 2. install Microsoft.EntityFrameworkCore.Design
         *    and Microsoft.EntityFrameworkCore.SqlServer to both projects.
         * 3. derive a class from DbContext in the data access project. you want: zero-arg constructor,
         *    DbContextOptions constructor, DbSets, and OnModelCreating override.
         * 4. register the DbContext as a service in the ASP.NET startup project's Startup class, and
         *    add connection string to user secrets.
         * 5. using Git Bash / terminal, from the data access project folder run:
         *    dotnet ef migrations add (name-of-migration) --startup-project (path-to-startup-proj)
         *    dotnet ef database update --startup-project (path-to-startup-proj)
         *    https://docs.microsoft.com/en-us/ef/core/miscellaneous/cli/dotnet#dotnet-ef-migrations-add
         * 5. any time you change the structure of the EF configuration, go to step 5.
         */

        public MovieContext()
        { }

        public MovieContext(DbContextOptions<MovieContext> options) : base(options)
        { }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>(entity =>
            {
                // unnecessary since conventions will set this up anyway:
                entity.HasKey(e => e.Id); // Id is primary key

                // set up IDENTITY for thhis column
                entity.Property(e => e.Id)
                    .UseSqlServerIdentityColumn();

                entity.Property(e => e.Title)
                    .IsRequired() // NOT NULL
                    .HasMaxLength(200); // NVARCHAR(200)

                // i think .NET DateTime is T-SQL DATETIME by default...
                // for code-first of DateTimes, we want to override the column type
                //entity.Property(e => e.ReleaseYear)
                //    .HasColumnType("DATETIME2");

                // configure relationships:
                //  (marking these as navigation properties)
                entity.HasOne(e => e.Genre)
                    .WithMany(e => e.Movies)
                    .OnDelete(DeleteBehavior.SetNull);
                // if there is no explicit foreign key property,
                // one will be added called "shadow property"
            });
        }
    }
}
