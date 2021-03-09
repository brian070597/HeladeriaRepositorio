using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Heladeria.Shared.Modelos;
using System.Security.Cryptography;
using System.Text;

namespace Heladeria.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly HeladeriaContext context;
        public UsuariosController(HeladeriaContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<Usuario>>> Get()
        {
            try
            {
                return await context.Usuarios.ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        [HttpGet("{id}", Name = "obtenerUsuario")]
        public async Task<ActionResult<Usuario>> Get(int id)
        {
            try
            {
                return await context.Usuarios.FirstOrDefaultAsync(x => x.Idusuario == id);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        [HttpPost]
        public async Task<ActionResult> Post(Usuario usuario)
        {
            try
            {
                context.Add(usuario);
                await context.SaveChangesAsync();
                return new CreatedAtRouteResult("obtenerUsuario", new { Id = usuario.Idusuario, usuario });
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPut]
        public async Task<ActionResult> Put(Usuario usuario)
        {
            try
            {
                context.Entry(usuario).State = EntityState.Modified;
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
                var usuario = new Usuario { Idusuario = id };
                context.Remove(usuario);
                await context.SaveChangesAsync();
                return NoContent();
            }

            catch (Exception ex)
            {
                throw ex;
            }

        }
        [HttpGet("{id}", Name = "logueoUsuario")]
        public async Task<ActionResult<Usuario>> Get(string nombre, string password )
        {
            try
            {
                var pass = HashearPassword(password);

                return await context.Usuarios.FirstOrDefaultAsync(x => x.NombreUsuario == nombre && x.Contraseña == pass );
                
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public static byte[] HashearPassword(string password) { return SHA1.Create().ComputeHash(Encoding.UTF8.GetBytes(password)); }
    }
}
