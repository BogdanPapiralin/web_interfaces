using Web_interfaces.Data;
using System.Linq;
namespace Web_interfaces.Filters
{
    public class DbUser
    {
        public static void AddUser(string userName, string password)
        {
                using (var context = new  BookContext())
            {
                var user = new User
                {
                    UserName = userName,
                    Password = password,
                    Rights = 0
                };
                context.Users.Add(user);
                context.SaveChanges();
            }
        }

        public static bool SearchUser(string userName, string password)
        {
            using (var context = new BookContext())
            {
                var user = context.Users.FirstOrDefault(u => u.UserName == userName && u.Password == password);
                if (user != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
