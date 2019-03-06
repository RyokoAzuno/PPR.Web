using System.Collections.Generic;

namespace PPR.Web.Models
{
    public class PageViewModel<T> where T: class
    {
        public IEnumerable<T> Items { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}