using TurniketWebApi.Data.Context;
using TurniketWebApi.Data.IRepositories;
using TurniketWebApi.Models;

namespace TurniketWebApi.Data.Repositories
{
    public class EmployeeRepositoryAsync : GenericRepositoryAsync<Employee>,IEmployeeRepositoryAsync
    {
        private readonly DatabaseContext dbContext;
        public EmployeeRepositoryAsync(DatabaseContext dbContext): base(dbContext) 
        {
            this.dbContext = dbContext;
        }

    }
}
