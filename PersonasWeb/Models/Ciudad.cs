using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace CEBodyPlanet.Models
{
    public class Ciudad
    {

        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_Ciudad { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [StringLength(9, MinimumLength = 4, ErrorMessage = "Verificque extension (min4-max9")]
        [Display(Name = "Código Postal")]
        public int CodPostal { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [StringLength(50, MinimumLength = 4, ErrorMessage = "Verifique valor ingresado ")]
        public string Nombre { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string Provincia { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [StringLength(50, MinimumLength = 5)]
        public string Pais { get; set; }
        public ICollection<Persona>? Persona { get; set; }
    }
}
