﻿using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using PsychologicalSupports.Models;
using PsychologicalSupports.Models.Dependencies;

namespace PsychologicalSupports.Controllers
{
    public class AveragePointsController : Controller
    {
        private readonly IPsychologicalSupportsContext __context;
        private IRepository<AveragePoint> _repository;
        public AveragePointsController(IRepository<AveragePoint> repository,IPsychologicalSupportsContext context)
        {
            __context = context;
            _repository = repository;
        }
        [Authorize]
        public ActionResult Index()
        {
            return View(_repository.List());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var averagePoint = _repository.Get(id);
            if (averagePoint == null)
            {
                return HttpNotFound();
            }
            return View(averagePoint);
        }

        public ActionResult Create()
        {
            ViewBag.StudentID = new SelectList(__context.Students, "StudentID", "FIO");
            return View();
        }

        [HttpPost]
        public ActionResult Create(AveragePoint averagePoint)
        {
            if (ModelState.IsValid)
            {
                _repository.Create(averagePoint);
                return RedirectToAction("Index");
            }

            ViewBag.StudentID = new SelectList(__context.Students, "StudentID", "FIO", averagePoint.StudentID);
            return View(averagePoint);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var averagePoint = _repository.Get(id);
            if (averagePoint == null)
            {
                return HttpNotFound();
            }
            ViewBag.StudentID = new SelectList(__context.Students, "StudentID", "FIO", averagePoint.StudentID);
            return View(averagePoint);
        }

        [HttpPost]
        public ActionResult Edit(AveragePoint averagePoint)
        {
            if (ModelState.IsValid)
            {
                _repository.Edit(averagePoint);
                return RedirectToAction("Index");
            }
            ViewBag.StudentID = new SelectList(__context.Students, "StudentID", "FIO", averagePoint.StudentID);
            return View(averagePoint);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var averagePoint = _repository.Get(id);
            if (averagePoint == null)
            {
                return HttpNotFound();
            }
            return View(averagePoint);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            _repository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
