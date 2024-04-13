﻿using BarberiApp.WebApi.Interface;
using BarberiApp.WebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BarberiApp.WebApi.Controllers
{
    [Authorize]
    [Route("api/empleado")]
    [ApiController]
    public class EmpleadoController : ControllerBase
    {
        private readonly IEmpleado _IEmpleado;

        public EmpleadoController(IEmpleado IEmpleado)
        {
            _IEmpleado = IEmpleado;
        }
        //Roles (1 'SU') (2 'Admin') (3 'Barbero') (4 'Cliente')     
        // GET: api/employee> 
        [HttpGet]
        [Authorize(Roles = "1, 2")]
        public async Task<ActionResult<IEnumerable<Empleado>>> Get()
        {
            return await Task.FromResult(_IEmpleado.ObtenerListaEmpleados());
        }

        // GET api/employee/5
        [HttpGet("{id}")]
        [Authorize(Roles = "1, 2")]
        public async Task<ActionResult<Empleado>> Get(int id)
        {
            var employees = await Task.FromResult(_IEmpleado.ObtenerEmpleadoPorId(id));
            if (employees == null)
            {
                return NotFound();
            }
            return employees;
        }

        // POST api/employee
        [HttpPost]
        public async Task<ActionResult<Empleado>> Post(Empleado empleado)
        {
            _IEmpleado.CrearEmpleado(empleado);
            return await Task.FromResult(empleado);
        }

        // PUT api/employee/5
        [HttpPut("{id}")]
        [Authorize(Roles = "1, 2")]
        public async Task<ActionResult<Empleado>> Put(int id, Empleado empleado)
        {
            if (id != empleado.EmpleadoID)
            {
                return BadRequest();
            }
            try
            {
                _IEmpleado.ActualizarEmpleado(empleado);
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
            return await Task.FromResult(empleado);
        }

        // DELETE api/employee/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "1, 2")]
        public async Task<ActionResult<Empleado>> Delete(int id)
        {
            var empleado = _IEmpleado.EliminarEmpleado(id);
            return await Task.FromResult(empleado);
        }

        private bool EmployeeExists(int id)
        {
            return _IEmpleado.ValidarEmpleado(id);
        }
    }
}