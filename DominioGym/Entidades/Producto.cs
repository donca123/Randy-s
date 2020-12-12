using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DominioGym
{
    public class Producto
    {
        
        [Key]
        public int IdProducto { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string NombreProducto { get; set; }

        public int Cantidad { get; set; }

        public double PrecioVenta { get; set; }
        public bool Estado { get; set; }
        
        
        // Clave Externa
        [ForeignKey("Categoria")]
        public int IdCategoria { get; set; }

        // Objeto que representa la clave externa.
        [ForeignKey("IdCategoria")]
        public virtual Categoria Categoria { get; set; }

        public static Producto Nuevo(string _nombre, double _precioUnitario, int _cantidad, Categoria _tipoProducto)
        {
            return new Producto()
            {
                NombreProducto = _nombre
                ,
                PrecioVenta = _precioUnitario
                ,
                Cantidad = _cantidad
                ,
                Categoria = _tipoProducto
                ,
                IdCategoria = _tipoProducto.IdCategoria
                ,
                Estado=true


            };

        }

        public void ModificarProducto(string _nombre, double _precioUnitario, int _cantidad, Categoria _tipoProducto)
        {
            NombreProducto = _nombre
                ;
            PrecioVenta = _precioUnitario
            ;
            Cantidad = _cantidad
            ;
            Categoria = _tipoProducto
            ;
            IdCategoria = _tipoProducto.IdCategoria
            ;


        }

        public void cambiarEstado()
        {
            Estado = false;
        }

        public ICollection<Producto> ListarProducto()
        {
            return ListarProducto();
        }

    }
}
