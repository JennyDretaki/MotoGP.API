namespace MotoGP.API.Services
{
    public class PaginationMetadata
    {
        public int TotalItemCount { get; }
        public int PageSize { get; }
        public int CurrentPage { get; }
        public int TotalPageCount { get; }

        public PaginationMetadata(int totalItemCount, int pageSize, int currentPage)
        {
            TotalItemCount = totalItemCount;
            PageSize = pageSize;
            CurrentPage = currentPage;
            TotalPageCount = (int)Math.Ceiling(totalItemCount / (double)pageSize);
        }
    }

}
