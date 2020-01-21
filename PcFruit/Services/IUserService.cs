﻿using PcFruit.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PcFruit.Services
{
    public interface IUserService
    {
        User Authenticate(string email, string password);
    }
}
