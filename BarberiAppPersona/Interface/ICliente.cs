using BarberiAppPersona.Models;

namespace BarberiAppPersona.Interface
{
    public interface ICliente
    {
        public List<Cliente> ObtenerListaClientes();
        public Cliente ObtenerClientePorId(int id);
        public void CrearCliente(Cliente Cliente);
        public void ActualizarCliente(Cliente Cliente);
        public Cliente EliminarCliente(int id);
        public bool ValidarCliente(int id);
    }
}
