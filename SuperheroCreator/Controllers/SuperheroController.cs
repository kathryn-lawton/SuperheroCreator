using SuperheroCreator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SuperheroCreator.Controllers
{
    public class SuperheroController : Controller
    {
		// GET: Superhero
		public ActionResult Index()
        {
			ApplicationDbContext db = new ApplicationDbContext();

            return View();
        }
    }
}