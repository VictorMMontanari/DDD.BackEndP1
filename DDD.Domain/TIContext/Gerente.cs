using DDD.Domain.SecretariaContext;
using DDD.Domain.UserManagementContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain.TI
{
    public class Gerente : User
    {
        public string CargaHoraria { get; set; }
        public List<Programador>? Programadores { get; set; }
    }
}
