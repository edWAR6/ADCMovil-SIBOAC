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

    public partial class OpcionFormularioPorArticulo
    {
        [DisplayName("Codigo")]
        [StringLength(6, ErrorMessage = "El codigo no debe ser mayor a 6 caracter.")]
        [Required(ErrorMessage = "El codigo es obligatorio")]
        public string Id { get; set; }

        [DisplayName("Conducta")]
        [StringLength(2, ErrorMessage = "La conducta no debe ser mayor a 2 caracter.")]
        [Required(ErrorMessage = "La conducta es obligatoria")]
        public string Conducta { get; set; }

        [DisplayName("Fecha de inicio")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "La fecha de inicio es obligatoria")]
        public System.DateTime FechaDeInicio { get; set; }

        [DisplayName("Fecha de fin")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "La fecha de fin es obligatoria")]
        public System.DateTime FechaDeFin { get; set; }

        [DisplayName("C�digo de formulario")]
        [Required(ErrorMessage = "El c�digo es obligatorio")]
        public int CodigoOpcionFormulario { get; set; }

        [DisplayName("Estado")]
        [StringLength(1, ErrorMessage = "El estado no debe ser mayor a 1 caracter.")]
        [Required(ErrorMessage = "El estado es obligatorio")]
        public string Estado { get; set; }

        public string DescripcionCodigoOpcionFormulario
        { get; set; }

        public string DescripcionCodigoCatArticulo
        { get; set; }
    }
}
