using Web_interfaces.Data;
using System.Linq;
namespace Web_interfaces.Filters
{
    public class Search
    {


        public static List<Book> SearchMain(string searchganre = "",string searchtitle="" , string searchautor = "", int minprice = 0, int maxprice = 50, int minpages = 0, int maxpages = 300,int yearss = 0)
        {
            using (var context = new BookContext())
            {

                List<Book> books;
                books = Search.SearchTitle(searchtitle);
                books = Search.SearchGanre(books, searchganre);
                books = Search.SearchAutor(books, searchautor);
                books = Search.SearchPrice(books, minprice, maxprice);
                books = Search.SearchPages(books, minpages, maxpages);
                books = Search.SearchYear(books, yearss);
                foreach(Book book in books) { Console.WriteLine(book.Title); }
                
                return books;
            }
        }


        public static List<Book> SearchTitle(string searchTerm ="")
            {
                using (var context = new BookContext())
                {
                    var books = context.Books
                        .Where(b => b.Title.Contains(searchTerm) )
                        .ToList();

                    return books;
                }
            }



        public static List<Book> SearchGanre( List<Book> book,string searchTerm = "")
        {
            
                var books = book
                    .Where(b => b.Types.Contains(searchTerm))
                    .ToList();

                return books;
            
        }




        public static List<Book> SearchAutor(List<Book> book, string searchTerm = "")
        {
            
                var books = book
                    .Where(b =>  b.Author.Contains(searchTerm))
                    .ToList();

                return books;
            
        }


        public static List<Book> SearchPrice(List<Book> book, int min,int max)
        {

            var books = book.Where(b => b.Price <= max && b.Price >= min).ToList();
            return books;

            
            
        }



        public static List<Book> SearchPages(List<Book> book, int min,int max)
        {

            var books = book.Where(b => b.Pages <= max && b.Pages >= min).ToList();
            return books;

            
            
        }

        
        public static List<Book> SearchYear(List<Book> book, int yer)
        {
            if(yer == 0) { return book; }
                var books = book
                    .Where(b => b.Years == yer)
                    .ToList();

                return books;
           
        }

    }
}
