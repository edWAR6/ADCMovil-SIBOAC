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
    
    public partial class RolPorPersonaOpcionFormulario
    {
        public int CodigoRolPersona { get; set; }
        public int CodigoOpcionFormulario { get; set; }
        public string Estado { get; set; }
        public System.DateTime FechaDeInicio { get; set; }
        public System.DateTime FechaDeFin { get; set; }

        public string DescripcionCodigoOpcionFormulario
        {
            get
            {
                string Descripcion = "";
                PC_HH_AndroidEntities db = new PC_HH_AndroidEntities();
                {
                    OpcionDeFormulario opcionDeFormulario = db.OPCIONFORMULARIO.Find(CodigoOpcionFormulario);
                    if (opcionDeFormulario.Id == CodigoOpcionFormulario)
                    {
                        return Descripcion = opcionDeFormulario.Descripcion;
                    }
                }
                return Descripcion;
            }
        }


        public string DescripcionCodigoRolPersona
        {
            get
            {
                string Descripcion = "";
                PC_HH_AndroidEntities db = new PC_HH_AndroidEntities();
                {
                    RolPorPersona rolPorPersona = db.ROLPERSONA.Find(CodigoRolPersona.ToString());
                    if (rolPorPersona.Id.Trim() == CodigoRolPersona.ToString().Trim())
                    {
                        return Descripcion = rolPorPersona.Descripcion;
                    }
                }
                return Descripcion;
            }
        }

    }




}
