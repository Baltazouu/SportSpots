using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// Cass to manage list of spots avaible
    /// </summary>
    public class SportsManager
    {  

        //public IReadOnlyCollection<Sport> avaibles {  get; private set; }

        readonly ObservableCollection<Sport> avaibleS;
        
        public SportsManager()
        {
            avaibleS = SportStub.Loadsport();

        }
    }
}
