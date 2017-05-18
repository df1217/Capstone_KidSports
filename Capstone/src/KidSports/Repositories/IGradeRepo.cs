﻿using KidSports.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KidSports.Repositories
{
    public interface IGradeRepo
    {
        List<Grade> GetAllGrades();
    }
}
