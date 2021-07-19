using System;
using System.Collections.Generic;
using System.Text;

namespace PersonDirectory.Domain.Common
{
    public class BaseEntity<T>
    {
        public T Id { get; set; }
    }
}
