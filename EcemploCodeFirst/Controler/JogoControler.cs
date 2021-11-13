using EcemploCodeFirst.Dto;
using EcemploCodeFirst.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcemploCodeFirst.Controler
{
    public class JogoControler
    {
        //CRUD
        public Jogo ObterJogoPorId(int id)
        {
            var dbContext = new PlataformaDBContext();


            return dbContext.Jogos.FirstOrDefault(x => x.Id == id);

        }

        public List<Jogo> ListarTodos()
        {
            var dbContext = new PlataformaDBContext();

            return dbContext.Jogos.ToList();
        }

        public void AdicionarJogo(Jogo jogo)
        {
            var dbContext = new PlataformaDBContext();
            dbContext.Jogos.Add(jogo);
            dbContext.SaveChanges();

        }

        public void ApagarJogo(Jogo jogo)
        {
            var dbContext = new PlataformaDBContext();
            dbContext.Jogos.Remove(jogo);
            dbContext.SaveChanges();


        }

        public void AtualizarJogo(int id, JogoDto jogoDto)
        {
            var dbContext = new PlataformaDBContext();
            var jogo= dbContext.Jogos.FirstOrDefault(x => x.Id == id);
            jogo.Nome = jogoDto.Nome;
            jogo.TipoJogo = jogoDto.TipoJogo;
            dbContext.SaveChanges();
        }

    }
}
