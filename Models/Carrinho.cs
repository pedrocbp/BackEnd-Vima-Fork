using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

public class Carrinho
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public int Id { get; set; }

    [Required] // Adiciona validação para garantir que a quantidade não seja nula
    public int Quantidade { get; set; }

    [Required] // Verifica se Tamanhos é fornecido
    public string Tamanhos { get; set; }

    [Required] // Verifica se o produto é fornecido
    public string Product { get; set; }

    [Required] // Verifica se o preço é fornecido
    public decimal Preco { get; set; }

    public string ImageURL { get; set; }

    public Carrinho(int quantidade, string tamanhos, string product, decimal preco)
    {
        Quantidade = quantidade;
        Tamanhos = tamanhos;
        Product = product;
        Preco = preco;
    }
}
