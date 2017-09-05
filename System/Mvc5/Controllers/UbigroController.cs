using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain;
using Service;
using System.Net;

namespace Mvc5.Controllers
{
    public class UbigroController : Controller
    {
       

        private IUbigeoService _ubigeoService;
        public UbigroController()
        {
            if (_ubigeoService == null)
            {
                _ubigeoService = new UbigeoService();
            }
        }
        
        // GET: Ubigro
        public ActionResult Index(string criterio)
        {
            var ub = _ubigeoService.GetUbigeos(criterio);
            return View(ub);
        }

        // GET: Ubigro/Details/5
        public ActionResult Details()
        {
          
            return View();
        }

        // GET: Ubigro/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ubigro/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Ubigro/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Ubigro/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Ubigro/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Ubigro/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
