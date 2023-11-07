using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiPrueba.Models
{
    [Table(name: "Producto")]
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(name: "IdProducto")]
        public int Id { get; set; }

        [Column(name: "Nombre", TypeName = "varchar (255)")]
        public string Name { get; set; }

        [Column(name: "Codigo", TypeName = "varchar (15)")]
        public string Code { get; set; }

        [Column(name: "Categoria", TypeName = "varchar (255)")]
        public string Category { get; set; }

        [Column(name: "Stock")]
        public int Stock { get; set; }

        [Column(name: "Precio", TypeName = "numeric(18, 2)")]
        public decimal Price { get; set; }
    }
}