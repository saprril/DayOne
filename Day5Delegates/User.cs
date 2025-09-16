namespace Day5Delegates
{
    public enum PreferredNotification : byte
    {
        None = 0, //000
        Push = 1 << 0, //001
        SMS = 1 << 1, //010
        Email = 1 << 2 //100
    }


    public class User
    {

        public string? Username { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public PreferredNotification Settings { get; set; }

        public User(string username, string mail, string number)
        {
            Settings |= PreferredNotification.Push;
            Username = username;
            Email = mail;
            PhoneNumber = number;
        }

        public void SetEmailNotification()
        {
            if (Email != null)
            {
                Settings |= PreferredNotification.Email;
            }
        }

        public void SetSMSNotification()
        {
            if (PhoneNumber != null)
            {
                Settings |= PreferredNotification.SMS;
            }
        }

        public void TurnOffNotification()
        {
            Settings = PreferredNotification.None;
        }
    }
}