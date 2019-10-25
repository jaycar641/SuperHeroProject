using System.Linq;
using System.Web.Mvc;
using TheSuperHeroProject.Models;

namespace TheSuperHeroProject.Controllers
{
    public class SuperHeroController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: SuperHero
        public ActionResult Index()
        {
            return View();
        }

        // GET: SuperHero/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SuperHero/Create
        public ActionResult Create()
        {
            SuperHero superHero = new SuperHero();
            return View();
        }

        // POST: SuperHero/Create
        [HttpPost]
        public ActionResult Create(SuperHero superHero)
        {
            try
            {
                // TODO: Add insert logic here
                db.SuperHeroes.Add(superHero);
                db.SaveChanges();

                return RedirectToAction("Index"); //view index page without anything in it
            }
            catch
            {
                return View();
            }
        }

        // GET: SuperHero/Edit/5
        public ActionResult Edit(int id)
        {
            SuperHero superHero = new SuperHero();
            superHero = db.SuperHeroes.Where(e => e.Id == id).FirstOrDefault();

            return View(superHero);
        }

        // POST: SuperHero/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, SuperHero superHero)
        {
            try
            {
                // TODO: Add update logic here


                SuperHero superHeroOriginal = db.SuperHeroes.Where(e => e.Id == superHero.Id).FirstOrDefault();

             
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: SuperHero/Delete/5
        public ActionResult Delete(int id)
        {
            SuperHero superHero = db.SuperHeroes.Where(e => e.Id == id).SingleOrDefault();
            return View(superHero);
        }

        // POST: SuperHero/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, SuperHero superhero)
        {
            try
            {
                // TODO: Add delete logic here
                db.SuperHeroes.Remove(superhero);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
