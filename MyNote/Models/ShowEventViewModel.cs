using MyNote.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyNote.Models
{
    public class ShowEventViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string Date { get; set; }
        public virtual List<Photo> Photos { get; set; }

        public ShowEventViewModel ()
        {
            Photos = new List<Photo>();
        }
    }
}