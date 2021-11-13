using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExemploCodeFirst.Model
{
    [Table("Category")]
    public class Categoria
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [MaxLength(255, ErrorMessage = "Nome muito grande")]
        [MinLength(10)]
        [Column("Name")]
        public string Nome { get; set; }

    }
}
