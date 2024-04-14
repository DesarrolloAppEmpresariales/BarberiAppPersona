using BarberiAppPersona.Interface;
using BarberiAppPersona.Models;
using Microsoft.EntityFrameworkCore;

namespace BarberiAppPersona.Repository
{
    public class AdminPlatRepository : IAdminPlat
    {
        readonly DatabaseContext _dbContext = new();

        public AdminPlatRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<AdminPlat> ObtenerListaAdminPlats()
        {
            try
            {
                return _dbContext.AdminPlat.ToList();
            }
            catch
            {
                throw;
            }
        }

        public AdminPlat ObtenerAdminPlatPorId(int id)
        {
            try
            {
                AdminPlat? AdminPlat = _dbContext.AdminPlat.Find(id);
                if (AdminPlat != null)
                {
                    return AdminPlat;
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

        public void CrearAdminPlat(AdminPlat AdminPlat)
        {
            try
            {
                _dbContext.AdminPlat.Add(AdminPlat);
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public void ActualizarAdminPlat(AdminPlat AdminPlat)
        {
            try
            {
                _dbContext.Entry(AdminPlat).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public AdminPlat EliminarAdminPlat(int id)
        {
            try
            {
                AdminPlat? AdminPlat = _dbContext.AdminPlat.Find(id);

                if (AdminPlat != null)
                {
                    _dbContext.AdminPlat.Remove(AdminPlat);
                    _dbContext.SaveChanges();
                    return AdminPlat;
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

        public bool ValidarAdminPlat(int id)
        {
            return _dbContext.AdminPlat.Any(e => e.AdminPlatID == id);
        }
    }
}
