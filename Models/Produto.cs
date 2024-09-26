namespace VimaV2.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public string Descricao { get; set; }
        public int Estoque { get; set; }
        public List<string> Tamanhos { get; set; }
        public List<string> Imagens { get; set; }
        public string ImageURL { get; set; } // Certifique-se de que esta propriedade existe
    }
}
