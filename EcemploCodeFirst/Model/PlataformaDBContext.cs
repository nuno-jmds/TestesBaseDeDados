using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExemploCodeFirst.Model
{
    public class PlataformaDBContext : DbContext
    {
        public PlataformaDBContext()
                    : base("name=DataBaseDeJogos")
        {
#if DEBUG

            //Database.SetInitializer(new DropCreateDatabaseIfModelChanges<PlataformaDBContext>());
            Database.SetInitializer(new DropCreateDatabaseAlways<PlataformaDBContext>());

#endif


        }

        public DbSet<Plataforma> Plataformas { get; set; }
        public DbSet<Jogo> Jogos{get;set;}

        public DbSet<Categoria> Categorias { get; set; }

        public DbSet<JogoDeConsole> JogoDeConsoles { get; set; }
    }
}
