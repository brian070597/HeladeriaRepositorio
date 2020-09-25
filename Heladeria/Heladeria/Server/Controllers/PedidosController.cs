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
    public class PedidosController : ControllerBase
    {
        private readonly HeladeriaContext context;
        public PedidosController(HeladeriaContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<Pedido>>> Get()
        {
            try
            {
                return await context.Pedidos.ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        [HttpGet("{id}", Name = "obtenerPedido")]
        public async Task<ActionResult<Pedido>> Get(int id)
        {
            try
            {
                return await context.Pedidos.FirstOrDefaultAsync(x => x.Idpedido == id);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        [HttpPost]
        public async Task<ActionResult> Post(Pedido pedido)
        {
            try
            {
                context.Add(pedido);
                await context.SaveChangesAsync();
                return new CreatedAtRouteResult("obtenerPedido", new { Id = pedido.Idpedido, pedido });
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPut]
        public async Task<ActionResult> Put(Pedido pedido)
        {
            try
            {
                context.Entry(pedido).State = EntityState.Modified;
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
                var pedido = new Pedido { Idpedido = id };
                context.Remove(pedido);
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
