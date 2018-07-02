using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SuperheroCreator.Models
{
	public class Superhero
	{
		[Key]
		public int SuperheroId { get; set; }
		public string Name { get; set; }
		public string AlterEgoName { get; set; }
		public string PrimaryAbility { get; set; }
		public string SecondaryAbility { get; set; }
		public string Catchphrase { get; set; }

	}
}