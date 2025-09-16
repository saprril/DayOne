using System.Security.Cryptography.X509Certificates;

namespace Day5Delegates
{
    class Program
    {
        SendNotification? sendNotifDelegate;
        static void Main(string[] args)
        {
            User user1 = new User("hsakjb", "aaa@mail.com", "111");
            User user2 = new User("asakjk", "b@mail.com", "14045");

            List<User> userLists = new List<User> { user1, user2 };



            foreach (User item in userLists)
            {

            }
        }
    }
}