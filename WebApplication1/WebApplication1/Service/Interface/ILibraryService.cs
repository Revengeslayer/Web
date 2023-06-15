using WebApplication1.Models;
using WebApplication1.Models.ViewModel;

namespace WebApplication1.Service.Interface
{
    public interface ILibraryService
    {
        string FolderPath(string filename);
        List<Datas> GetFileDbDatas(string[] filepaths);
        List<MyApiViewModel> GetViewDatas(List<Datas> datas);
        List<MyApiViewModel> GetSortDatas(List<MyApiViewModel> model, string sortOption);
        string[] GetFilePaths(string filename);
        void CreateNewTxt();
    }
}
