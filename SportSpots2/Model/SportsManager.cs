using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class SportsManager
    {  

        public IReadOnlyCollection<Sport> avaibles {  get; private set; }

        readonly List<Sport> avaibleS;
        
        public SportsManager()
        {
            avaibleS = SportStub.Loadsport();

        }

        

    }
}
