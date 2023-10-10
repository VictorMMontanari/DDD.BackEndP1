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
    public class ProgramadorRepositorySqlServer : IProgramadorRepository
    {
        private readonly SqlContext _context;

        public ProgramadorRepositorySqlServer(SqlContext context)
        {
            _context = context;
        }
        public List<Programador> GetProgramadors()
        {
            return _context.Programadores.ToList();
        }
        public Programador GetProgramadorById(int id)
        {
            return _context.Programadores.Find(id);
        }
        public void InsertProgramador(Programador programador)
        {
            _context.Programadores.Add(programador);
            _context.SaveChanges();
        }
        public void UpdateProgramador(Programador programador)
        {
            _context.Entry(programador).State = EntityState.Modified;
            _context.SaveChanges();
        }
        public void DeleteProgramador(Programador programador)
        {
            _context.Set<Programador>().Remove(programador);
            _context.SaveChanges();
        }
    }
}
