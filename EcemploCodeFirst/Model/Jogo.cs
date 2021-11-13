using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExemploCodeFirst.Model
{
    [Table("Games")]
    public class Jogo
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        
        [MaxLength(255,ErrorMessage ="Nome muito grande")]
        [MinLength(10)]
        [Column("Name")]
        public string Nome { get; set; }
        //[MaxLength(50, ErrorMessage = "Nome muito grande")]
        //public string TipoJogo { get; set; }

        [Column("Position")]
        public int Posicao { get; set; }

        public virtual Plataforma Plataforma { get; set; }

        public virtual Categoria Categoria { get; set; }

       


    }
}