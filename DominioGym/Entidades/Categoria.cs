using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DominioGym
{
    public class Categoria
    {

        [Key]
        public int IdCategoria { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string NombreCategoria { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string DescripcionCategoria { get; set; }

        


        public static Categoria nuevaCategoria(string _descripcion, string _nombreC)
        {

            return new Categoria
            {
                NombreCategoria = _nombreC,
                DescripcionCategoria = _descripcion
               

            };

        }
        public void modificarCategoria(string _nombre, string _descripcion)
        {
            NombreCategoria = _nombre;
            DescripcionCategoria = _descripcion;
            

        }


       
    }


}
