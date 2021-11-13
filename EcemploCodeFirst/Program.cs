using ExemploCodeFirst.Controler;
using ExemploCodeFirst.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExemploCodeFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            var jogo1 = new Jogo();
            jogo1.Nome = "Primeiro jogo";
            var jogo2 = new Jogo();
            jogo2.Nome = "Segundo jogo";




            var app = new JogoControler();
            app.AdicionarJogo(jogo1);
            app.AdicionarJogo(jogo2);
            var jogos = app.ListarTodos();

            foreach(var item in jogos)
            {

                Console.WriteLine(item.Nome);
            }
            //Atualizar
            app.AtualizarJogo(jogo1.Id, new Dto.JogoDto {Nome="Guerra das estrelas" });
            //app.ApagarJogoPorId();


            foreach (var item in jogos)
            {

                Console.WriteLine(item.Nome);
            }

        }
    }
}
