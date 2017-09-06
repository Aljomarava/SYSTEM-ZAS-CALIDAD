using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class AsistenciaAlumno
    {
        [Key]
        public Int32 AsistenciaAlumnoId { get; set; }

        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime FechaAsistencia { get; set; }

        [Required]
        public Int32 SeccionId { get; set; }
        public Seccion Seccion { get; set; }

        [Required]
        public Int32 DocenteId { get; set; }
        public Docente Docente { get; set; }
        [Required]
        public Int32 CursoId { get; set; }
        public Curso Curso { get; set; }

        [Required]
        public Int32 AlumnoId { get; set; }
        public Alumno Alumno { get; set; }


        [Required]
        public int AnioAcademicoId { get; set; }
        public AnioAcademico AnioAcademico { get; set; }
    }
}
