using DDD.Domain.TI;
using DDD.Infra.SQLServer.Interfaces.TIInterface;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Infra.SQLServer.Repositories.TIRepository
{
    public class GerenteRepositorySqlServer : IGerenteRepository
    {
        private readonly SqlContext _context;

        public GerenteRepositorySqlServer(SqlContext context)
        {
            _context = context;
        }

        public List<Gerente> GetGerentes()
        {
            return _context.Gerentes.ToList();
        }

        public Gerente GetGerenteById(int id)
        {
            return _context.Gerentes.Find(id);
        }
        public void InsertGerente(Gerente gerente)
        {
            _context.Gerentes.Add(gerente);
            _context.SaveChanges();
        }

        public void UpdateGerente(Gerente gerente)
        {
            _context.Entry(gerente).State = EntityState.Modified;
            _context.SaveChanges();
        }
        public void DeleteGerente(Gerente gerente)
        {
            _context.Set<Gerente>().Remove(gerente);
            _context.SaveChanges();
        }
    }
}
