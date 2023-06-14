using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models.ViewModel
{
    public partial class MyApiViewModel
    {
        [Key]
        public int Id { get; set; }
        public long? Size { get; set; }
        public string? FileType { get; set; }
    }
}
