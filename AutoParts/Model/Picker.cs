using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AutoParts.Model
{
    class Picker
    {
        private List<IAnalog> direct;
        private List<IAnalog> possible;
        private List<IAnalog> undirect;

        public Picker(List<IAnalog> d, List<IAnalog> p)
        {
            direct = d;
            possible = p;
            undirect = new List<IAnalog>();
        }
        public List<int> GetParts()
        {
            Select_Undirect();
            
            var res = direct.Concat(undirect);

            return res.Select(x => x.id).ToList();

        }

        private void Select_Undirect()
        {
            foreach(var p in possible)
            {
                foreach (var d in direct)
                {
                    if(d.HasAnalog(p))
                    {
                        undirect.Add(p);
                        break;
                    }
                }
            }
            
        }
    }
}
