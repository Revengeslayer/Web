using WebApplication1.Models;
using WebApplication1.Service.Interface;

namespace WebApplication1.Service
{
    public class FileProvideService : IFileProvideService
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
}
