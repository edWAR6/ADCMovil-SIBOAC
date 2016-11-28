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

    public partial class DetallePorTipoSenial
    {
        [DisplayName("Codigo del tipo de se�al")]
        [StringLength(2, ErrorMessage = "El codigo no debe ser mayor a 2 caracteres.")]
        [Required(ErrorMessage = "El codigo es obligatorio")]
        public string CodigoTipoSenial { get; set; }

        [DisplayName("Codigo del detalle del tipo de se�al")]
        [StringLength(2, ErrorMessage = "El codigo no debe ser mayor a 2 caracteres.")]
        [Required(ErrorMessage = "El codigo es obligatorio")]
        public string Id { get; set; }

        [DisplayName("Descripci�n")]
        [Required(ErrorMessage = "La descripci�n es obligatoria")]
        [StringLength(50, ErrorMessage = "La descripci�n no debe ser mayor a 50 caracteres")]
        public string Descripcion { get; set; }

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

        public string DescripcionCodigoTipoSenial
        {
            get
            {
                string Descripcion = "";
                PC_HH_AndroidEntities db = new PC_HH_AndroidEntities();
                {
                    TipoDeSenalExistente tipoDeSenalExistente = db.TIPOSE�ALEXISTE.Find(CodigoTipoSenial);
                    if (tipoDeSenalExistente.Id == CodigoTipoSenial)
                    {
                        return Descripcion = tipoDeSenalExistente.Descripcion;
                    }
                }
                return Descripcion;
            }
        }

    }
}
