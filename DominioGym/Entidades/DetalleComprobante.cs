using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DominioGym
{
    public  class DetalleComprobante
    {
        [Key]
        public int IdDetalle { get; set; }
        public int Cantidad{get; set;}
        public decimal Subtotal { get; set; }

        // Clave Externa
        [ForeignKey("Comprobante")]
        public int IdComprobante { get; set; }

        // Objeto que representa la clave externa.
        [ForeignKey("IdComprobante")]
        public virtual Comprobante Comprobante { get; set; }

        // Clave Externa
        [ForeignKey("Producto")]
        public int IdProducto { get; set; }

        // Objeto que representa la clave externa.
        [ForeignKey("IdProducto")]
        public virtual Producto Producto { get; set; }


        public decimal Precio { get; set; }

        public static DetalleComprobante Registrar(Comprobante _comprobante, Producto _item, int _cantidad)
        {
            return new DetalleComprobante()
            {
                Comprobante = _comprobante
                ,
                IdComprobante = _comprobante.IdComprobante
                ,
                Producto = _item
                ,
                IdProducto = _item.IdProducto
                ,
                Cantidad = _cantidad
            };

        }
        public void Modificar(Producto _iditem, int _cantidad)
        {


        }


    }
}
