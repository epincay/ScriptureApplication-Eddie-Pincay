using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ScriptureApplication.Models
{
    public class Scripture
    {
        public int ID { get; set; }

        [Display(Name = "Book Name")]
        public string Book { get; set; }

        public string Chapter { get; set; }
        public string Verse { get; set; }
        public string Note { get; set; }

        [Display(Name = "Date Added")]
        [DataType(DataType.Date)]
        public DateTime Date_Added { get; set; }
    }
}
