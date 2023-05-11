﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public interface IDataManager
    {
        (bool,List<User>?) LoadUser();

        bool SaveUser(List<User> users);

    }
}
