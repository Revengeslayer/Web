using WebApplication1.Models;
using WebApplication1.Service.Interface;

namespace WebApplication1.Service
{
    public class FileProvideService : IFileProvideService
    {
        private string? filePath;

        public Datas Convert(FileInfo infileInformationput)
        {
            var fileData = new Datas
            {
                Name = infileInformationput.Name,
                LastWriteTime = infileInformationput.LastWriteTime,
                Path = this.filePath,
                Size = infileInformationput.Length,
                FileType = infileInformationput.Extension
            };

            return fileData;
        }

        public FileInfo GetFileInfo(string filePath)
        {
            this.filePath = filePath;

            return new FileInfo(filePath);
        }
    }
}
