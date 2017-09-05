using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain;
using Service;
using System.Net;
using Mvc5.Models;

namespace Mvc5.Controllers
{
    public class AlumnoController : Controller
    {
        private ApplicationDbContext _context = new ApplicationDbContext();
        private IAlumnoService _alumnoService;

        private IUbigeoService _ubigeoService;
        public AlumnoController()
        {
            if (_alumnoService==null)
            {
                _alumnoService = new AlumnoService();
            }
            if (_ubigeoService == null)
            {
                _ubigeoService = new UbigeoService();
            }
        }
        // GET: Alumno
        public ActionResult Index(string criterio)
        {
            var al = _alumnoService.GetAlumnos(criterio);
         

            
            return View(al);
        }

        // GET: Alumno/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var al = _alumnoService.GetAlumnooById(id);
            if (al == null)
            {
                return HttpNotFound();
            }
            return View(al);
        }

    
        
        // GET: Alumno/Create
        public ActionResult Create()
        {
            //Combo();
            return View();
        }

        //public List<SelectListItem> Departamentos()
        //{
        //    List<SelectListItem> DepartamentoId = new List<SelectListItem>();
        //    var dato = _ubigeoService.GetUbigeos().Where(u => u.IdUbigeo.Remove(0, 2).Equals("0000"));
        //    foreach (var item in dato)
        //    {
        //        DepartamentoId.Add(
        //            new SelectListItem()
        //            {
        //                Text = item.IdUbigeo,
        //                Value = item.Departamento
        //            });
        //    }
        //    return DepartamentoId;
        //}

        //public void Combo()
        //{


        //    var DepartamentoId = Departamentos();
        //    ViewBag.departamento = new SelectList(DepartamentoId, "Text", "Value");

        //    var ProvinciaId = new List<SelectListItem>() {
        //        new SelectListItem() { Text = "Seleccione", Value = "Seleccione" }
        //    };
        //    ViewBag.provincia = new SelectList(ProvinciaId, "Text", "Value");

        //    var DistritoId = new List<SelectListItem>() {
        //        new SelectListItem() { Text = "Seleccione", Value = "Seleccione" }
        //    };
        //    ViewBag.distrito = new SelectList(DistritoId, "Text", "Value");
        //}
        // POST: Alumno/Create
        [HttpPost]
        public ActionResult Create(Alumno alumno, string criterio)
        {
            try
            {
                //Combo();
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    _alumnoService.AddAlumno(alumno);
                    _alumnoService.GetAlumnos(criterio);

                    return RedirectToAction("Index");
                }
                return View("Create",alumno);
            }
            catch
            {
                return View();
            }
        }

        // GET: Alumno/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var al= _alumnoService.GetAlumnooById(id);

            if (al == null)
            {
                return HttpNotFound();
            }
            return View(al);
        }

        // POST: Alumno/Edit/5
        [HttpPost]
        public ActionResult Edit(Alumno alumno)
        {
            try
            {
                // TODO: Add update logic here

                if (ModelState.IsValid)
                {
                    _alumnoService.EditarAlumno(alumno);
                    
                    return RedirectToAction("Index");
                }
                return View(alumno);
            }
            catch
            {
                return View();
            }
        }

        // GET: Alumno/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var al = _alumnoService.GetAlumnooById(id);

            if (al == null)
            {
                return HttpNotFound();
            }
            return View(al);
        }

        // POST: Alumno/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                if (ModelState.IsValid)
                {
                    _alumnoService.EliminarAlumno(id);
                    

                    return RedirectToAction("Index");
                }
                return View(id);
            }
            catch
            {
                return View();
            }
        }
        //public JsonResult GetProvincias(int departmentId)
        //{

        //    string id = "";
        //    if (departmentId.ToString().Count() < 6 && departmentId.ToString().Any()) id = (0 + "" + departmentId);
        //    else id = departmentId.ToString();

        //    _context.Configuration.ProxyCreationEnabled = false;
        //    var provincias = _ubigeoService.GetUbigeos().Where(u => (u.IdUbigeo.ToString().Remove(0, 4).ToString() == "00") &&
        //                                            (u.IdUbigeo.ToString().Remove(2, 4).Equals(id.Remove(2, 4)))).
        //                                            OrderBy(u => u.Provincia);


        //    var provincia = new List<Ubigeo>();

        //    for (int i = 1; i < provincias.Count(); i++)
        //    {
        //        provincia.Add(provincias.ToList()[i]);
        //    }
        //    return Json(provincia);
        //}

        //public JsonResult GetDistritos(int provinciaId)
        //{

        //    string id = "";
        //    if (provinciaId.ToString().Count() < 6 && provinciaId.ToString().Count() > 0) id = (0 + "" + provinciaId);
        //    else { id = provinciaId.ToString(); }

        //    _context.Configuration.ProxyCreationEnabled = false;
        //    var Distritos = _ubigeoService.GetUbigeos().Where(p => p.IdUbigeo.ToString().Remove(0, 4) != "00" &&
        //                                                   p.IdUbigeo.ToString().Remove(4, 2).Equals(id.Remove(4, 2)));

        //    var distrito = new List<Ubigeo>();

        //    for (int i = 0; i < Distritos.Count(); i++)
        //    {
        //        distrito.Add(Distritos.ToList()[i]);
        //    }
        //    return Json(distrito);

        //}

    }
}
