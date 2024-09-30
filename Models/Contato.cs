using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VimaV2.Models
{
    public class Contato
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Sobrenome { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(100)]
        public string Assunto { get; set; }

        [Required]
        [StringLength(500)]
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
