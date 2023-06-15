using WebApplication1.Service.Interface;

namespace WebApplication1.Service
{
    public class TxtService : ITxtService
    {
        public string FilePath { get; set; }

        public void CreateTxtFile(string filepath)
        {
            string content = "";
            File.WriteAllText(filepath, content);
        }

        public void SetFilePath(string name)
        {
            string currentPath = Directory.GetCurrentDirectory();
            this.FilePath = Path.Combine(currentPath, name);
        }
    }
}
