using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Domain;

namespace Service
{
   public interface IMatriculaService
    {
        IEnumerable<Matricula> GetMatriculas(string criterio, Int32? idUbigeo);
        IEnumerable<Matricula> GetMatriculas(string criterio);
        IEnumerable<Matricula> GetMatriculas();
        Matricula GetMatriculaById(Int32? idMatricula);

        void AddMatricula(Matricula matricula);
        void EditarMatricula(Matricula matricula);

        void EliminarMatricula(Int32 idMatricula);

        Matricula GetMatriculaByCodigo(string codigo);



    }
}
