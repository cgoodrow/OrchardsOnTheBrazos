using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrchardsOnTheBrazos.Models
{
    public class FileDetail
    {
        public Guid Id { get; set; }
        public string FileName { get; set; }
        public string Extension { get; set; }
        public int SupportId { get; set; }
        public virtual Support Support { get; set; }

    }

    public class DirectoryDetail
    {
        public Guid Id { get; set; }
        public string FileName { get; set; }
        public string Extension { get; set; }
        public int DirectoryId { get; set; }
        public virtual Directory Directory { get; set; }

    }
}