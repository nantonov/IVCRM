namespace IVCRM.Core.Models
{
    public class TableParameters
    {
        const int MaxPageSize = 50;
        public int PageNumber { get; set; } = 0;
        private int _pageSize { get; set; } = 10;
        public int PageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
            }
        }
    }
}
