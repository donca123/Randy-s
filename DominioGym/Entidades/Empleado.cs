using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DominioGym
{
    public class Empleado : Persona
    {
        [Key]
        public int IdEmpleado { get; set; }

        public int Clave { get; set; }

        [ForeignKey("Cargo")]
        public int IdCargo { get; set; }

        // Objeto que representa la clave externa.
        [ForeignKey("IdCargo")]
        public virtual Cargo Cargo { get; set; }

        public static Empleado NuevoEmpleado(string _nombre, string _paterno, string _materno, string _direccion, int _telefono, bool _estado,
           int _clave, Cargo _cargo)
        {
            return new Empleado()
            {
                Nombres = _nombre
                ,
                ApellidoP = _paterno
                ,
                ApellidoM = _materno
                ,
                Direccion = _direccion
                ,
                Telefono = _telefono
                ,
                Estado = _estado
                ,
                Clave = _clave
                ,
                Cargo = _cargo
                ,
                IdCargo = _cargo.IdCargo
            };
        }

        public void ModificarEmpleado(string _nombre, string _paterno, string _materno, string _direccion, int _telefono, bool _estado,
           int _clave, Cargo _cargo)
        {
            Nombres = _nombre
                ;
            ApellidoP = _paterno
            ;
            ApellidoM = _materno
            ;
            Direccion = _direccion
            ;
            Telefono = _telefono
            ;
            Estado = _estado
            ;
            Clave = _clave
            ;
            Cargo = _cargo
            ;
            IdCargo = _cargo.IdCargo;
        }
    

        public void eliminarEmpleado()
        {
            Estado = false;
        }

        public ICollection<Cliente> listarEmpleado()
        {
            return listarEmpleado();
        }
    }
}
