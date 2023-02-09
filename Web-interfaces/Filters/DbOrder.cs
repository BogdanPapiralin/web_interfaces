using System.Net;
using Web_interfaces.Data;


namespace Web_interfaces.Filters
{
    public class DbOrder
    {
        public static void AddOrder(int idd,int idd2)
        {
            using (var context = new BookContext())
            {
                List<Book> books = Search.Searchid(idd);
                
                var order = new Order
                {
                    UserId = idd2,
                    BookId = books[0].BookId,
                    Quantity = 1,
                    TotalPrice = books[0].Price,
                    Status = 0,
                    CreatedAt = DateTime.Now
                };
                context.Orders.Add(order);
                context.SaveChanges();
            }
        }
        public static void AddToOrder(int idd, int idd2)
        {
            using (var context = new BookContext())
            {
                List<Order> orderss = DbOrder.Searchid1(idd,idd2);
                var orderToEdit = context.Orders.Find(orderss[0].OrderId);
                if (orderToEdit != null)
                {
                    orderToEdit.Quantity = orderss[0].Quantity+1;
                    orderToEdit.TotalPrice = orderss[0].TotalPrice + orderss[0].TotalPrice / orderss[0].Quantity;
                    context.SaveChanges();
                }
                

                context.SaveChanges();
            }
        }




        public static bool Searchid(int Id, int Id2)
        {
            using (var context = new BookContext())
            {

                var books = context.Orders
                    .Where(b => b.BookId == Id && b.UserId == Id2)
                    .ToList();
                try { if(books[0].Status == 0) { return true;}else return false; }
                catch { return false; }
                

            }

        }


        public static List<Order> Searchid1(int Id, int Id2)
        {
            using (var context = new BookContext())
            {

                var books = context.Orders
                    .Where(b => b.BookId == Id && b.UserId == Id2)
                    .ToList();
                return books; 

            }

        }





        public static List<Order> SearchStutus(int stat)
        {
            using (var context = new BookContext())
            {

                var ord = context.Orders
                    .Where(b => b.Status == stat)
                    .ToList();
                return ord;

            }

        }


        public static void DelOrd(int Id)
        {
            using (var context = new BookContext())
            {
                var orderToDelete = context.Orders.Find(Id);
                context.Orders.Remove(orderToDelete);
                context.SaveChanges();
            }

        }
    }
}
