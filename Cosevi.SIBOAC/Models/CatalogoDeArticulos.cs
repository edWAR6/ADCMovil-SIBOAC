//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Cosevi.SIBOAC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public partial class CatalogoDeArticulos
    {
        [DisplayName("C�digo")]
        [Required(ErrorMessage = "El c�digo es obligatorio")]
        [StringLength(6, ErrorMessage = "El codigo no debe ser mayor a 6 caracteres.")]
        public string Id { get; set; }

        [DisplayName("Conducta")]
        [Required(ErrorMessage = "La conducta es obligatoria")]
        [StringLength(2, ErrorMessage = "La conducta no debe ser mayor a 2 caracteres.")]
        public string Conducta { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DisplayName("Fecha de inicio")]
        [Required(ErrorMessage = "La fecha de inicio es obligatoria")]
        public System.DateTime FechaDeInicio { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DisplayName("Fecha de fin")]
        [Required(ErrorMessage = "La fecha de fin es obligatoria")]
        public System.DateTime FechaDeFin { get; set; }

        [DisplayName("Descripci�n")]
        [StringLength(255, ErrorMessage = "La descripci�n no debe ser mayor a 255 caracteres")]
        [Required(ErrorMessage = "La descripci�n es obligatoria")]
        public string Descripcion { get; set; }

        [DisplayName("Monto de la multa")]
        [Required(ErrorMessage = "El monto es obligatorio")]
        //[Range(0.01, 999999999.99, ErrorMessage = "El precio solo puede tener 2 decimales 0.00")]
        //[DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
        [RegularExpression(@"^\$?\-?([1-9]{1}[0-9]{0,2}(\,\d{3})*(\.\d{0,2})?|[1-9]{1}\d{0,}(\.\d{0,2})?|0(\.\d{0,2})?|(\.\d{1,2}))$|^\-?\$?([1-9]{1}\d{0,2}(\,\d{3})*(\.\d{0,2})?|[1-9]{1}\d{0,}(\.\d{0,2})?|0(\.\d{0,2})?|(\.\d{1,2}))$|^\(\$?([1-9]{1}\d{0,2}(\,\d{3})*(\.\d{0,2})?|[1-9]{1}\d{0,}(\.\d{0,2})?|0(\.\d{0,2})?|(\.\d{1,2}))\)$", ErrorMessage = "El precio solo puede tener 2 decimales 0.00")]
        //[Range(0, 9999999999999999.99)]
        [DataType(DataType.Currency, ErrorMessage ="El valor ingresado no es un monto valido")]
        public decimal Multa { get; set; }

        [StringLength(1, ErrorMessage = "El estado no debe ser mayor a 1 caracter.")]
        [DisplayName("Estado")]
        [Required(ErrorMessage = "El estado es obligatorio")]
        public string Estado { get; set; }

        [DisplayName("Puntos")]
        [Required(ErrorMessage = "Los puntos son obligatorios")]
        public int Puntos { get; set; }

        [DisplayName("Totalidad")]
        [Required(ErrorMessage = "La totalidad es obligatoria")]
        public int Totalidad { get; set; }
    }
}
