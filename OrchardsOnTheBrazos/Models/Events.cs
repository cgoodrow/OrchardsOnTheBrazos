using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace OrchardsOnTheBrazos.Models
{
    public class Events
    {
        [Key]
        public Guid EventId { get; set; }
        [Display(Name ="Event Post")]
        public string EventPost { get; set; }
        [Display(Name = "Event Picture")]
        public string EventPicture { get; set; }
        [Display(Name = "Event Name")]
        public string EventName { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        [Display(Name ="Event Date")]
        public DateTime EventDate { get; set; }
    }
}