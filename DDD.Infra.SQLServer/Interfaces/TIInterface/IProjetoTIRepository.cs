using DDD.Domain.SecretariaContext;
using DDD.Domain.TI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Infra.SQLServer.Interfaces.TIInterface
{
    public interface IProjetoTIRepository
    {
        public List<ProjetoTI> GetProjetosTI();
        public ProjetoTI GetProjetoTIById(int id);
        //public void InsertProjetoTI(ProjetoTI projetoTI);
        public ProjetoTI InsertProjetoTI(int idGerente, int idProgramador);
        public void UpdateProjetoTI(ProjetoTI projetoTI);
        public void DeleteProjetoTI(ProjetoTI projetoTI);
    }
}
