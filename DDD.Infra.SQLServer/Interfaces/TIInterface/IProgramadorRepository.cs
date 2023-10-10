using DDD.Domain.TI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Infra.SQLServer.Interfaces.TIInterface
{
    public interface IProgramadorRepository
    {
        public List<Programador> GetProgramadors();
        public Programador GetProgramadorById(int id);
        public void InsertProgramador(Programador programador);
        public void UpdateProgramador(Programador programador);
        public void DeleteProgramador(Programador programador);
    }
}
