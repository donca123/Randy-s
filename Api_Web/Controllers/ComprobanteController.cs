using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Datos;
using DominioGym;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api_Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComprobanteController : ControllerBase
    {
        private readonly GymContext _context;

        public ComprobanteController(GymContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Comprobante> Get()
        {
            return _context.Comprobante.Include(x =>x.Detalle).ToList();
        }

        [HttpGet("{id}", Name = "ultimoComprobante")]
        public IActionResult GetById(int id)
        {
            var comprobante = _context.Comprobante.Include(x => x.Detalle).FirstOrDefault(x => x.IdComprobante == id);

            if (comprobante == null)
            {
                return NotFound();
            }
            return Ok(comprobante);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Comprobante comprobante)
        {
            if (ModelState.IsValid)
            {
                _context.Comprobante.Add(comprobante);
                _context.SaveChanges();
                return new CreatedAtRouteResult("ultimoComprobante", new { id = comprobante.IdComprobante }, comprobante);
            }
            return BadRequest(ModelState);
        }
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] Comprobante comprobante, int id)
        {
            if (comprobante.IdComprobante != id)
            {
                return BadRequest();
            }
            _context.Entry(comprobante).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok();
        }
        
    }
}