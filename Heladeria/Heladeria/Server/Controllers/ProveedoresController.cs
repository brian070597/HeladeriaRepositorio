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
    public class ProveedoresController : ControllerBase
    {
        
        private readonly HeladeriaContext context;
        public ProveedoresController(HeladeriaContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<Proveedore>>> Get()
        {
            try
            {
                return await context.Proveedores.ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        [HttpGet("{id}", Name = "obtenerProveedor")]
        public async Task<ActionResult<Proveedore>> Get(int id)
        {
            try
            {
                return await context.Proveedores.FirstOrDefaultAsync(x => x.Idproveedor == id);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        [HttpPost]
        public async Task<ActionResult> Post(Proveedore proveedor)
        {
            try
            {
                context.Add(proveedor);
                await context.SaveChangesAsync();
                return new CreatedAtRouteResult("obtenerProveedor", new { Id = proveedor.Idproveedor, proveedor });
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPut]
        public async Task<ActionResult> Put(Proveedore proveedor)
        {
            try
            {
                context.Entry(proveedor).State = EntityState.Modified;
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
                var proveedor = new Proveedore { Idproveedor = id };
                context.Remove(proveedor);
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
