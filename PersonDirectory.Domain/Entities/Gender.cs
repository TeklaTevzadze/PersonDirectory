using PersonDirectory.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonDirectory.Domain.Entities
{
    public class Gender : BaseEntity<int>
    {
        public string Name { get; set; }
    }
}
