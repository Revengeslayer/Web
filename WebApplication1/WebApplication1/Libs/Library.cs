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
                data.Name = fileInformation.Name;
                data.LastWriteTime = fileInformation.LastWriteTimeUtc;
                data.Path = filepath;
                dbDataLists.Add(data);
            }
            //ViewData load
            var viewDataLists = new List<MyApiViewModel>();
            foreach (var dbData in dbDataLists)
            {
                MyApiViewModel viewData = new MyApiViewModel();
                viewData.Name = dbData.Name;
                viewData.LastWriteTime = dbData.LastWriteTime;
                viewData.Path = dbData.Path;
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

        public static List<MyApiViewModel> GetSortDatas(List<MyApiViewModel> model, string sortOption)
        {
            if (sortOption =="name")
            {
                model =model.OrderByDescending(model => model.Name).ToList();
            }
            if (sortOption =="time")
            {
                model = model.OrderByDescending(model => model.LastWriteTime).ToList();
            }
            if (sortOption =="path")
            { 
                model = model.OrderByDescending(model => model.Path).ToList(); 
            }
            return model;
        }
    }
}
