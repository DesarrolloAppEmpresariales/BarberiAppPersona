using BarberiAppPersona.Interface;
using BarberiAppPersona.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BarberiAppPersona.Controllers
{
    [Authorize]
    [Route("api/AdminNeg")]
    [ApiController]
    public class AdminNegController : ControllerBase
    {
        private readonly IAdminNeg _IAdminNeg;

        public AdminNegController(IAdminNeg IAdminNeg)
        {
            _IAdminNeg = IAdminNeg;
        }
        //Roles (1 'SU') (2 'Admin') (3 'Barbero') (4 'Cliente')     
        // GET: api/employee> 
        [HttpGet]
        [Authorize(Roles = "1, 2")]
        public async Task<ActionResult<IEnumerable<AdminNeg>>> Get()
        {
            return await Task.FromResult(_IAdminNeg.ObtenerListaAdminNegs());
        }

        // GET api/employee/5
        [HttpGet("{id}")]
        [Authorize(Roles = "1, 2")]
        public async Task<ActionResult<AdminNeg>> Get(int id)
        {
            var employees = await Task.FromResult(_IAdminNeg.ObtenerAdminNegPorId(id));
            if (employees == null)
            {
                return NotFound();
            }
            return employees;
        }

        // POST api/employee
        [HttpPost]
        public async Task<ActionResult<AdminNeg>> Post(AdminNeg AdminNeg)
        {
            _IAdminNeg.CrearAdminNeg(AdminNeg);
            return await Task.FromResult(AdminNeg);
        }

        // PUT api/employee/5
        [HttpPut("{id}")]
        [Authorize(Roles = "1, 2")]
        public async Task<ActionResult<AdminNeg>> Put(int id, AdminNeg AdminNeg)
        {
            if (id != AdminNeg.AdminNegID)
            {
                return BadRequest();
            }
            try
            {
                _IAdminNeg.ActualizarAdminNeg(AdminNeg);
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
            return await Task.FromResult(AdminNeg);
        }

        // DELETE api/employee/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "1, 2")]
        public async Task<ActionResult<AdminNeg>> Delete(int id)
        {
            var AdminNeg = _IAdminNeg.EliminarAdminNeg(id);
            return await Task.FromResult(AdminNeg);
        }

        private bool EmployeeExists(int id)
        {
            return _IAdminNeg.ValidarAdminNeg(id);
        }
    }
}
