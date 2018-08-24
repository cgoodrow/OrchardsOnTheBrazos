using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace OrchardsOnTheBrazos.Models
{
    public class Info
    {
        [Key]
        public int Id { get; set; }
        public string Site { get; set; }
        public string Link { get; set; }
    }
}