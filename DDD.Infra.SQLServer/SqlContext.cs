using DDD.Domain.PicContext;
using DDD.Domain.SecretariaContext;
using DDD.Domain.TI;
using DDD.Domain.UserManagementContext;
using Microsoft.EntityFrameworkCore;

namespace DDD.Infra.SQLServer
{
    public class SqlContext : DbContext
    {

        //https://balta.io/blog/ef-crud
        //https://jasonwatmore.com/post/2022/03/18/net-6-connect-to-sql-server-with-entity-framework-core

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=UniversidadeDb");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Matricula>().HasKey(m => new { m.AlunoId, m.DisciplinaId });
            modelBuilder.Entity<Aluno>()
                .HasMany(e => e.Disciplinas)
                .WithMany(e => e.Alunos)
                .UsingEntity<Matricula>();


            modelBuilder.Entity<User>().UseTpcMappingStrategy();
            modelBuilder.Entity<Aluno>().ToTable("Aluno");
            modelBuilder.Entity<Pesquisador>().ToTable("Pesquisador");
            //https://learn.microsoft.com/pt-br/ef/core/modeling/inheritance

            modelBuilder.Entity<Gerente>()
                .HasMany(e => e.Programadores)
                .WithMany(e => e.Gerente)
                .UsingEntity<ProjetoTI>();

            modelBuilder.Entity<User>().UseTpcMappingStrategy();
            modelBuilder.Entity<Gerente>().ToTable("GerenteTI");
            modelBuilder.Entity<Programador>().ToTable("ProgramadorTI");
            modelBuilder.Entity<ProjetoTI>().ToTable("ProjetosTI");
        }

        //UserManagementContext
        public DbSet<User> Users { get; set; }
        //SecretariaContext
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Disciplina> Disciplinas { get; set; }
        public DbSet<Matricula> Matriculas { get; set; }
        //PicContext
        //public DbSet<Pesquisador> Pesquisadores { get; set; }
        //public DbSet<Projeto> Projetos { get; set; }
        //TIContext
        public DbSet<Gerente> Gerentes { get; set; }
        public DbSet<Programador> Programadores { get; set; }
        public DbSet<ProjetoTI> ProjetosTI { get; set; }
    }
}
