using System.Collections.Generic;

namespace Benetton.Classes
{
    public class DatabaseMessage
    {
        static readonly List<string> messages = new List<string>
            {
                "Record Inserted Successfully",
                "Record Updated Successfully",
                "Record Deleted Successfully"
            };

        public List<string> Messages()
        {
            return messages;
        }

        public static bool ContainMessage(string msg)
        {
            bool check = false || messages.Contains(msg);
            return check;
        }

    }
}