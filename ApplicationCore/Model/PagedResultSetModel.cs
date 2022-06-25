using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Model
{
    public class PagedResultSetModel<T> where T : class
    {
        public PagedResultSetModel    
  
        public int PageNumber { get; }
        public int TotalRecords { get; }
        public int TotalPages { get; }
        public bool HasPreviousPage => PageNumber > 1;
        public bool HasNextPage => PageNumber < TotalRecords;
        public IEnumerable<T> PagedDate { get; set; }
    }
}
