using DigitalCursos.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace DigitalCursosAPI.Context
{
    public class AppDbContext :  DbContext
    {
       // public const string connectionString = "Server = localhost; Database = DigitalDemoDB; User Id = sqlserver; Password = 090112; Pooling = true;";

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Curso> Cursos { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            //Aluno
            mb.Entity<Aluno>()
                .HasKey(x => x.AlunoId);
            mb.Entity<Aluno>()
                .Property(x => x.Nome).HasMaxLength(150);
            mb.Entity<Aluno>()
                .Property(x => x.Sobrenome).HasMaxLength(100);
            mb.Entity<Aluno>()
                .Property(x => x.Email).HasMaxLength(100);

            //Curso
            mb.Entity<Curso>()
                .HasKey(x => x.CursoId);
            mb.Entity<Curso>()
                .Property(x => x.CursoNome).HasMaxLength(150);
            mb.Entity<Curso>()
                .Property(x => x.Descricao).HasMaxLength(150);
            mb.Entity<Curso>()
                .Property(x => x.Preco).
                HasColumnType("decimal(18,2)");

            //dados
            mb.Entity<Curso>().HasData(
                new Curso
                {
                    CursoId = 1,
                    CursoNome = "CSharp Basico",
                    Descricao = "Curso de C# Básico",
                    CargaHoraria = 40,
                    Inicio = new System.DateTime(2021, 09, 06),
                    Preco = 150.00M,
                    Logo = null

                }
            );

            mb.Entity<Curso>().HasData(
                new Curso
                {
                    CursoId = 2,
                    CursoNome = "Asp .Net Core Basico",
                    Descricao = "Asp .Net Core Básico",
                    CargaHoraria = 40,
                    Inicio = new System.DateTime(2021, 09, 06),
                    Preco = 250.00M,
                    Logo = null

                }
            );

            mb.Entity<Aluno>().HasData(
                new Aluno
                {
                    AlunoId = 1,
                    Nome = "Felipe",
                    Sobrenome = "Ribeiro",
                    Email = "felipe@email.com",
                    Nascimento = new System.DateTime(2002, 07, 11),
                    Foto = null,
                    Genero = Genero.Masculino,
                    CursoId = 1
                }
            );

            mb.Entity<Aluno>().HasData(
                new Aluno
                {
                    AlunoId = 2,
                    Nome = "Maria",
                    Sobrenome = "Silveira",
                    Email = "maria@email.com",
                    Nascimento = new System.DateTime(2001, 05, 07),
                    Foto = null,
                    Genero = Genero.Feminino,
                    CursoId = 2
                }
            );

        }
    }
}
