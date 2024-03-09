using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlainDough.DTO;
public  class PlainObj
{
    public string Name { get; set; }
    public string DataType { get; set; }
    public string CompleteDataType => this.DataType+(this.IsCollection ? "[]" : "");
    public bool IsCollection { get; set; }
}
