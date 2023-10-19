namespace BrasilGeo.Aplications.Queries
{
    public class LocationIBGEReadQuery
    {
        private const int MaxPageSize = 50;
        public int PageIndex { get; set; } = 1;
        private int _pageSize = 6;
        public int PageSize
        {
            get { return _pageSize; }
            set { _pageSize = (value > MaxPageSize) ? MaxPageSize : value; }
        }
        public long Id { get; set; }
        public string State { get; set; }
        public string City{ get; set; }
        public string Sort { get; set; } = "StateAsc";
        private string _search;
        public string Search
        {
            get { return _search; }
            set { _search = value.ToLower(); }
        }
    }
}
