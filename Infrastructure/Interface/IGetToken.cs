﻿using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interface
{
   public interface IGetToken
    {
        string GetToken2(LoginModel user );
    }
}
