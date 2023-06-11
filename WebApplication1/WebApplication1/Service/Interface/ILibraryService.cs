using WebApplication1.Models.ViewModel;

namespace WebApplication1.Service.Interface
{
    public interface ILibraryService
    {
        public string FolderPath(string filename);
        public List<MyApiViewModel> GetFileDatas(string[] filepaths);
        public List<MyApiViewModel> GetSortDatas(List<MyApiViewModel> model, string sortOption);
    }
}
