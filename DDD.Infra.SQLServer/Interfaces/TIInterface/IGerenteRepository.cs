using DDD.Domain.TI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Infra.SQLServer.Interfaces.TIInterface
{
    public interface IGerenteRepository
    {
        public List<Gerente> GetGerentes();
        public Gerente GetGerenteById(int id);
        public void InsertGerente(Gerente gerente);
        public void UpdateGerente(Gerente gerente);
        public void DeleteGerente(Gerente gerente);
    }
}
