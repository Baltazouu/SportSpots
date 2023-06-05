using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// Interface to save and Load Users (Link With Persistance)
    /// </summary>
    public interface IDataManager
    {
        /// <summary>
        /// Method For LoadUsers From A File
        /// </summary>
        /// <returns>tuple boolean result of operation and List of users loaded null if false opeartion</returns>
        (bool,List<User>?) LoadUser();

        /// <summary>
        /// Method To save users into file
        /// </summary>
        /// <param name="users">List of user to file</param>
        /// <returns>boolean : result of operation</returns>
        bool SaveUser(List<User> users);

    }
}
