using WebApplication1.Models;
using WebApplication1.Models.ViewModel;

namespace WebApplication1.Libs
{
    public class Library
    {
        public static List<MyApiViewModel> GetFileDatas(string[] filepaths)
        {
            //Database Datas load
            var dbDataLists = new List<Datas>();    
            foreach (var filepath in filepaths)
            {
                Datas data = new Datas();
                FileInfo fileInformation = new FileInfo(filepath);
                data.name = fileInformation.Name;
                data.lastWriteTime = fileInformation.LastWriteTimeUtc;
                data.path = filepath;
                dbDataLists.Add(data);
            }
            //ViewData load
            var viewDataLists = new List<MyApiViewModel>();
            foreach (var dbData in dbDataLists)
            {
                MyApiViewModel viewData = new MyApiViewModel();
                viewData.name = dbData.name;
                viewData.lastWriteTime = dbData.lastWriteTime;
                viewData.path = dbData.path;
                viewDataLists.Add(viewData);
            }

            return viewDataLists;
        }

        public static string FolderPath(string filename)
        {
            string currentPath = Directory.GetCurrentDirectory();
            string folderPath = Path.Combine(currentPath, filename);
            return folderPath;
        }
    }
}
