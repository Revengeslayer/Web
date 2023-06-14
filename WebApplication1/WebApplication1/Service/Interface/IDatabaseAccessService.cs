using WebApplication1.Models;

namespace WebApplication1.Service.Interface
{
    public interface IDatabaseAccessService
    {
        bool CheckTableIsNull();
        void CreateTableDatas(List<Datas> dataLists);
        List<Datas> LoadTableDatas();
    }
}
