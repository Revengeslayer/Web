using WebApplication1.Models;
using WebApplication1.Models.ViewModel;

namespace WebApplication1.Service.Interface
{
    public interface ILibraryService
    {
        public string FolderPath(string filename);
        public List<Datas> GetFileDbDatas(string[] filepaths);
        public List<MyApiViewModel> GetViewDatas(List<Datas> datas);
        public List<MyApiViewModel> GetSortDatas(List<MyApiViewModel> model, string sortOption);
        string[] GetFilePaths(string filename);
    }
}
