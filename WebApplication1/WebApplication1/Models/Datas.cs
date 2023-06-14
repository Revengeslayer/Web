using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public partial class Datas
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public DateTime? LastWriteTime { get; set; }
        public string? Path { set; get; }
        public long? Size { get; set; }
    }
}
