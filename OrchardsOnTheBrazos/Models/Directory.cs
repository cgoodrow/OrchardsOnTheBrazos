using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrchardsOnTheBrazos.Models
{
    public class Directory
    {
        public int DirectoryId { get; set; }

        public virtual ICollection<DirectoryDetail> DirectoryDetail { get; set; }
    }
}