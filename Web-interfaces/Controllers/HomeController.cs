using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SQLInfoRetriever;
using System.Data;
using System.Net;
using System.Reflection;
using System.Reflection.Emit;
using System.Web.Helpers;
using Web_interfaces.Data;
using Web_interfaces.Filters;
using Web_interfaces.Paging;
using static System.Reflection.Metadata.BlobBuilder;

namespace Web_interfaces.Controllers
{
    public class HomeController : Controller
    {



        [HttpGet]
        public async Task Edit(int id)
        {
            if (DbOrder.Searchid(id, 1) == true) { DbOrder.AddToOrder(id, 1); }
            else { DbOrder.AddOrder(id, 1); }

            Console.WriteLine(id);

        }

        [HttpGet]
        public async Task Edit1(int id)
        {
            Console.WriteLine("sssssssssssssdd");
            using (var context = new BookContext())
            {
                Order or = context.Orders.Find(id);
                context.Orders.Remove(or);
                context.SaveChanges();
            }

        }

        int pageSize = 6;

        [HttpGet]
        public IActionResult cart(int id)
        {
            if (id != 0)
            {
                using (var context = new BookContext())
                {
                    Order or = context.Orders.Find(id);
                    context.Orders.Remove(or);
                    context.SaveChanges();
                }
            }


            OrderListViewModel model = new OrderListViewModel();
            BookContext h = new BookContext();
            List<Order> med = DbOrder.SearchStutus(0);
            model.Orders = med;


            return View(model);
        }
       



        [HttpGet]
        public IActionResult pay()
        {
            OrderListViewModel model = new OrderListViewModel();
            BookContext h = new BookContext();
            List<Order> med = DbOrder.SearchStutus(0);
            model.Orders = med;


            return View(model);
        }
        [HttpPost]

        public IActionResult pay(string Namee, string Email1, string City, int ZipCode, string Address, string Comment)
        {

            BookContext h = new BookContext();
            List<Order> med = DbOrder.SearchStutus(0);
            if ( Namee != null && Email1 != null && City != null && ZipCode != 0 && Address != null )
            {
                  using (SqlConnection connection = new SqlConnection(Retriever.connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("INSERT INTO UserInfo (Name, Email, City, ZipCode, Address, Comment) VALUES (@Name, @Email, @City, @ZipCode, @Address, @Comment)", connection))
                    {
                        command.Parameters.AddWithValue("@Name", Namee);
                        command.Parameters.AddWithValue("@Email", Email1);
                        command.Parameters.AddWithValue("@City", City);
                        command.Parameters.AddWithValue("@ZipCode", ZipCode);
                        command.Parameters.AddWithValue("@Address", Address);
                        command.Parameters.AddWithValue("@Comment", Comment);





                   
                    }



                    using (SqlCommand command = new SqlCommand("SELECT * FROM UserInfo ORDER BY UserID DESC", connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int insertedUserID = reader.GetInt32(0);
                            
                            
                                    foreach (Order o in med) {
                                        using (var context = new BookContext())
                                        {
                                            var orderToEdit = context.Orders.Find(o.OrderId);
                                        Console.WriteLine(orderToEdit.Status);
                                                orderToEdit.Status =insertedUserID;
                                                context.SaveChanges();
                                    }
                                     }

                            }

                        


                        }
                    }




                    return Redirect("/?page=1");
                } 
            }
            else
            {
                OrderListViewModel model = new OrderListViewModel();
                List<Order> med1 = DbOrder.SearchStutus(0);
                model.Orders = med1;
                ViewData["Message"] = "Try again one of the fields is not filled ";
                Console.WriteLine("Name: " + Namee + " Email: " + Email1 + " City: " + City + " ZipCode: " + ZipCode + " Address: " + Address + " Comment: " + Comment);
                return View(model);
            }
            //Name, Email, City, ZipCode, Address, Comment
            
        }






        [HttpGet]
        public IActionResult login()
        { return View(); }

        [HttpPost]

        public IActionResult login(string Email, string password)
        {
            if (Email != null && password != null)
            {
                if (DbUser.SearchUser(Email, password))
                { return Redirect("/?page=1");

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

        public IActionResult registration(string Email, string password, string confirm_password)
        {
            if (Email != null && password != null && password == confirm_password)
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
        public IActionResult Index(int page)
        {
            BooksListViewModel model = new BooksListViewModel();
            Console.WriteLine(page);
            
            if (page == 0)
            {
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

                SearchItem a = new SearchItem("", "", "",0,50, 0, 300, 0);
            }
            else
            {
                List<Book> boo = Search.SearchMain(SearchItem.Genre,SearchItem.Title,SearchItem.Author,SearchItem.MinPrice,SearchItem.MaxPrice,SearchItem.MinPages,SearchItem.MaxPages,SearchItem.Year);
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
            }

            Console.WriteLine("9444444444444444444");

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

           
            SearchItem a = new SearchItem(genre, title, author, minprice, maxprice, minpages, maxpages, year);




            return View(model);
        }
    }
}
