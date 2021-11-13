using ExemploCodeFirst.Dto;
using ExemploCodeFirst.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExemploCodeFirst.Controler
{
    public class JogoControler
    {
        //CRUD
        public Jogo ObterJogoPorId(Guid id)
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

        public void ApagarJogoPorId(Guid id)
        {
            var dbContext = new PlataformaDBContext();
            var jogo= dbContext.Jogos.FirstOrDefault(x => x.Id == id);
            dbContext.Jogos.Remove(jogo);
            dbContext.SaveChanges();


        }

        public void AtualizarJogo(Guid id, JogoDto jogoDto)
        {
            var dbContext = new PlataformaDBContext();
            var jogo= dbContext.Jogos.FirstOrDefault(x => x.Id == id);
            jogo.Nome = jogoDto.Nome;
            var categoria = dbContext.Categorias.FirstOrDefault(x => x.Nome == jogoDto.Categoria);
            jogo.Categoria = categoria;
            dbContext.SaveChanges();
        }

    }
}
