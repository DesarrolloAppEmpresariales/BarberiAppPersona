using BarberiAppPersona.Interface;
using BarberiAppPersona.Models;
using Microsoft.EntityFrameworkCore;

namespace BarberiAppPersona.Repository
{
    public class AdminNegRepository : IAdminNeg
    {
        readonly DatabaseContext _dbContext = new();

        public AdminNegRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<AdminNeg> ObtenerListaAdminNegs()
        {
            try
            {
                return _dbContext.AdminNeg.ToList();
            }
            catch
            {
                throw;
            }
        }

        public AdminNeg ObtenerAdminNegPorId(int id)
        {
            try
            {
                AdminNeg? AdminNeg = _dbContext.AdminNeg.Find(id);
                if (AdminNeg != null)
                {
                    return AdminNeg;
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

        public void CrearAdminNeg(AdminNeg AdminNeg)
        {
            try
            {
                _dbContext.AdminNeg.Add(AdminNeg);
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public void ActualizarAdminNeg(AdminNeg AdminNeg)
        {
            try
            {
                _dbContext.Entry(AdminNeg).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public AdminNeg EliminarAdminNeg(int id)
        {
            try
            {
                AdminNeg? AdminNeg = _dbContext.AdminNeg.Find(id);

                if (AdminNeg != null)
                {
                    _dbContext.AdminNeg.Remove(AdminNeg);
                    _dbContext.SaveChanges();
                    return AdminNeg;
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

        public bool ValidarAdminNeg(int id)
        {
            return _dbContext.AdminNeg.Any(e => e.AdminNegID == id);
        }
    }
}
