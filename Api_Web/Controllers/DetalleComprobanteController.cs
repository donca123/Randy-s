using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Datos;
using DominioGym;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api_Web.Controllers
{
    [Route("api/Comprobante/{IdComprobante}/DetalleComprobante")]
    [ApiController]
    public class DetalleComprobanteController : ControllerBase
    {
        private readonly GymContext _context;
        public DetalleComprobanteController(GymContext context)
        {
            _context = context;
        }


        [HttpGet]
        public IEnumerable<DetalleComprobante> Getall(int IdComprobante)
        {
            return _context.DetalleComprobante.Where(x => x.IdComprobante == IdComprobante).ToList();
        }
    }
}