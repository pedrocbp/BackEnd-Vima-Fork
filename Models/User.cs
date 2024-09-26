using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace VimaV2.Models
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

        private User() { }
        public User(string nome, string sobrenome, string email, string senha)
        {
            this.Nome = nome;
            this.Sobrenome = sobrenome;
            this.Email = email;
            this.Senha = senha;
        }
    }
}
