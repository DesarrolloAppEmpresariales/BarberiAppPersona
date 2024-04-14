using BarberiAppPersona.Interface;
using BarberiAppPersona.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BarberiAppPersona.Controllers
{
    [Authorize]
    [Route("api/cliente")]
    [ApiController]
    public class ClienteController : Controller
    {
        private readonly ICliente _ICliente;

        public ClienteController(ICliente ICliente)
        {
            _ICliente = ICliente;
        }
        //Roles (1 'SU') (2 'Admin') (3 'Barbero') (4 'Cliente')     
        // GET: api/employee> 
        [HttpGet]
        [Authorize(Roles = "1, 2")]
        public async Task<ActionResult<IEnumerable<Cliente>>> Get()
        {
            return await Task.FromResult(_ICliente.ObtenerListaClientes());
        }

        // GET api/employee/5
        [HttpGet("{id}")]
        [Authorize(Roles = "1, 2")]
        public async Task<ActionResult<Cliente>> Get(int id)
        {
            var employees = await Task.FromResult(_ICliente.ObtenerClientePorId(id));
            if (employees == null)
            {
                return NotFound();
            }
            return employees;
        }

        // POST api/employee
        [HttpPost]
        public async Task<ActionResult<Cliente>> Post(Cliente Cliente)
        {
            _ICliente.CrearCliente(Cliente);
            return await Task.FromResult(Cliente);
        }

        // PUT api/employee/5
        [HttpPut("{id}")]
        [Authorize(Roles = "1, 2")]
        public async Task<ActionResult<Cliente>> Put(int id, Cliente Cliente)
        {
            if (id != Cliente.ClienteID)
            {
                return BadRequest();
            }
            try
            {
                _ICliente.ActualizarCliente(Cliente);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return await Task.FromResult(Cliente);
        }

        // DELETE api/employee/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "1, 2")]
        public async Task<ActionResult<Cliente>> Delete(int id)
        {
            var Cliente = _ICliente.EliminarCliente(id);
            return await Task.FromResult(Cliente);
        }

        private bool EmployeeExists(int id)
        {
            return _ICliente.ValidarCliente(id);
        }
    }
}
