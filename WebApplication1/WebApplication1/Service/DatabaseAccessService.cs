using WebApplication1.Models;
using WebApplication1.Service.Interface;

namespace WebApplication1.Service
{
    public class DatabaseAccessService : IDatabaseAccessService
    {
        private readonly DatasDbContext _dbContext;
        public DatabaseAccessService(DatasDbContext datasDbContext) 
        {
            this._dbContext = datasDbContext;
        }
        public bool CheckTableIsNull()
        {
            return _dbContext.Datas.Count() == 0;
        }
    }
}
