using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_Resume.Interface;
using Test_Resume.Model.Enums;

namespace Test_Resume.Model
{
  public  class ElementGraph: IElementGraph
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public DominateLevel DominateLevel { get; set; }
 
        public  List<ElementGraph> Childs { get; set; }

         //[NotMapped]
       // List<IElementGraph> IElementGraph.Childs { get => Childs.ConvertAll(o => (IElementGraph)o); set { Childs = value.ConvertAll(o => (ElementGraph)o);   } }

        private DateTime? startTime;
        public DateTime?  StartTime { get
            {
                if (this.DominateLevel != DominateLevel.Level5)
                {
                    if (Childs != null)
                        if (Childs.Count > 0)
                            return Childs.Where(x => x.StartTime.HasValue).Select(x => x.StartTime).Min();
                    return null;
                }
                else { return startTime; }
            }
                        
            set { if (DominateLevel == DominateLevel.Level5) { startTime = value; } }

        }

        private DateTime? endTime;
        public DateTime?  EndTime
        {
            get
            {
                if (DominateLevel != DominateLevel.Level5)
                {
                    if(Childs!=null)
                        if (Childs.Count>0)
                            return Childs.Where(x=>x.EndTime.HasValue) .Select(x => x.EndTime ).Max();
                    return null;
                }
                else return endTime;
            }


            set { if (DominateLevel == DominateLevel.Level5) { endTime = value; } }

        }



    }

}
