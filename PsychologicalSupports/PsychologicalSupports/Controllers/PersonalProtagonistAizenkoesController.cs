﻿using System.Net;
using System.Web.Mvc;
using PsychologicalSupports.Models;
using PsychologicalSupports.Models.Dependencies;

namespace PsychologicalSupports.Controllers
{
    public class PersonalProtagonistAizenkoesController : Controller
    {
        private readonly IPsychologicalSupportsContext _context;
        private IRepository<PersonalProtagonistAizenko> _repository;
        public PersonalProtagonistAizenkoesController(IRepository<PersonalProtagonistAizenko> repository, IPsychologicalSupportsContext context)
        {
            _context = context;
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
            var PersonaAnxietyScale = _repository.Get(id);
            if (PersonaAnxietyScale == null)
            {
                return HttpNotFound();
            }
            return View(PersonaAnxietyScale);
        }

        public ActionResult Create()
        {
            ViewBag.StudentID = new SelectList(_context.Students, "StudentID", "FIO");
            return View();
        }

        [HttpPost]
        public ActionResult Create(PersonalProtagonistAizenko PersonalProtagonistAizenko)
        {
            if (ModelState.IsValid)
            {
                _repository.Create(PersonalProtagonistAizenko);
                return RedirectToAction("Index");
            }

            ViewBag.StudentID = new SelectList(_context.Students, "StudentID", "FIO", PersonalProtagonistAizenko.StudentID);
            return View(PersonalProtagonistAizenko);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var PersonaAnxietyScale = _repository.Get(id);
            if (PersonaAnxietyScale == null)
            {
                return HttpNotFound();
            }
            ViewBag.StudentID = new SelectList(_context.Students, "StudentID", "FIO", PersonaAnxietyScale.StudentID);
            return View(PersonaAnxietyScale);
        }

        [HttpPost]
        public ActionResult Edit(PersonalProtagonistAizenko PersonalProtagonistAizenko)
        {
            if (ModelState.IsValid)
            {
                _repository.Edit(PersonalProtagonistAizenko);
                return RedirectToAction("Index");
            }
            ViewBag.StudentID = new SelectList(_context.Students, "StudentID", "FIO", PersonalProtagonistAizenko.StudentID);
            return View(PersonalProtagonistAizenko);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var PersonaAnxietyScale = _repository.Get(id);
            if (PersonaAnxietyScale == null)
            {
                return HttpNotFound();
            }
            return View(PersonaAnxietyScale);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            _repository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
