using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcemploCodeFirst.Model
{
    public class PlataformaDBContext : DbContext
    {
        public PlataformaDBContext()
                    : base("name=DataBaseDeJogos")
        {
        }

        public DbSet<Plataforma> Plataformas { get; set; }
        public DbSet<Jogo> Jogos{get;set;}
    }
}
