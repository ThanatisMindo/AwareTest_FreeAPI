﻿using AwareTest.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwareTest.Services.IService
{
    public interface IDummyService
    {
        Task<string> GetDummyEmployee();
    }
}
