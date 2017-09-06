using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Repository;

namespace Service
{
    public class AsistenciaAlumnoService : IAsistenciaAlumnoService
    {
        private IAsistenciaAlumnoRepository _repository;

        public AsistenciaAlumnoService(IAsistenciaAlumnoRepository repository)
        {
            _repository = repository;
        }
        public void AddAsistencia(AsistenciaAlumno asistenciaAlumno)
        {
            _repository.AddAsistencia(asistenciaAlumno);
        }

        public AsistenciaAlumno GetAsistencia(int id)
        {
            return _repository.GetAsistenciaAlumno(id);
        }

        public IEnumerable<AsistenciaAlumno> GetAsistencias(string criterio)
        {

            return _repository.GetAsistenciaAlumno(criterio);
        }

        public void UpdateAsistencia(AsistenciaAlumno asistenciaAlumno)
        {
            _repository.UpdateAsistencia(asistenciaAlumno);
        }
    }
}
