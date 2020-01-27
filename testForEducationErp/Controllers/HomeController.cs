using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using testForEducationErp.DAL;
using testForEducationErp.Models;
using PagedList.Mvc;
using PagedList;
using System.IO;
using System.Net;

namespace testForEducationErp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(int? page, int? filterYearStart, int? filterYearEnd, string filterTitle = "", string filterProducer = "")
        {
            int pageSize = 20;
            int pageNumber = (page ?? 1);

            if(filterYearStart == null && filterYearEnd == null)
            {
                filterYearStart = DateTime.Now.AddYears(-3).Year;
                filterYearEnd = DateTime.Now.Year;
            }
            
            return View(Films.GetFilms(filterTitle, filterYearStart, filterYearEnd, filterProducer).
                OrderByDescending(y => y.YearRelease).ToPagedList(pageNumber, pageSize));
        }

        [Authorize]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Film film, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = Config.db.Users.Where(u => u.UserName == User.Identity.Name).FirstOrDefault();
                film.UserId = user.Id;

                Config.db.Films.Add(film);
                Config.db.SaveChanges();

                if (image != null)
                {
                    film.Poster = string.Format("{0}.{1}", film.Id, Path.GetExtension(image.FileName).TrimStart(new char[] { '.' }));
                    Config.db.SaveChanges();
                    image.SaveAs(Server.MapPath("~/Images/" + film.Poster));
                }

                return RedirectToAction("Index");
            }
            return View(film);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Film film = Films.GetFilmByID((int)id);

            if (film == null)
            {
                return HttpNotFound();
            }
            return View(film);
        }

        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Film film = Films.GetFilmByID((int)id);
            if (film != null)
            {
                if(film.User.UserName != User.Identity.Name)
                    return new HttpStatusCodeResult(HttpStatusCode.Unauthorized);

                return View(film);
            }
            else
                return HttpNotFound();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Film editFilm, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                Film film = Films.GetFilmByID(editFilm.Id);
                if (film == null)
                    return HttpNotFound();

                if (image != null)
                {
                    if (film.Poster != null)
                        System.IO.File.Delete(Server.MapPath("~/Images/" + film.Poster));

                    film.Poster = string.Format("{0}.{1}", film.Id, Path.GetExtension(image.FileName).TrimStart(new char[] { '.' }));
                    image.SaveAs(Server.MapPath("~/Images/" + film.Poster));
                }

                film.Title = editFilm.Title;
                film.Description = editFilm.Description;
                film.YearRelease = editFilm.YearRelease;
                film.Producer = editFilm.Producer;
                Config.db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(editFilm);
        }
    }
}