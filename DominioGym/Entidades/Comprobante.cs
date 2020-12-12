using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace DominioGym
{
    public class Comprobante
    {

        [Key]
        public int IdComprobante { get; set; }


        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fecha")]
        public DateTime FechaEmision { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Serie { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Numero { get; set; }

        public decimal Total { get; set; }
        public decimal Igv { get; set; }
        public decimal Subtotal { get; set; }

        public bool Estado { get; set; }

        public ICollection<DetalleComprobante> Detalle { get; set; }


        // Clave Externa
        [ForeignKey("Cliente")]
        public int IdCliente { get; set; }

        // Objeto que representa la clave externa.
        [ForeignKey("IdCliente")]
        public virtual Cliente Cliente { get; set; }

        // Clave Externa
        [ForeignKey("Empleado")]
        public int IdEmpleado { get; set; }

        // Objeto que representa la clave externa.
        [ForeignKey("IdEmpleado")]
        public virtual Empleado Empleado { get; set; }



        public static Comprobante Nuevo(string _serie, string _numero, DateTime _fecha, Cliente _cliente, Empleado _vendedor, decimal _total)
        {
            return new Comprobante()
            {
                Serie = _serie
                ,
                Numero = _numero
                ,
                FechaEmision = _fecha
                ,
                Cliente = _cliente
                ,
                IdCliente = _cliente.IdCliente
                ,
                Empleado = _vendedor
                ,
                IdEmpleado = _vendedor.IdEmpleado
                ,
                Total = _total


            };

        }

        public void AgregarDetalle(Comprobante _comprobante, Producto _producto, int _cantidad)
        {
           

            Detalle.Add(DetalleComprobante.Registrar(_comprobante, _producto, _cantidad));
        }

        public void ModificarDetalle(DetalleComprobante _item, Producto _producto, int _cantidad)
        {
            _item.Modificar(_producto, _cantidad);
        }

        public void EliminarDetalle(DetalleComprobante _item)
        {
            Detalle.Where(p => p.IdProducto == _item.IdProducto);
        }

        public void Emitir(decimal _igv)
        {
            Detalle.Sum(p => p.Subtotal);
            Igv = Subtotal * _igv;
            Total = Subtotal + Igv;
            Estado = true;

        }
    }
}
