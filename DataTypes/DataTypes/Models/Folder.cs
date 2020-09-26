using System;
using System.Collections.Generic;
using System.Text;

namespace DataTypes.Models
{
    public class Folder:Entity
    {
        public string Name { get; set; }
        public List<Files> Files { get; set; }
        public List<Folder> Folders { get; set; }
    }
}
