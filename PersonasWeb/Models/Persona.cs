using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CEBodyPlanet.Models
{
    public class Persona
    {
    
            [Key]
            public int Id_Persona { get; set; }

            [Required(ErrorMessage = "Este campo es obligatorio.")]
            public int DNI_Persona { get; set; }

            [Required(ErrorMessage = "Este campo es obligatorio.")] 
            [StringLength(50)]
            [Display(Name = "Nombre")]
            public string? Nombre_Persona { get; set; }

            [Required(ErrorMessage = "Este campo es obligatorio.")]
            [StringLength(50)]
            [Display(Name = "Apellido")]
            public string? Apellido_Persona { get; set; }

            [Required(ErrorMessage = "Este campo es obligatorio.")]
            [Display(Name = "Fecha de nacimiento")]
            [DataType(DataType.Date)]
            public DateTime FechaNacimiento { get; set; }

            [Required(ErrorMessage = "Este campo es obligatorio.")]
            [StringLength(50)]
            [Display(Name = "Telefonmo/Celular")]
            public string Telefono_Persona { get; set; }

            [Required(ErrorMessage = "Este campo es obligatorio.")]
            [StringLength(50)]
            [Display(Name = "Mail")]
            public string Mail_Persona { get; set; }

            [Required(ErrorMessage = "Este campo es obligatorio.")]
            [StringLength(50)]
            [Display(Name = "Domicilio")]
            public string Domicilio_Persona { get; set; }

            [Required(ErrorMessage = "Este campo es obligatorio.")]
            [Display(Name = "Ciudad")]
            public int Id_Ciudad { get; set; }
            public Ciudad? Ciudad { get; set; }

            [Required(ErrorMessage = "Este campo es obligatorio.")]
            [Display(Name = "Sexo")]
            [EnumDataType(typeof(Sexo))]
            public Sexo Sexo { get; set; }
    }

        public enum Sexo
        {
            Masculino = 1,
            Femenino = 2,
            Otro = 3
        }

    

}
