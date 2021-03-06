using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ExemploCodeFirst.Model
{
    [Table("Plataformas")]
    public class Plataforma
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        [MaxLength(255, ErrorMessage = "Nome muito grande")]
        [Column("Name")]
        public string Nome { get; set; }

        public virtual ICollection<Jogo> Jogos { get; set; }
    }
}
