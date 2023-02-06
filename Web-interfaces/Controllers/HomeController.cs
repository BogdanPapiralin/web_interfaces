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
        public IActionResult login()
        { return View(); }

        [HttpPost]

        public IActionResult login(string Email, string password)
        {
            if (Email != null && password != null )
            {
               if( DbUser.SearchUser(Email, password)) 
                {return Redirect("/?page=1");
                    
                }
                else { ViewData["Message"] = "try again Email or password no correct ";
                    return View(); }
            }
            else
            {
                ViewData["Message"] = "try again Email or password no correct ";
                return View();
            }
            
        }

        [HttpGet]
        public IActionResult registration()
        { return View(); }

        [HttpPost]

        public IActionResult registration(string Email,string password,string confirm_password)
        {
            if(Email!=null && password != null && password == confirm_password ) 
            { 
            DbUser.AddUser(Email, password);
            }
            else
            {
                ViewData["Message"] = "try again Email or password = null or password != confirm_password ";
                return View();
            }
            return Redirect("/?page=1");
        }

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

        public IActionResult Index(int page = 1,string genre="" , string title = "", string author = "", int minprice=0,int maxprice=50,int minpages=0,int maxpages=1000 ,int year=0 )
        {

             if (genre == null) { genre ="";}
            if (title == null) { title = "";  }
            if (author == null) { author = "";  }
           
            BooksListViewModel model = new BooksListViewModel();

            List<Book> boo = Search.SearchMain(genre, title, author, minprice, maxprice, minpages, maxpages, year);
         
          

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
           




          
            return View(model);
        }
    }
}
