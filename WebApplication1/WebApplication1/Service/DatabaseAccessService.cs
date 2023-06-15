using WebApplication1.Models;
using WebApplication1.Service.Interface;
using System.IO;
using System.Linq;

namespace WebApplication1.Service
{
    public class DatabaseAccessService : IDatabaseAccessService
    {
        private readonly DatasDbContext _dbContext;
        private readonly IFileProvideService _fileProvideService;
        private readonly ITxtService _txtService;
        public DatabaseAccessService(DatasDbContext datasDbContext, IFileProvideService fileProvideService, ITxtService txtService) 
        {
            this._dbContext = datasDbContext;
            this._fileProvideService = fileProvideService;
            this._txtService = txtService;
        }
        public bool CheckTableIsNull()
        {
            return _dbContext.Datas.Count() == 0;
        }

        public void CreateDatasTable(List<Datas> dataLists)
        {
            _dbContext.Datas.AddRange(dataLists);
            _dbContext.SaveChanges();
        }

        public void CreateNewTxtToDatabase(int txtnumber)
        {
            _txtService.SetFilePath("Files");

            var folderPath = _txtService.FilePath;
            string fileName = txtnumber.ToString() + ".txt";
            string filePath = Path.Combine(folderPath, fileName);

            _txtService.CreateTxtFile(filePath);
            
            FileInfo fileInformation = _fileProvideService.GetFileInfo(filePath);
            var filedata = _fileProvideService.GetFileDatas(fileInformation);
            _dbContext.Datas.Add(filedata);
            _dbContext.SaveChanges();
        }

        public void DeteletData(Datas viewDataIdData)
        {
            _dbContext.Remove(viewDataIdData);
            _dbContext.SaveChanges();
        }

        public Datas FindViewDataIdDbData(int viewDataId)
        {
            return _dbContext.Datas.Find(viewDataId);
        }

        public List<Datas> LoadTableDatas()
        {
            var dataLists = _dbContext.Datas.ToList();

            return dataLists;
        }
    }
}
