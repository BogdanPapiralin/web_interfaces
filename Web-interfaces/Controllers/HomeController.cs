using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Reflection;
using Web_interfaces.Data;
using Web_interfaces.Filters;
using Web_interfaces.Paging;
using static System.Reflection.Metadata.BlobBuilder;

namespace Web_interfaces.Controllers
{
    public class HomeController : Controller
    {

        
            int pageSize = 6;
            // GET: MedicinesController
          
          

            [HttpGet]
        public IActionResult Index(int page = 1)
        {
            Console.WriteLine("asdasd");
                BooksListViewModel model = new BooksListViewModel();

                List<Book> boo = Search.SearchMain();
                model.Books = Search.SearchMain();
                model.Books = boo
                  .OrderBy(medd => medd.BookId)
                  .Skip((page - 1) * pageSize)
                  .Take(pageSize);

                model.PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = boo.Count
                };


                
            /*
           foreach (Book  a in Search.SearchMain())
            {
                Console.WriteLine(a.Author);
            }*/
            return View(model);
        }
        [HttpPost]

        public IActionResult Index(int page = 1,string genre="" , string title = "", string author = "", int minprice=0,int maxprice=50,int minpages=0,int maxpages=300 ,int year=0 )
        {

             if (genre == null) { genre ="";Console.WriteLine("55555555555"); }
            if (title == null) { title = ""; Console.WriteLine("55555555555"); }
            if (author == null) { author = ""; Console.WriteLine("55555555555"); }
           
            BooksListViewModel model = new BooksListViewModel();

            List<Book> boo = Search.SearchMain(genre, title, author, minprice, maxprice, minpages, maxpages, year);
            List<Book> booo = Search.SearchMain(genre, title, author, minprice, maxprice, minpages, maxpages, year);
            Console.WriteLine("11111111111111111");
           
            foreach (Book book in booo) { Console.WriteLine(book.Title); }
            Console.WriteLine("22222222222222222");

            model.Books = Search.SearchMain();
            model.Books = boo
              .OrderBy(medd => medd.BookId)
              .Skip((page - 1) * pageSize)
              .Take(pageSize);

            model.PagingInfo = new PagingInfo
            {
                CurrentPage = page,
                ItemsPerPage = pageSize,
                TotalItems = boo.Count
            };
           




            Console.WriteLine(genre + title + author + minprice + maxprice + minpages + maxpages + year);
            List <Book>  Books = Search.SearchMain( genre,  title,  author,  minprice,  maxprice,  minpages,  maxpages,  year);
       


                
            Console.WriteLine(genre + title + author + minprice + maxprice + minpages + maxpages + year);
            
            return View(model);
        }
    }
}
