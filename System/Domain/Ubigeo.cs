using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace Domain
{
    [Table("Ubigeo")]
    public class Ubigeo
    {
       

        //[Required]
        //[MaxLength(80)]
        //public String Codigo { get; set; }
        
        [Required]
        [MaxLength(80)]
        public String Departamento { get; set; }

        [Required]
        [MaxLength(80)]
        public String Provincia { get; set; }

        [Required]
        [MaxLength(80)]
        public String Distrito { get; set; }

        [Key]
        [StringLength(255)]
       
        public String IdUbigeo { get; set; }

        public List<Alumno> Alumnos { get; set; }
        public List<Apoderado> Apoderados { get; set; }
        public List<Docente> Docentes { get; set; }
    }
}
