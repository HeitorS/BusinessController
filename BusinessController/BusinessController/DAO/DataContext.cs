using BusinessController.Models;
using System.Data.Entity;
using System.Data.Entity.Validation;

namespace BusinessController.DAO
{
    public class DataContext : DbContext
    {
        public DataContext() : base("name=Matriz") { }

        public DbSet<PESSOA> Pessoas { get; set; }

        public DbSet<USUARIO> Usuarios { get; set; }

        public override int SaveChanges()
        {
            try
            {
                return base.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                string objectError = string.Empty;
                string errorValue = string.Empty;
                foreach (var eve in e.EntityValidationErrors)
                {
                    objectError += string.Format("Entidade do tipo \"{0}\" no estado \"{1}\" tem os seguintes erros de validação:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        errorValue += string.Format("- Property: \"{0}\", Erro: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
        }
    }
}