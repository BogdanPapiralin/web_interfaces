using Web_interfaces.Data;

namespace Web_interfaces.Paging
{
    public class BooksListViewModel
    {
        public  IEnumerable<Book> Books { get; set; }
        public  PagingInfo PagingInfo { get; set; }
    }
}
