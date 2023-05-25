using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace CEBodyPlanet.Models
{
    public class Marca
    {
        [Key]
       
        public int Id_Marca { get; set; }

        [Display(Name = "Nombre Marca")]
        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [StringLength(50, MinimumLength = 5)]
        public string NomnbreMarca { get; set; }

        public ICollection<Producto> Producto { get; set; }
    }
}
