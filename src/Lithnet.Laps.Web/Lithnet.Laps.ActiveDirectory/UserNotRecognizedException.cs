using System;

namespace Lithnet.Laps.ActiveDirectory
{
    public class UserNotRecognizedException: Exception
    {
        public UserNotRecognizedException() : base()
        {
        }

        public UserNotRecognizedException(string message) : base(message)
        {
        }
    }
}
