﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PmcDataModel.Models
{
    interface IIndexable<out T>
    {
        T this[int index] { get; }
    }
}