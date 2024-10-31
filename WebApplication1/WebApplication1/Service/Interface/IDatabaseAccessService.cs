using WebApplication1.Models;

namespace WebApplication1.Service.Interface
{
    public interface IDatabaseAccessService
    {
        bool CheckTableIsNull();
        void CreateDatasTable(List<Datas> dataLists);
        List<Datas> LoadTableDatas();
        void CreateNewTxtToDatabase(int txtnumber);
        Datas? FindViewDataIdDbData(int viewDataId);
        void DeteletData(Datas viewDataIdData);
        void AddData(Datas Data);
    }
}
