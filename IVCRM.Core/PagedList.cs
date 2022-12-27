using IVCRM.Core.Models;

namespace IVCRM.Core
{
    public class PagedList<T>
    {
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public IEnumerable<T> Data { get; set; }

        public PagedList()
        {
            Data = new List<T>();
        }

        public PagedList(IEnumerable<T> items, int count, TableParameters parameters)
        {
            TotalCount = count;
            PageSize = parameters.PageSize;
            CurrentPage = parameters.PageNumber;
            TotalPages = (int)Math.Ceiling(count / (double)parameters.PageSize);
            Data = items;
        }
    }
}
