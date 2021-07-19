using System;
using System.Collections.Generic;
using System.Text;

namespace PersonDirectory.Application.Models
{
    public class PagedData<T>
    {
        public List<T> Data { get; set; }
        public int TotalItemCount { get; set; }
        public int Page { get; set; }
        public int Offset { get; set; }
        public int PageCount { get; set; }
    }
}
