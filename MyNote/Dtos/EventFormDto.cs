using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyNote.Dtos
{
    public class EventFormDto
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        [DataType(DataType.MultilineText)]
        public string Text { get; set; }
        [Required]
        public string Date { get; set; }
        public virtual List<string> PhotoPaths { get; set; }

        public EventFormDto()
        {
            PhotoPaths = new List<string>();
        }
    }
}