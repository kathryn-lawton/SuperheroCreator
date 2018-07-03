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
			var superheroes = db.Superhero.ToList();

            return View(superheroes);
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

		[HttpGet]
		public ActionResult Delete(bool? saveChangesError=false, int id=0)
		{
			ApplicationDbContext db = new ApplicationDbContext();
			if (saveChangesError.GetValueOrDefault())
			{
				ViewBag.ErrorMessage = "Delete was not successful. Please try again, and if the problem continues contact your system administrator."; 
			}
			Superhero superhero = db.Superhero.Find(id);
			if(superhero == null)
			{
				return HttpNotFound();
			}
			return View(superhero);
		}

		[HttpPost]
		public ActionResult Delete(int id)
		{
			ApplicationDbContext db = new ApplicationDbContext();
			try
			{
				Superhero superhero = db.Superhero.Find(id);
				db.Superhero.Remove(superhero);
				db.SaveChanges();
			}
			catch (Exception)
			{
				return RedirectToAction("Delete", new { id = id, saveChangesError = true });
			}
			return RedirectToAction("Index");
		}

	}
}