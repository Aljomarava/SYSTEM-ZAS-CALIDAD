using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IAsistenciaAlumnoService
    {
        IEnumerable<AsistenciaAlumno> GetAsistencias(string criterio);
        AsistenciaAlumno GetAsistencia(int id);
        void AddAsistencia(AsistenciaAlumno asistenciaAlumno);
        void UpdateAsistencia(AsistenciaAlumno asistenciaAlumno);
    }
}
