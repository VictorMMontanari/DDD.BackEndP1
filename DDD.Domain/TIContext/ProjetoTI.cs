using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain.TI
{
    public class ProjetoTI
    {
        public int ProjetoId { get; set; }

        public int GerenteId { get; set; }
        public Gerente Gerente { get; set; }

        public int ProgramadorId { get; set; }
        public Programador Programador { get; set; }

        public DateTime DataEntrega { get; set; }
    }
}
