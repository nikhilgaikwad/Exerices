using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Message
{
    [Expires(60)]
    [Message]
    public class Request
    {
        [Encrypted]
        public string SaySomething { get; set; }
    }


    [AttributeUsage(AttributeTargets.Class)]
    public sealed class ExpiresAttribute : Attribute
    {
        public ExpiresAttribute(int expiresAfterSeconds) { ExpiresAfter = TimeSpan.FromSeconds(expiresAfterSeconds); }
        public TimeSpan ExpiresAfter { get; private set; }
    }
}
