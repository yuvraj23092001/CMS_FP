using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmsBackend.ViewModels
{
    public class NoticeViewModel
    {
        public int Id { get; set; }

        [Column("Notice")]
        public string? Notice1 { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }

        [Column("FK_CreatedBy")]
        public int? FkCreatedBy { get; set; }
    }
}
