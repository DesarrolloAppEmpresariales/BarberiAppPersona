using BarberiAppPersona.Models;

namespace BarberiAppPersona.Interface
{
    public interface IAdminNeg
    {
        public List<AdminNeg> ObtenerListaAdminNegs();
        public AdminNeg ObtenerAdminNegPorId(int id);
        public void CrearAdminNeg(AdminNeg AdminNeg);
        public void ActualizarAdminNeg(AdminNeg AdminNeg);
        public AdminNeg EliminarAdminNeg(int id);
        public bool ValidarAdminNeg(int id);
    }
}
