using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiPrueba.Models
{
    [Table(name: "Usuario")]
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(name: "IdUsuario")]
        public int Id { get; set; }

        [Column(name: "Nombre", TypeName = "Varchar (255)")]
        public string FirstName { get; set; }

        [Column(name: "Clave", TypeName = "Varchar (20)")]
        public string Password { get; set; }

        [Column(name: "Email", TypeName = "Varchar (100)")]
        public string Email { get; set; }

        [Column(name: "Rol", TypeName = "Varchar (255)")]
        public string Role { get; set; }

        [Column(name: "Apellido", TypeName = "Varchar (255)")]
        public string LastName { get; set; }
        
        public virtual ICollection<HistorialRefreshToken> HistorialRefreshTokens { get; } = new List<HistorialRefreshToken>();
    }
}