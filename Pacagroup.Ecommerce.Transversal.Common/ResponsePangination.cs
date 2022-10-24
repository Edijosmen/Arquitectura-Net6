
namespace Pacagroup.Ecommerce.Transversal.Common
{
    public class ResponsePangination<T>:ResponseGeneric<T>
    {
        public int PageNumber { get; set; }
        public int TotalPage { get; set; }
        public int TotalCount { get; set; }
        public bool HasPreviousPage =>PageNumber > 1;
        public bool HasNextPage => PageNumber < TotalPage;

    }
}
