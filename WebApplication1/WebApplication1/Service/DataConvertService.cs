using WebApplication1.Models;
using WebApplication1.Models.ViewModel;
using WebApplication1.Service.Interface;

namespace WebApplication1.Service
{
    public class DataConvertService : IDataConvertService<Datas, MyApiViewModel>
    {
        public MyApiViewModel GetFileDatas(Datas dbData)
        {
            var viewModelData = new MyApiViewModel
            {
                Id = dbData.Id,
                Name = dbData.Name,
                LastWriteTime = dbData.LastWriteTime,
                Path = dbData.Path,
                Size = dbData.Size,
                FileType = dbData.FileType
            };

            return viewModelData;
        }
    }
}
