using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CEBodyPlanet.Models
{
    public class Proveedor
    {
    
            [Key]
            public int Id_Proveedor { get; set; }

            [Required]
            [Display(Name = "CUIT Proveedor")]
            public int Cuit_proveedor { get; set; }

            [Required(ErrorMessage = "Este campo es obligatorio.")] 
            [StringLength(50)]
            [Display(Name = "Nombre")]
            public string? Nombre { get; set; }

            [Required(ErrorMessage = "Este campo es obligatorio.")]
            [StringLength(50)]
            [Display(Name = "Apellido")]
            public string? Apellido { get; set; }

            [Required(ErrorMessage = "Este campo es obligatorio.")]
            [StringLength(50)]
            [Display(Name = "Telefonmo/Celular")]
            public string Telefono { get; set; }

            [Required(ErrorMessage = "Este campo es obligatorio.")]
            [StringLength(50)]
            [Display(Name = "Mail")]
            public string Mail { get; set; }

            [Required(ErrorMessage = "Este campo es obligatorio.")]
            [StringLength(50)]
            [Display(Name = "Domicilio")]
            public string Domicilio { get; set; }

            [Required(ErrorMessage = "Este campo es obligatorio.")]
            [Display(Name = "Ciudad")]
            public int CiudadId { get; set; }
            public Ciudad? Ciudad { get; set; }

            public ICollection<Producto> producto { get; set; }
    }

       

    

}
