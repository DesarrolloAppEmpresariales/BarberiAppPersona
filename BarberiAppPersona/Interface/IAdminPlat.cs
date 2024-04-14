using BarberiAppPersona.Models;

namespace BarberiAppPersona.Interface
{
    public interface IAdminPlat
    {
        public List<AdminPlat> ObtenerListaAdminPlats();
        public AdminPlat ObtenerAdminPlatPorId(int id);
        public void CrearAdminPlat(AdminPlat AdminPlat);
        public void ActualizarAdminPlat(AdminPlat AdminPlat);
        public AdminPlat EliminarAdminPlat(int id);
        public bool ValidarAdminPlat(int id);
    }
}
