﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonDirectory.Application.Exceptions
{
    public class ObjectNotFoundException : Exception
    {
        public ObjectNotFoundException() { }

        public ObjectNotFoundException(string message)
            : base(message)
        {
        }
    }
}
