using WebApplication1.Libs;
using WebApplication1.Models;
using WebApplication1.Models.ViewModel;
using WebApplication1.Service.Interface;

namespace WebApplication1.Service
{
    public class LibraryService : ILibraryService
    {
        private readonly IFileProvideService fileProvideService;
        private readonly IDataConvertService<Datas, MyApiViewModel> dataConvertService;
        public LibraryService(IFileProvideService fileProvideService,IDataConvertService<Datas,MyApiViewModel> dataConvertService) 
        {
            this.fileProvideService = fileProvideService;
            this.dataConvertService = dataConvertService;
        }
        public string FolderPath(string filename)
        {
            string currentPath = Directory.GetCurrentDirectory();
            string folderPath = Path.Combine(currentPath, filename);
            return folderPath;
        }
        public List<MyApiViewModel> GetFileDatas(string[] filepaths)
        {
            //Database Datas load
            var dbDataLists = GetDBDataLists(filepaths, fileProvideService);
            //ViewData load
            var viewDataLists = GetViewDataLists(dbDataLists, dataConvertService);

            return viewDataLists;
        }
        private static List<MyApiViewModel> GetViewDataLists(List<Datas> dbDataLists, IDataConvertService<Datas, MyApiViewModel> dataConverter)
        {
            var viesDataLists = dbDataLists.Select(dbData => dataConverter.Convert(dbData)).ToList();

            return viesDataLists;
        }
        private static List<Datas> GetDBDataLists(string[] filepaths, IFileProvideService fileInformationProvider)
        {
            var dataLists = filepaths.Select(
                filepath =>
                {
                    FileInfo fileInformation = fileInformationProvider.GetFileInformation(filepath);

                    return fileInformationProvider.Convert(fileInformation);
                }).ToList();

            return dataLists;
        }
        public List<MyApiViewModel> GetSortDatas(List<MyApiViewModel> model, string sortOption)
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
