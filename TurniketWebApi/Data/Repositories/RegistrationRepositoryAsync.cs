using TurniketWebApi.Data.Context;
using TurniketWebApi.Data.IRepositories;
using TurniketWebApi.Models;

namespace TurniketWebApi.Data.Repositories
{
    public class RegistrationRepositoryAsync : GenericRepositoryAsync<Registration>,IRegistrationRepositoryAsync
    {
        private readonly DatabaseContext dbContext;
        public RegistrationRepositoryAsync(DatabaseContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }
    }
}
