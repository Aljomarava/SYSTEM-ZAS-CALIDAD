using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using System.Data.Entity;

namespace Repository
{
    public class UbigeoRepository : MasterRepository, IUbigeoRepository
    {
        public void AddUbigeo(Ubigeo ubigeo)
        {
            throw new NotImplementedException();
        }

        public void EditarUbigeo(Ubigeo ubigeo)
        {
            Context.Entry(ubigeo).State = EntityState.Modified;
            Context.SaveChanges();
        }

        public void EliminarUbigeo(int idUbigeo)
        {
            throw new NotImplementedException();
        }

        public Ubigeo GetUbigeoByCodigo(string codigo)
        {
            throw new NotImplementedException();
        }

        public Ubigeo GetUbigeo(int? idUbigeo)
        {
            return Context.ubigeos.Find(idUbigeo);
        }

        public IEnumerable<Ubigeo> GetUbigeos()
        {

            var query = from u in Context.ubigeos
                        select u;

            return query;
        }

        public IEnumerable<Ubigeo> GetUbigeos(string criterio)
        {
            var query = from p in Context.ubigeos
                        select p;
            if (!string.IsNullOrEmpty(criterio))
            {
                query = from p in query
                        where 
                              p.IdUbigeo.ToUpper().Contains(criterio.ToUpper())
                        select p;
            }

            return query;
        }
    }
}
