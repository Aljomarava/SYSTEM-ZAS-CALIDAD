using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Domain;
using System.Data.Entity;

namespace Repository
{
    public class MatriculaRepository :MasterRepository,IMatriculaRepository
    {
        public void AddMatricula(Matricula matricula)
        {
            Context.matriculas.Add(matricula);
            Context.SaveChanges();
        }

        public void EditarMatricula(Matricula matricula)
        {
            Context.Entry(matricula).State = EntityState.Modified;
            Context.SaveChanges();
        }

        public void EliminarMatricula(int idMatricula)
        {
            var matricula = Context.matriculas.Find(idMatricula);

            if (matricula != null)
            {
                Context.matriculas.Remove(matricula);
                Context.SaveChanges();
            }
        }

        public Matricula GetMatriculaByCodigo(string codigo)
        {
            return Context.matriculas.SingleOrDefault(x => x.Alumno.Dni.Equals(codigo));
        }

        public Matricula GetMatriculaById(int? idMatricula)
        {
            return Context.matriculas.Find(idMatricula);
        }

        public IEnumerable<Matricula> GetMatriculas()
        {
            return Context.matriculas;
        }

        public IEnumerable<Matricula> GetMatriculas(string criterio)
        {
            var query = from p in Context.matriculas
                        select p;

            if (!string.IsNullOrEmpty(criterio))
            {
                query = from p in query
                        where p.Alumno.Dni.ToUpper().Contains(criterio.ToUpper()) ||
                              p.Alumno.Apellidos.ToUpper().Contains(criterio.ToUpper())
                        select p;
            }

            return query;
        }

        public IEnumerable<Matricula> GetMatriculas(string criterio, int? idUbigeo)
        {
            var query = from p in Context.matriculas
                        select p;

            if (!string.IsNullOrEmpty(criterio))
            {
                query = from p in query
                        where p.Alumno.Dni.ToUpper().Contains(criterio.ToUpper()) ||
                              p.Alumno.Apellidos.ToUpper().Contains(criterio.ToUpper())
                        select p;
            }

            if (idUbigeo.HasValue)
            {
                query = query.Where(p => p.ApoderadoId.Equals(idUbigeo.Value));
            }

            return query;
        }


    }
}
