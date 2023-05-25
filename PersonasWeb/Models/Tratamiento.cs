using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CEBodyPlanet.Models
{
    public class Tratamiento
    {
        [Key]
        public int Id_tratamiento { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [StringLength(50, MinimumLength = 10)]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [StringLength(50, MinimumLength = 10)]
        public string DescripcionTratamiento { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [Range(1, 999999), DataType(DataType.Currency)]
        [Column(TypeName = "decimal(10, 2)")]
        public decimal Precio { get; set; }


    }
}
