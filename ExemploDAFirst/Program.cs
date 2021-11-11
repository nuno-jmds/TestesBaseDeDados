using StackExchange.Profiling;
using StackExchange.Profiling.EntityFramework6;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExemploDAFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            var profiler = MiniProfiler.StartNew("My Profiler Name");
            MiniProfilerEF6.Initialize();
            using (profiler.Step("Main Work"))
            {              
                ObterTodosOsAlunos();
               ObterTodosOsAlunosQueComecemCom( "M");
                CriarNovoAluno();
                CriarNovoAlunoComTelefone();
                AtualizarDados(2);
                NormalizarDados();
                ApagarDados(29);
            }

            System.IO.File.WriteAllText(@"D:\Projetos\DataBase\profile.txt",profiler.RenderPlainText());
            Console.ReadLine();
        }



        private static void ImprimirSeparador()
        {

            Console.WriteLine("-------------------------");
        }
        #region Consulta
        private static void ObterTodosOsAlunos()
        {
            var escola = new EscolaDBEntities();
            var listaAlunos = escola.Aluno.ToList();

            foreach (var aluno in listaAlunos)
            {

                Console.WriteLine($"Nome Aluno: {aluno.Nome}");

            }
            ImprimirSeparador();
        }

        private static void ObterTodosOsAlunosQueComecemCom(string inicio)
        {
            var escola = new EscolaDBEntities();
            var listaAlunos = escola.Aluno.Where(x=>x.Nome.StartsWith(inicio)).ToList();

            foreach (var aluno in listaAlunos)
            {

                Console.WriteLine($"Nome Aluno: {aluno.Nome}");

            }
            ImprimirSeparador();
        }

        private static void ObterTodosOsAlunosQuePossuemTelefone()
        {
            var escola = new EscolaDBEntities();
            var listaAlunos = escola.Aluno.Where(x => x.Telefone.ToList().Any()).ToList();

            foreach (var aluno in listaAlunos)
            {

                Console.WriteLine($"Nome Aluno: {aluno.Nome}");

            }
            ImprimirSeparador();
        }
        #endregion

        #region Insercao
        private static void CriarNovoAluno()
        {

            var lucas = new Aluno();
            lucas.Nome = "Lucas da Silva";
            lucas.Matricula = "0001234";
            lucas.Sexo = "M";
            lucas.DataNascimento = new DateTime(2009, 01, 05);
            lucas.DataMatricula = DateTime.Today;

            var escola = new EscolaDBEntities();

            escola.Aluno.Add(lucas);
            escola.SaveChanges();

            ImprimirSeparador();
        }

        private static void CriarNovoAlunoComTelefone()
        {

            var maria = new Aluno();
            maria.Nome = "Maria da Silva";
            maria.Matricula = "0001235";
            maria.Sexo = "F";
            maria.DataNascimento = new DateTime(2009, 01, 05);
            maria.DataMatricula = DateTime.Today;

            var telefone = new List<Telefone>(){
            new Telefone
            {
            NumeroTelefone="12311254",
            Prefixo="351"
            }
        };

            maria.Telefone =telefone
                ;
            var escola = new EscolaDBEntities();

            escola.Aluno.Add(maria);
            escola.SaveChanges();

            ImprimirSeparador();
        }

        #endregion

        #region Atualização
        private static void AtualizarDados(int idAluno) 
        {
            var id = 7;
            var escola = new EscolaDBEntities();
            var pedro = escola.Aluno.FirstOrDefault(x => x.Id == id);
            pedro.Nome = "Pedro de Sousa";
            escola.SaveChanges();
        }

        private static void NormalizarDados()
        {
            var escola = new EscolaDBEntities();
            var alunos = escola.Aluno.ToList();

            foreach (var aluno in alunos)
            {
                aluno.Nome = ConverterLetraMaiuscula(aluno.Nome);
                if (aluno.DataMatricula == null)
                {
                    aluno.DataMatricula = DateTime.Today;
                }

            }
            escola.SaveChanges();
        }

        private static string ConverterLetraMaiuscula(string palavra)
        {


            var primeiraLetra = palavra[0].ToString().ToUpper();
            var restoPalavra = palavra.Substring(1, palavra.Length - 1);
            var resultado = primeiraLetra + restoPalavra;

            return resultado;
        }
        
        
        
        
        
        #endregion

        #region Apagar

        private static void ApagarDados(int idAluno)
        {
            var escola = new EscolaDBEntities();
            var aluno = escola.Aluno.FirstOrDefault(x => x.Id == idAluno);
            escola.Telefone.RemoveRange(aluno.Telefone);
            escola.Aluno.Remove(aluno);



            escola.SaveChanges();
        }


        #endregion


    }
}
