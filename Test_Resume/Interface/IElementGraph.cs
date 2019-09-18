using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_Resume.Model;
using Test_Resume.Model.Enums;

namespace Test_Resume.Interface
{
 public   interface IElementGraph
    {
       int Id { get; set; }

       string Name { get; set; }
       DominateLevel DominateLevel { get; set; }

      // List<IElementGraph> Childs { get; set; }

       DateTime?  StartTime { get; set; }

       DateTime?  EndTime { get; set; }


    }
}
