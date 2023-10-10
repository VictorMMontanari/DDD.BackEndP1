using DDD.Domain.SecretariaContext;
using DDD.Domain.TI;
using DDD.Infra.SQLServer.Interfaces.TIInterface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Infra.SQLServer.Repositories.TIRepository
{
    public class ProjetoTIRepositorySqlServer : IProjetoTIRepository
    {
        private readonly SqlContext _context;
        public ProjetoTIRepositorySqlServer(SqlContext context)
        {
            _context = context;
        }
        public List<ProjetoTI> GetProjetosTI()
        {
            return _context.ProjetosTI.ToList();
        }
        public ProjetoTI GetProjetoTIById(int id)
        {
            return _context.ProjetosTI.Find(id);
        }
        //public void InsertProjetoTI(ProjetoTI projetoTI)
        //{
        //    _context.ProjetosTI.Add(projetoTI);
        //    _context.SaveChanges();
        //}

        public ProjetoTI InsertProjetoTI(int idGerente, int idProgramador)
        {
            var gerente = _context.Gerentes.First(i => i.UserId == idGerente);
            var programador = _context.Programadores.First(i => i.UserId == idProgramador);

            var projetoTI = new ProjetoTI
            {
                Gerente = gerente,
                Programador = programador
            };

            try
            {

                _context.Add(projetoTI);
                _context.SaveChanges();

            }
            catch (Exception ex)
            {
                var msg = ex.InnerException;
                throw;
            }

            return projetoTI;
        }
        public void UpdateProjetoTI(ProjetoTI projetoTI)
        {
            _context.Entry(projetoTI).State = EntityState.Modified;
            _context.SaveChanges();
        }
        public void DeleteProjetoTI(ProjetoTI projetoTI)
        {
            _context.Set<ProjetoTI>().Remove(projetoTI);
            _context.SaveChanges();
        }

        public void InsertProjetoTI(ProjetoTI projetoTI)
        {
            throw new NotImplementedException();
        }
    }
}
