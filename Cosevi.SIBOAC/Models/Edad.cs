//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Cosevi.SIBOAC.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Edad
    {
        public System.DateTime FechaMinNacimiento { get; set; }
        public System.DateTime FechaMaxNacimiento { get; set; }
        public System.DateTime FechaPorDefecto { get; set; }
        public string Estado { get; set; }
        public Nullable<System.DateTime> FechaDeInicio { get; set; }
        public Nullable<System.DateTime> FechaDeFin { get; set; }
    }
}