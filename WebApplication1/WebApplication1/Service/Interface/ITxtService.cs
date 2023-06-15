namespace WebApplication1.Service.Interface
{
    public interface ITxtService
    {
        public string FilePath { get; set; }
        void SetFilePath(string name);
        void CreateTxtFile(string filepath);
    }
}
