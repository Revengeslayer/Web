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
                FileInfo fileInformation = new FileInfo(filepath);
                Datas data = new Datas
                {
                    Name = fileInformation.Name,
                    LastWriteTime = fileInformation.LastWriteTimeUtc,
                    Path = filepath
                };
                dbDataLists.Add(data);
            }
            //ViewData load
            var viewDataLists = new List<MyApiViewModel>();
            foreach (var dbData in dbDataLists)
            {
                MyApiViewModel viewData = new()
                {
                    Name = dbData.Name,
                    LastWriteTime = dbData.LastWriteTime,
                    Path = dbData.Path
                };
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

            if (sortOption =="name1")
                model = model.OrderBy(model => model.Name).ToList();
            if (sortOption =="name2")
                model =model.OrderByDescending(model => model.Name).ToList();
            if (sortOption == "time1")
                model = model.OrderBy(model => model.LastWriteTime).ToList();
            if (sortOption =="time2")
                model = model.OrderByDescending(model => model.LastWriteTime).ToList();
            if (sortOption == "path1")
                model = model.OrderBy(model => model.Path).ToList();
            if (sortOption =="path2")
                model = model.OrderByDescending(model => model.Path).ToList(); 
            return model;
        }
    }
}
