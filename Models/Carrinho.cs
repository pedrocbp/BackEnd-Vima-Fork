using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using VimaV2.Migrations;

namespace VimaV2.Models
{
    public class Carrinho
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public int Quantidade {  get; set; }
        public string ImageURL {  get; set; }
        public string Product {  get; set; }
        public decimal Preco { get; set; }

        private Carrinho() { }
        public Carrinho (int quantidade, string product, decimal preco)
        {
            Quantidade = quantidade;
            Product = product;
            Preco = preco;
        }
    }
}