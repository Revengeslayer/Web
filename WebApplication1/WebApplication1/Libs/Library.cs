using System.Xml.Linq;
using WebApplication1.Models;
using WebApplication1.Models.ViewModel;

namespace WebApplication1.Libs
{
    public class Library
    {
        public static List<MyApiViewModel> GetFileDatas(string[] filepaths)
        {
            //Database Datas load
            List<Datas> dbDataLists = GetDBDataLists(filepaths);
            //ViewData load
            List<MyApiViewModel> viewDataLists = GetViewDataLists(dbDataLists);

            return viewDataLists;
        }

        private static List<MyApiViewModel> GetViewDataLists(List<Datas> dbDataLists)
        {
            var viesDataLists = dbDataLists.Select(
               dbData => new MyApiViewModel
               {
                   Name = dbData.Name,
                   LastWriteTime = dbData.LastWriteTime,
                   Path = dbData.Path,
                   Size = dbData.Size
               }).ToList();

            return viesDataLists;
        }

        private static List<Datas> GetDBDataLists(string[] filepaths)
        {
            var dataLists = filepaths.Select(
                filepath =>
                {
                    FileInfo fileInformation = new FileInfo(filepath);
                    return new Datas
                    {
                        Name = fileInformation.Name,
                        LastWriteTime = fileInformation.LastWriteTime,
                        Path = filepath,
                        Size =fileInformation.Length
                    };
                }).ToList();

            return dataLists;
        }

        public static string FolderPath(string filename)
        {
            string currentPath = Directory.GetCurrentDirectory();
            string folderPath = Path.Combine(currentPath, filename);
            return folderPath;
        }

        public static List<MyApiViewModel> GetSortDatas(List<MyApiViewModel> model, string sortOption)
        {

            if (sortOption == "name1")
                model = model.OrderBy(model => model.Name).ToList();
            if (sortOption == "name2")
                model = model.OrderByDescending(model => model.Name).ToList();
            if (sortOption == "time1")
                model = model.OrderBy(model => model.LastWriteTime).ToList();
            if (sortOption == "time2")
                model = model.OrderByDescending(model => model.LastWriteTime).ToList();
            if (sortOption == "path1")
                model = model.OrderBy(model => model.Path).ToList();
            if (sortOption == "path2")
                model = model.OrderByDescending(model => model.Path).ToList();
            if (sortOption == "size1")
                model = model.OrderBy(model => model.Size).ToList();
            if (sortOption == "size2")
                model = model.OrderByDescending(model => model.Size).ToList();

            return model;
        }
    }
}
