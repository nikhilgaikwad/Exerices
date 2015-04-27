using Message;
using NServiceBus.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorldServer
{
    class RequestHandler
    {
        public void Handle(RequestMessage message)
        {
            LogManager.GetLogger("RequestHandler").Info(message.SaySomething);
        }
    }
}
