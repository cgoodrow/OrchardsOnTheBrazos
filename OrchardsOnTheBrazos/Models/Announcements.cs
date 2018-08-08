using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace OrchardsOnTheBrazos.Models
{
    public class Announcements
    {
        public int Id { get; set; }
        public string Title { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        //[DataType(DataType.Date)]
        public DateTime Date { get; set; }
        public string Announcement { get; set; }
    }
}