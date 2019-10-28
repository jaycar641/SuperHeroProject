using System.Collections;
using System.Collections.Generic;
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
            SuperHero superHero = db.SuperHeroes.Where(e => e.Id == id).FirstOrDefault();

            return View(superHero);
        }



        // GET: SuperHero/List
        public ActionResult List()
        {
            //List<SuperHero> SuperHeroesList = new List<SuperHero>();

            //foreach (SuperHero hero in db.SuperHeroes.ToList())
            //    SuperHeroesList.Add(db.SuperHeroes.Where(e => e))
            try
            {
                List<SuperHero> superHeroesList = db.SuperHeroes.ToList();

                return View(superHeroesList);
            }
            catch
            {
                return View();
            }
           


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
             //   SuperHero original = new SuperHero();
               // original = db.SuperHeroes.Where(e => e.Id == id).FirstOrDefault();
                SuperHero super = new SuperHero(); // created instance in function to be updated
                super = db.SuperHeroes.Where(hero => hero.Id == superHero.Id).FirstOrDefault(); //setting the instance to the returned super hero
                super = superHero;


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
                SuperHero super1 = new SuperHero();

                super1 = db.SuperHeroes.Where(e => e.Id == id).SingleOrDefault();

                superhero = super1;
               db.SuperHeroes.Remove(super1);
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
