using System.Xml.Linq;
using WebApplication1.Models;
using WebApplication1.Models.ViewModel;

namespace WebApplication1.Libs
{
    public interface IDataConverter<TInput, TOutput>
    {
        TOutput Convert(TInput input);
    }
    public class MyApiViewModelConverter : IDataConverter<Datas, MyApiViewModel>
    {
        public MyApiViewModel Convert(Datas dbData)
        {
            var viewModelData = new MyApiViewModel
            {
                Name = dbData.Name,
                LastWriteTime = dbData.LastWriteTime,
                Path = dbData.Path,
                Size = dbData.Size
            };

            return viewModelData;
        }
    }
    public interface IFileInformationProvider
    {
        FileInfo GetFileInformation(string filePath);
    }
    public class FileInformationProvider : IFileInformationProvider, IDataConverter<FileInfo, Datas>
    {
        private string? filePath;
        public Datas Convert(FileInfo infileInformationput)
        {
            var fileDatas = new Datas
            {
                Name = infileInformationput.Name,
                LastWriteTime = infileInformationput.LastWriteTime,
                Path = this.filePath,
                Size = infileInformationput.Length
            };

            return fileDatas;
        }

        public FileInfo GetFileInformation(string filePath)
        {
            this.filePath = filePath;

            return new FileInfo(filePath);
        }
    }
    public class Library
    {
        public static List<MyApiViewModel> GetFileDatas(string[] filepaths)
        {
            //Database Datas load
            var fileInformationProvider = new FileInformationProvider();
            var dbDataLists = GetDBDataLists(filepaths, fileInformationProvider);
            //ViewData load
            var dataConverter = new MyApiViewModelConverter();
            var viewDataLists = GetViewDataLists(dbDataLists, dataConverter);

            return viewDataLists;
        }

        private static List<MyApiViewModel> GetViewDataLists(List<Datas> dbDataLists, IDataConverter<Datas, MyApiViewModel> dataConverter)
        {
            var viesDataLists = dbDataLists.Select(dbData => dataConverter.Convert(dbData)).ToList();

            return viesDataLists;
        }

        private static List<Datas> GetDBDataLists(string[] filepaths, FileInformationProvider fileInformationProvider)
        {
            var dataLists = filepaths.Select(
                filepath =>
                {
                    FileInfo fileInformation = fileInformationProvider.GetFileInformation(filepath);

                    return fileInformationProvider.Convert(fileInformation);
                }).ToList();

            return dataLists;
        }

        public static string FolderPath(string filename)
        {
            string currentPath = Directory.GetCurrentDirectory();
            string folderPath = Path.Combine(currentPath, filename);
            return folderPath;
        }
    }
}
