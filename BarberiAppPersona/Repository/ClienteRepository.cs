using BarberiAppPersona.Interface;
using BarberiAppPersona.Models;
using Microsoft.EntityFrameworkCore;

namespace BarberiAppPersona.Repository
{
    public class ClienteRepository : ICliente
    {
        readonly DatabaseContext _dbContext = new();

        public ClienteRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Cliente> ObtenerListaClientes()
        {
            try
            {
                return _dbContext.Cliente.ToList();
            }
            catch
            {
                throw;
            }
        }

        public Cliente ObtenerClientePorId(int id)
        {
            try
            {
                Cliente? Cliente = _dbContext.Cliente.Find(id);
                if (Cliente != null)
                {
                    return Cliente;
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
            catch
            {
                throw;
            }
        }

        public void CrearCliente(Cliente Cliente)
        {
            try
            {
                _dbContext.Cliente.Add(Cliente);
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public void ActualizarCliente(Cliente Cliente)
        {
            try
            {
                _dbContext.Entry(Cliente).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public Cliente EliminarCliente(int id)
        {
            try
            {
                Cliente? Cliente = _dbContext.Cliente.Find(id);

                if (Cliente != null)
                {
                    _dbContext.Cliente.Remove(Cliente);
                    _dbContext.SaveChanges();
                    return Cliente;
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
            catch
            {
                throw;
            }
        }

        public bool ValidarCliente(int id)
        {
            return _dbContext.Cliente.Any(e => e.ClienteID == id);
        }
    }
}
