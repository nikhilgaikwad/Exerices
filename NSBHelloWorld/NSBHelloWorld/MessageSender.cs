using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Message;
using NServiceBus;
using NServiceBus.Logging;

namespace NSBHelloWorld
{
    public class MessageSender
    {
        public IBus Bus { get; set; }

        public void Start()
        {
            var message = new Request {SaySomething = "Say something..."};
            Bus.Send("helloWorldServer", message);

            LogManager.GetLogger("MessageSender").Info("Message Send...");
        }

        public void Run()
        {
            Bus.OutgoingHeaders["user"] = "udi";
            var message = new Request { SaySomething = "Say something" };
            Bus.Send(message);
            LogManager.GetLogger("MessageSender").Info("Sent message.");
        }

        public void Stop()
        {   
        }
    }
}
