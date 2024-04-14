using BarberiAppPersona.Interface;
using BarberiAppPersona.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BarberiAppPersona.Controllers
{
    [Authorize]
    [Route("api/AdminPlat")]
    [ApiController]
    public class AdminPlatController : ControllerBase
    {
        private readonly IAdminPlat _IAdminPlat;

        public AdminPlatController(IAdminPlat IAdminPlat)
        {
            _IAdminPlat = IAdminPlat;
        }
        //Roles (1 'SU') (2 'Admin') (3 'Barbero') (4 'Cliente')     
        // GET: api/employee> 
        [HttpGet]
        [Authorize(Roles = "1, 2")]
        public async Task<ActionResult<IEnumerable<AdminPlat>>> Get()
        {
            return await Task.FromResult(_IAdminPlat.ObtenerListaAdminPlats());
        }

        // GET api/employee/5
        [HttpGet("{id}")]
        [Authorize(Roles = "1, 2")]
        public async Task<ActionResult<AdminPlat>> Get(int id)
        {
            var employees = await Task.FromResult(_IAdminPlat.ObtenerAdminPlatPorId(id));
            if (employees == null)
            {
                return NotFound();
            }
            return employees;
        }

        // POST api/employee
        [HttpPost]
        public async Task<ActionResult<AdminPlat>> Post(AdminPlat AdminPlat)
        {
            _IAdminPlat.CrearAdminPlat(AdminPlat);
            return await Task.FromResult(AdminPlat);
        }

        // PUT api/employee/5
        [HttpPut("{id}")]
        [Authorize(Roles = "1, 2")]
        public async Task<ActionResult<AdminPlat>> Put(int id, AdminPlat AdminPlat)
        {
            if (id != AdminPlat.AdminPlatID)
            {
                return BadRequest();
            }
            try
            {
                _IAdminPlat.ActualizarAdminPlat(AdminPlat);
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
            return await Task.FromResult(AdminPlat);
        }

        // DELETE api/employee/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "1, 2")]
        public async Task<ActionResult<AdminPlat>> Delete(int id)
        {
            var AdminPlat = _IAdminPlat.EliminarAdminPlat(id);
            return await Task.FromResult(AdminPlat);
        }

        private bool EmployeeExists(int id)
        {
            return _IAdminPlat.ValidarAdminPlat(id);
        }
    }
}
