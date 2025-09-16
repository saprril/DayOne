namespace Day5Delegates
{
    public delegate void SendNotification(User user, string message);

    public static class Notify
    {
        public static void SendPushNotification(User user, string message)
        {
            Console.WriteLine($"MSG: '{message}' sent to {user.Username} via push notification");
        }
        public static void SendSMSNotification(User user, string message)
        {
            Console.WriteLine($"MSG: '{message}' sent to {user.Username} via SMS {user.PhoneNumber}");
        }
        public static void SendEmailNotification(User user, string message)
        {
            Console.WriteLine($"MSG: '{message}' sent to {user.Username} via SMS {user.Email}");
        }
    }

}