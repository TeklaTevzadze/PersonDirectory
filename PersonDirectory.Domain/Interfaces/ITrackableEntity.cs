using System;
using System.Collections.Generic;
using System.Text;

namespace PersonDirectory.Domain.Interfaces
{
    public interface ITrackableEntity
    {
        public DateTime DateCreated { get; set; }
    }
}
