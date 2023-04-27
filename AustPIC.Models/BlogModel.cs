using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AustPIC.Models
{
    public class BlogModel
    {
        public int BlogId { get; set; }
        [Required]
        [DisplayName("Blog Title")]
        public string BlogTitle { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public System.DateTime BlogDate { get; set; }
        [Required]
        [DisplayName("Blog Author")]
        public string BlogAuthor { get; set; }
        [Required]
        [DisplayName("Blog Category")]
        public string BlogCatergory { get; set; }
        [Required]
        [DisplayName("Blog Description")]
        public string BlogShort { get; set; }
        [Required]
        [DisplayName("Blog Content")]
        public string BlogBody { get; set; }
        [DisplayName("Blog Image")]
        public string BlogImg { get; set; }
        public int BlogView { get; set; }
    }
}
