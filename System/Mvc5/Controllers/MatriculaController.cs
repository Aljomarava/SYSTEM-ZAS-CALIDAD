using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Service;

namespace Mvc5.Controllers
{
    public class MatriculaController : Controller
    {

        private IAlumnoService _alumnoService;
        private IApoderadoService _apoderadoService;
        private IMatriculaService _matriculaService;
        // GET: Matricula
        public ActionResult Index()
        {
            return View();
        }


        public MatriculaController()
        {
            if (_alumnoService == null)
            {
                _alumnoService = new AlumnoService();
            }
            if (_apoderadoService == null)
            {
                _apoderadoService = new ApoderadosService();
            }
            if (_matriculaService== null)
            {
                _matriculaService = new MatriculaService();
            }
        }

        public ActionResult BuscarAlumno()
        {
            return View();
        }

        public ActionResult BuscarAlumnoByCodigo(string codigo)
        {
            var alumno = _matriculaService.GetMatriculaByCodigo(codigo);

            var result = new
            {
                success = alumno != null ? true : false,
                data = alumno
            };

            return Json(result, JsonRequestBehavior.AllowGet);
        }


    }
}