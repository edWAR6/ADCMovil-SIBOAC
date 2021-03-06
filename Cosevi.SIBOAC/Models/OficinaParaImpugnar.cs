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

    public partial class OficinaParaImpugnar
    {
        [Required(ErrorMessage = "El c�digo de la oficina es requerido")] //alerta de que el usuario debe llenar el espacio
        [StringLength(2, ErrorMessage = "El c�digo de la oficina no debe ser mayor a 2 caracteres.")]
        [DisplayName("C�digo")] 
        public string Id { get; set; }

        [Required(ErrorMessage = "La descripci�n es obligatoria")] //alerta de que el usuario debe llenar el espacio
        [StringLength(20, ErrorMessage = "La descripci�n de la oficina no debe ser mayor a 20 caracteres.")]
        [DisplayName("Oficina")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "El estado  es requerido")] //alerta de que el usuario debe llenar el espacio
        [StringLength(1, ErrorMessage = "El estado no debe ser mayor a 1 caracter.")]
        [DisplayName("Estado")]
        public string Estado { get; set; }

        [Required(ErrorMessage = "La fecha de inicio es requerida.")] //alerta de que el usuario debe llenar el espacio
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DisplayName("Fecha Inicio")]
        public Nullable<System.DateTime> FechaDeInicio { get; set; }

        [Required(ErrorMessage = "La fecha de Fin es requerida.")] //alerta de que el usuario debe llenar el espacio
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DisplayName("Fecha Fin")]
        public Nullable<System.DateTime> FechaDeFin { get; set; }
    }
}
