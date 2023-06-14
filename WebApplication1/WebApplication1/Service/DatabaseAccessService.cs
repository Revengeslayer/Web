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

        public void CreateTableDatas(List<Datas> dataLists)
        {
            _dbContext.Datas.AddRange(dataLists);
            _dbContext.SaveChanges();
        }

        public List<Datas> LoadTableDatas()
        {
            var dataLists = _dbContext.Datas.ToList();

            return dataLists;
        }
    }
}
