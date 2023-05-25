using System.ComponentModel.DataAnnotations;


namespace CEBodyPlanet.Models
{
    public class Categoria
    {
        [Key]
        public int Id_Categoria { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Nombre Categoria")]
        public string Nombre { get; set; }
        public ICollection<Producto> producto { get; set; }
    }
}
