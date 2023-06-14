﻿using WebApplication1.Libs;
using WebApplication1.Models;
using WebApplication1.Models.ViewModel;
using WebApplication1.Service.Interface;

namespace WebApplication1.Service
{
    public class LibraryService : ILibraryService
    {
        private readonly IFileProvideService fileProvideService;
        private readonly IDataConvertService<Datas, MyApiViewModel> dataConvertService;
        public LibraryService(IFileProvideService fileProvideService, IDataConvertService<Datas, MyApiViewModel> dataConvertService)
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
        public List<Datas> GetFileDatas(string[] filepaths)
        {
            //Database Datas load
            var dataLists = filepaths.Select(
                filepath =>
                {
                    FileInfo fileInformation = fileProvideService.GetFileInfo(filepath);

                    return fileProvideService.Convert(fileInformation);
                }).ToList();

            return dataLists;
        }
        public List<MyApiViewModel> GetViewDatas(List<Datas> dbDataLists)
        {
            var viesDataLists = dbDataLists.Select(dbData => dataConvertService.Convert(dbData)).ToList();

            return viesDataLists;
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

        public string[] GetFilePaths(string filename)
        {
            var directoryPath = FolderPath(filename);
            string[] filePaths = Directory.GetFiles(directoryPath);

            return filePaths;
        }
    }
}
