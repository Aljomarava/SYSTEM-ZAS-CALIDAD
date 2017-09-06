using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
   public  interface IAsistenciaAlumnoRepository
    {
        IEnumerable<AsistenciaAlumno> GetAsistenciaAlumno(string criterio);
        AsistenciaAlumno GetAsistenciaAlumno(int id);
        void AddAsistencia(AsistenciaAlumno asistenciaAlumno);
        void UpdateAsistencia(AsistenciaAlumno asistenciaAlumno);
    }
}
