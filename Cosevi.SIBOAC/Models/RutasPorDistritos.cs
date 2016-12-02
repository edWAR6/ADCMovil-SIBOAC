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

    public partial class RutasPorDistritos
    {
        [DisplayName("Distrito")]
        [Required(ErrorMessage = "El c�digo es obligatorio")]
        public int CodigoDistrito { get; set; }

        [DisplayName("Ruta")]
        [Required(ErrorMessage = "El c�digo es obligatorio")]
        public int CodigoRuta { get; set; }

        [DisplayName("Kilometros")]
        [Required(ErrorMessage = "Los kilometros son obligatorios")]
        public int Km { get; set; }

        [DisplayName("Estado")]
        [StringLength(1, ErrorMessage = "El estado no debe ser mayor a 1 caracter.")]
        [Required(ErrorMessage = "El estado es obligatorio")]
        public string Estado { get; set; }

        [DisplayName("Fecha de inicio")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "La fecha de inicio es obligatoria")]
        public Nullable<System.DateTime> FechaDeInicio { get; set; }

        [DisplayName("Fecha de fin")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "La fecha de fin es obligatoria")]
        public Nullable<System.DateTime> FechaDeFin { get; set; }

        [DisplayName("Descripci�n")]
        public string DescripcionDistrito
        {
            get; set;
        }
        [DisplayName("Descripci�n")]
        public string DescripcionRuta
        {
            get;set;
        }

    }
}
