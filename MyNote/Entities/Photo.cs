using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyNote.Entities
{
    public class Photo
    {
        [Key]
        public int Id { get; set; }
        public string Path { get; set; }

        [ForeignKey("EventId")]
        public virtual Event Event { get; set; }
        public int EventId { get; set; }
    }
}