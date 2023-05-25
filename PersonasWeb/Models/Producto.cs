using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CEBodyPlanet.Models
{
    public class Producto
    {

        [Key]
        public int Id_Producto { get; set; }

        [Display(Name = "Nombre Producto")]
        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [StringLength(50, MinimumLength = 5)]
        public string Nombre { get; set; }

        [Display(Name = "Descripción Producto")]
        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [StringLength(50, MinimumLength = 5)]
        public string Descripcion { get; set; }

        [Display(Name = "Precio de Venta #1")]
        [Range(1, 999999), DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        [Required(ErrorMessage = "Este campo es obligatorio.")]
        public decimal PrecioVta1 { get; set; }

        [Display(Name = "Precio de Venta #2")]
        [Range(1, 999999), DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        [Required(ErrorMessage = "Este campo es obligatorio.")]
        public decimal? PrecioVta2 { get; set; }

        [Display(Name = "Presentación")]
        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [StringLength(50)]
        public string Presentacion { get; set; }


        [Display(Name = "Fecha de Vencimiento")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Este campo es obligatorio.")]
        public DateTime FechaVto { get; set; }

        [Display(Name = "Producto Activo")]
        [Required(ErrorMessage = "Este campo es obligatorio.")]
        public bool Activo { get; set; }

        [Display(Name = "Stock Disponible")]
        [Range(1, 99999)]
        [Required(ErrorMessage = "Este campo es obligatorio.")]
        public int Stock { get; set; }

        [Display(Name = "Marca del Producto")]
        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [ForeignKey("id_Marca")]
        public string Marca { get; set; }
        public virtual Marca MarcaProducto { get; set; }

        [Display(Name = "Proveedor Producto")]
        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [ForeignKey("Id_Proveedor")]
        public string Proveedor { get; set; }
        public virtual Proveedor proveedor { get; set; }

        [Display(Name = "Categoria Producto")]
        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [ForeignKey("id_Categoria")]
        public string Categoria { get; set; }
        public virtual Categoria categoria { get; set; }

        [Display(Name = "Tipo de Uso")]
        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [EnumDataType(typeof(Uso))]
        public Uso Uso { get; set; }
    }

    public enum Uso
    {
        Gabinete = 1,
        VtaPublico = 2,
        Otro = 3
    }
}
