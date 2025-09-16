using System.Security.Cryptography.X509Certificates;

namespace Day5Delegates
{
    class Program
    {
        delegate object ObjectRetriever();
        delegate void StringAction(string s);
        static void Main(string[] args)
        {
            User user1 = new User("hsakjb", "aaa@mail.com", "111");
            User user2 = new User("asakjk", "b@mail.com", "14045");
            SendNotification SendPushOnly = Notify.SendPushNotification;

            SendNotification MulticastNotification = Notify.SendPushNotification;
            MulticastNotification += Notify.SendEmailNotification;

            List<User> userLists = new List<User> { user1, user2 };



            foreach (User item in userLists)
            {
                SendPushOnly.Invoke(item, "Hello!");
            }

            foreach (User item in userLists)
            {
                MulticastNotification.Invoke(item, "Hello!");
            }

            // Contravariance Example
            void ActOnObject(object variable) => Console.WriteLine(variable.ToString());

            StringAction contravariance = new StringAction(ActOnObject); // Legal:

            contravariance("What");

            // Covariance Example
            string RetrieveString() => "hello";

            ObjectRetriever covariance = new ObjectRetriever(RetrieveString); // Legal: object (more general) can receive string (more specific)
            object result = covariance();

            Console.WriteLine(result);
        }
    }
}