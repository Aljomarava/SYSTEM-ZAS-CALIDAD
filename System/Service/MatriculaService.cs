using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Repository;


namespace Service
{
    public class MatriculaService  : IMatriculaService
    {

        private IMatriculaRepository _matriculaRepository;


        public MatriculaService()
        {
            if (_matriculaRepository == null)
            {
                _matriculaRepository = new MatriculaRepository();
            }
        }

        public void AddMatricula(Matricula matricula)
        {
            _matriculaRepository.AddMatricula(matricula);
        }

        public void EditarMatricula(Matricula matricula)
        {
            _matriculaRepository.EditarMatricula(matricula);
        }

        public void EliminarMatricula(int idMatricula)
        {
            _matriculaRepository.EliminarMatricula(idMatricula);
        }

        public Matricula GetMatriculaByCodigo(string codigo)
        {
            return _matriculaRepository.GetMatriculaByCodigo(codigo);
        }

        public Matricula GetMatriculaById(int? idMatricula)
        {
            return _matriculaRepository.GetMatriculaById(idMatricula);
        }

        public IEnumerable<Matricula> GetMatriculas()
        {
            return _matriculaRepository.GetMatriculas();
        }

        public IEnumerable<Matricula> GetMatriculas(string criterio)
        {
            return _matriculaRepository.GetMatriculas(criterio);
        }

        public IEnumerable<Matricula> GetMatriculas(string criterio, int? idUbigeo)
        {
            return _matriculaRepository.GetMatriculas(criterio, idUbigeo);
        }

    }
}
