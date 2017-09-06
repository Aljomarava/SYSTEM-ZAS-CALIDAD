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
            throw new NotImplementedException();
        }

        public void UpdateAsistencia(AsistenciaAlumno asistenciaAlumno)
        {
            _context.Entry(asistenciaAlumno).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
