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
    
    public partial class PERSONA
    {
        public string tipo_ide { get; set; }
        public string identificacion { get; set; }
        public string tipo_lic { get; set; }
        public string apellido1 { get; set; }
        public string apellido2 { get; set; }
        public string nombre { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }
        public Nullable<System.DateTime> FechaNacimiento { get; set; }
        public string Inscrito { get; set; }
        public string sexo { get; set; }
        public string esmenor { get; set; }
        public Nullable<int> edad { get; set; }
        public string estcivil { get; set; }
        public string ocupacion { get; set; }
        public Nullable<int> cod_provincia { get; set; }
        public Nullable<int> cod_canton { get; set; }
        public Nullable<int> cod_distrito { get; set; }
        public Nullable<bool> direccionNoSuministrada { get; set; }
        public string senasDireccion { get; set; }
        public decimal NumeroBoleta { get; set; }
        public int Serie { get; set; }
        public Nullable<bool> fechaNacimientoNoSuministrada { get; set; }
        public Nullable<bool> codigo_horaslaborales { get; set; }
        public string fax { get; set; }
        public string email { get; set; }
        public string clase_vehiculo_colision { get; set; }
        public string codigo_vehiculo_colision { get; set; }
        public string placa_vehiculo_colision { get; set; }
    }
}
