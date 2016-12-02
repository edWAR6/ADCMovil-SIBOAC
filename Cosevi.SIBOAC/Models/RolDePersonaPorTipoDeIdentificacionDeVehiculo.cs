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

    public partial class RolDePersonaPorTipoDeIdentificacionDeVehiculo
    {
        [DisplayName("C�digo del rol de la persona")]
        [StringLength(2, ErrorMessage = "El c�digo no debe ser mayor a 2 caracteres")]
        [Required(ErrorMessage = "El codigo es obligatorio")]
        public string CodigoDeRol { get; set; }

        [DisplayName("C�digo de identificaci�n del vehiculo")]
        [StringLength(2, ErrorMessage = "El c�digo no debe ser mayor a 2 caracteres")]
        [Required(ErrorMessage = "El codigo es obligatorio")]
        public string CodigoDeIdentificacionVehiculo { get; set; }

        [DisplayName("Estado")]
        [StringLength(1, ErrorMessage = "El estado no debe ser mayor a 1 caracter")]
        [Required(ErrorMessage = "El estado es obligatorio")]
        public string Estado { get; set; }

        [DisplayName("Fecha de Inicio")]
        [Required(ErrorMessage = "La fecha de inicio es obligatoria")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> FechaDeInicio { get; set; }

        [DisplayName("Fecha de Fin")]
        [Required(ErrorMessage = "La fecha de fin es obligatoria")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> FechaDeFin { get; set; }

        public string  DescripcionRol
        { get; set; }

        public string DescripcionTipoVehiculo

        { get; set; }
    }
}
