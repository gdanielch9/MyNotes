using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyNote.Dtos
{
    public class EventFormDto
    {
        public int Id { get; set; }
        [Required]
        [DisplayName("Tytuł")]
        public string Title { get; set; }
        [Required]
        [DataType(DataType.MultilineText)]
        [DisplayName("Treść")]
        public string Text { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}")]
        public string Date { get; set; }
        public virtual List<string> PhotoPaths { get; set; }

        public EventFormDto()
        {
            PhotoPaths = new List<string>();
        }
    }
}