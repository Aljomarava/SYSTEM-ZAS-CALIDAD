using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using System.Data.Entity;

namespace Repository
{
    public class AsistenciaAlumnoRepository : IAsistenciaAlumnoRepository
    {
        private SystemContext _context;

        public AsistenciaAlumnoRepository()
        {
            if (_context == null)
            {
                _context = new SystemContext();
            }
        }

        public void AddAsistencia(AsistenciaAlumno asistenciaAlumno)
        {
            _context.asistenciaAlumno.Add(asistenciaAlumno);
            _context.SaveChanges();
        }

        public AsistenciaAlumno GetAsistenciaAlumno(int id)
        {
            return _context.asistenciaAlumno.Find(id);
        }

        public IEnumerable<AsistenciaAlumno> GetAsistenciaAlumno(string criterio)
        {
            var query = from a in _context.asistenciaAlumno.Include("Seccion.Grado").
                    Include("Seccion.Grado.Nivel").Include("Alumno").Include("Curso")
                        select a;

            if (!string.IsNullOrEmpty(criterio))
            {
                var actual = DateTime.Now.Year.ToString();
                query = from a in query.Include("Seccion").Include("Seccion.Grado").
                        Include("Seccion.Grado.Nivel").Include("Alumno")
                        where (a.Alumno.Nombres.ToUpper().Contains(criterio.ToUpper()) ||
                        a.Alumno.Apellidos.ToUpper().Contains(criterio.ToUpper()))
                        select a;
            }
            return query;
        }

        public void UpdateAsistencia(AsistenciaAlumno asistenciaAlumno)
        {
            _context.Entry(asistenciaAlumno).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
