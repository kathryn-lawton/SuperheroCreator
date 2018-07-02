namespace SuperheroCreator.Migrations
{
	using SuperheroCreator.Models;
	using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SuperheroCreator.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SuperheroCreator.Models.ApplicationDbContext context)
        {
			context.Superhero.AddOrUpdate(
				s => s.Name,
				new Superhero { Name = "Superman", AlterEgoName = "Clark Kent", PrimaryAbility = "Super Strength", SecondaryAbility = "Heat Vision", Catchphrase = "Son of Krypton"},
				new Superhero { Name = "Batman", AlterEgoName = "Bruce Wayne", PrimaryAbility = "Rich/Technology", SecondaryAbility = "Batarangs", Catchphrase = "I am the night!"},
				new Superhero { Name = "Thor", AlterEgoName = "Thor", PrimaryAbility = "Uses Mjölnir", SecondaryAbility = "Uses thunder", Catchphrase = "Odin's Beard!" },
				new Superhero { Name = "Captain America", AlterEgoName = "Steve Rodgers", PrimaryAbility = "Super Strength", SecondaryAbility = "Accelerated Healing", Catchphrase = "Avengers Assemble"},
				new Superhero { Name = "Hulk", AlterEgoName = "Bruce Banner", PrimaryAbility = "Super Strength", SecondaryAbility = "Superhuman Stamina", Catchphrase = "HULK SMASH"}

				);


        }
    }
}
