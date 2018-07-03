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
			var model = db.Superhero.ToList();

            return View(model);
        }

		[HttpGet]
		public ActionResult Create()
		{
			ApplicationDbContext db = new ApplicationDbContext();
			
			return View();
		}

		[HttpPost]
		public ActionResult Create([Bind (Include = "SuperheroId, Name, AlterEgoName, PrimaryAbility, SecondaryAbility, Catchphrase")] Superhero superhero)
		{
			ApplicationDbContext db = new ApplicationDbContext();
			if (ModelState.IsValid)
			{
				db.Superhero.Add(superhero);
				db.SaveChanges();
				return RedirectToAction("Index");
			}
			ViewBag.superheroId = new SelectList(db.Superhero, "Name", "AlterEgoName", "PrimaryAbility", "SecondaryAbility", "Catchphrase");
			return View(superhero);
		}

		[HttpGet]
		public ActionResult Details(int? id)
		{
			if(id == null)
			{
				return RedirectToAction("Index");
			}

			ApplicationDbContext db = new ApplicationDbContext();

			var foundSuperhero = db.Superhero.Where(s => s.SuperheroId == id).FirstOrDefault();
			if (foundSuperhero == null)
			{
				return RedirectToAction("Index");
			}
			return View(foundSuperhero);
		}

		[HttpGet]
		public ActionResult Edit(int? id)
		{
			if(id == null)
			{
				return RedirectToAction("Index");
			}
			ApplicationDbContext db = new ApplicationDbContext();
	
			var foundSuperheroId = db.Superhero.Where(s => s.SuperheroId == id).FirstOrDefault();
			if (foundSuperheroId == null) 
			{
				return RedirectToAction("Index");
			}
			return View(foundSuperheroId);
		}

		[HttpPost]
		public ActionResult Edit([Bind(Include = "SuperheroId, Name, AlterEgoName, PrimaryAbility, SecondaryAbility, Catchphrase")] Superhero superhero)
		{
			ApplicationDbContext db = new ApplicationDbContext();
			try
			{
				if(ModelState.IsValid)
				{
					db.Entry(superhero).State = System.Data.Entity.EntityState.Modified;
					db.SaveChanges();
					return RedirectToAction("Index");
				}
			}
			catch (Exception)
			{
				ModelState.AddModelError("", "Unable to save changes. Please try again, and if the problem continues contact your system administrator.");
			}
			return View(superhero);
		}


    }
}