using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Heladeria.Shared.Modelos;

namespace Heladeria.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VentasController : ControllerBase
    {
        private readonly HeladeriaContext context;
        public VentasController(HeladeriaContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<Venta>>> Get()
        {
            try
            {
                return await context.Ventas.ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        [HttpGet("{id}", Name = "obtenerVenta")]
        public async Task<ActionResult<Venta>> Get(int id)
        {
            try
            {
                return await context.Ventas.FirstOrDefaultAsync(x => x.Idventa == id);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        [HttpPost]
        public async Task<ActionResult> Post(Venta venta)
        {
            try
            {
                context.Add(venta);
                await context.SaveChangesAsync();
                return new CreatedAtRouteResult("obtenerVenta", new { Id = venta.Idventa, venta });
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPut]
        public async Task<ActionResult> Put(Venta venta)
        {
            try
            {
                context.Entry(venta).State = EntityState.Modified;
                await context.SaveChangesAsync();
                return NoContent();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        [HttpDelete("{id}")]

        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var venta = new Venta { Idventa = id };
                context.Remove(venta);
                await context.SaveChangesAsync();
                return NoContent();
            }

            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
