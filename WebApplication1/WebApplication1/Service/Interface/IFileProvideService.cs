using WebApplication1.Models;

namespace WebApplication1.Service.Interface
{
    public interface IFileProvideService:IDataConvertService<FileInfo, Datas>
    {
        FileInfo GetFileInformation(string filePath);
    }
}
