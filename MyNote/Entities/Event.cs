using MyNote.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyNote.Entities
{
    public class Event
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Text { get; set; }
        [Required]
        public string Date { get; set; }
        public virtual List<Photo> Photos { get; set; }
        public bool IsDeleted { get; set; }
        public ApplicationUser User { get; set; }
        public string UserId { get; set; }
    }
}