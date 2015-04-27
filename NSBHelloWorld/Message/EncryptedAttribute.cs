using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Message
{
    [AttributeUsage(AttributeTargets.Property)]
    class EncryptedAttribute : Attribute
    {
    }
}
