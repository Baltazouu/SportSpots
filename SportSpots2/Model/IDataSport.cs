using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public interface IDataSport
    {
        public List<Sport> LoadSports();

        public void SaveSports(List<Sport> sports);

    }
}
