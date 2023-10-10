using DDD.Domain.SecretariaContext;
using DDD.Domain.UserManagementContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain.TI
{
    public class Programador : User
    {
        //public int ProgramadorId { get; set; }
        public string NivelAtuacao { get; set; }

        public IList<Gerente>? Gerente { get; set; }
    }
}
