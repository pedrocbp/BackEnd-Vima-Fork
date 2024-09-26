using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VimaV2.Models
{
    public class Contato
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public string Assunto { get; set; }
        public string Description { get; set; }


        private Contato() { }

        public Contato(string name, string sobrenome, string email, string assunto, string description)
        {

            this.Name = name;
            this.Sobrenome = sobrenome;
            this.Email = email;
            this.Assunto = assunto;
            this.Description = description;
        }
    }
}
