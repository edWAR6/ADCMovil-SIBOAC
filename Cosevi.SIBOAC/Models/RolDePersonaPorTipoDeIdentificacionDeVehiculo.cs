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
    
    public partial class RolDePersonaPorTipoDeIdentificacionDeVehiculo
    {
        public string CodigoDeRol { get; set; }
        public string CodigoDeIdentificacionVehiculo { get; set; }
        public string Estado { get; set; }
        public Nullable<System.DateTime> FechaDeInicio { get; set; }
        public Nullable<System.DateTime> FechaDeFin { get; set; }

        public string  DescripcionRol
        {
            get
            {
                string Descripcion = "";
                PC_HH_AndroidEntities db = new PC_HH_AndroidEntities();
                if (CodigoDeRol != "")
                {
                    RolPorPersona rolPersona = db.ROLPERSONA.Find(CodigoDeRol);
                    if (rolPersona.Id == CodigoDeRol)
                    {
                        return Descripcion = rolPersona.Descripcion;
                    }
                }
                return Descripcion;                     
            }
        }

        public string DescripcionTipoVehiculo
        {
            get
            {
                string Descripcion = "";
                PC_HH_AndroidEntities db = new PC_HH_AndroidEntities();
                if (CodigoDeIdentificacionVehiculo != "")
                {
                    TipoDeVehiculo TipoVeh = db.TIPOVEH.Find(Convert.ToInt32(CodigoDeIdentificacionVehiculo.Trim()));
                    if (TipoVeh.Id.ToString() == CodigoDeIdentificacionVehiculo.Trim())
                    {
                        return Descripcion = TipoVeh.Descripcion;
                    }
                }
                return Descripcion;
            }
        }
    }
}
