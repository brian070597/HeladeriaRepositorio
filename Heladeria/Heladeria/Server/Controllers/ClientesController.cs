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
    public class ClientesController : ControllerBase
    {
        private readonly HeladeriaContext context;
        public ClientesController(HeladeriaContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<Cliente>>> Get()
        {
            try
            {
                return await context.Clientes.ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        [HttpGet("{id}", Name = "obtenerClientes")]
        public async Task<ActionResult<Cliente>> Get(int id)
        {
            try
            {
                return await context.Clientes.FirstOrDefaultAsync(x => x.Idcliente == id);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        [HttpPost]
        public async Task<ActionResult> Post(Cliente cliente)
        {
            try
            {
                context.Add(cliente);
                await context.SaveChangesAsync();
                return new CreatedAtRouteResult("obtenerProveedor", new { Id = cliente.Idcliente, cliente });
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPut]
        public async Task<ActionResult> Put(Cliente cliente)
        {
            try
            {
                context.Entry(cliente).State = EntityState.Modified;
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
                var cliente = new Cliente { Idcliente = id };
                context.Remove(cliente);
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
