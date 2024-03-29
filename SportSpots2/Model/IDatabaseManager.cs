﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// Interface For Manager The Link With the DataBase
    /// Not Used Here
    /// </summary>
    public interface IDatabaseManager
    {
        List<Sport> LoadFavSportFromUser(string mail, string password);
        List<Spot> LoadFavSpotFromUser(string mail);
        bool CheckRightPasswd(string addr, string passwd);
        bool CheckMailExist(string addr);
        int GetNewUserId();
        int GetUserID(string addr);
        bool InsertNewSport(int id, string addr, Sport s);
        bool InsertNewUser(string addr, string passwd);
        bool UpdateMail(int id, string addr);
        bool UpdatePass(int id, string addr, string passwd);
        bool InsertFavSport(Sport s, User u);
        bool InsertFavspot(Spot s, User u);
    }
}
