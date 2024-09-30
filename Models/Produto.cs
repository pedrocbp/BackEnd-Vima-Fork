using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VimaV2.Models
{
    public class Produto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Nome { get; set; }

        [Required]
        [Range(0.01, double.MaxValue)]
        public decimal Preco { get; set; }

        [StringLength(500)]
        public string Descricao { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int Estoque { get; set; }

        public List<string> Tamanhos { get; set; }

        public List<string> Imagens { get; set; }

        [Url]
        public string ImageURL { get; set; }
    }
}
