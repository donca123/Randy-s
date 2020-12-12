using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DominioGym
{
    public class Persona
    {

        [Column(TypeName = "nvarchar(100)")]
        public string Nombres { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string ApellidoP { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string ApellidoM { get; set; }
        public int Telefono { get; set; }

        [Column(TypeName = "nvarchar(100)")]
       public string Direccion { get; set; }
        public int Dni { get; set; }
        public bool Estado { get; set; }

    }
}
