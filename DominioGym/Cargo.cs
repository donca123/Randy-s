using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DominioGym
{
    public class Cargo
    {

        [Key]
        public int IdCargo { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string NombreCargo { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Descripcion { get; set; }







        public static Cargo nuevoCargo(string _nombreCargo, string _descripcion)
        {

            return new Cargo
            {
                NombreCargo = _nombreCargo,
                Descripcion = _descripcion
            };

        }


        public void modificarCargo(string _descripcion, string _nombreCargo)
        {
            NombreCargo = _nombreCargo;
            Descripcion = _descripcion;
        }

        public ICollection<Cargo> listarCargo()
        {
            return listarCargo();
        }

    }
}
