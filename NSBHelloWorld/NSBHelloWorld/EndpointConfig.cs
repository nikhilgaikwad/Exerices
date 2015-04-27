
using System.Linq;

namespace NSBHelloWorld
{
    using Message;
    using NServiceBus;
    using NServiceBus.Log4Net;
    using NServiceBus.Logging;
    using NServiceBus.Persistence;
    using System;

    /*
		This class configures this endpoint as a Server. More information about how to configure the NServiceBus host
		can be found here: http://particular.net/articles/the-nservicebus-host
	*/
    public class EndpointConfig : IConfigureThisEndpoint, AsA_Client
    {
        public void Customize(BusConfiguration configuration)
        {
            configuration.UseSerialization<XmlSerializer>() .Namespace("http://acme.com/");

            configuration.Conventions().DefiningMessagesAs(t => t.Assembly == typeof(Request).Assembly && t.Name.EndsWith("Message"));

            //configuration.Conventions().DefiningMessagesAs(t => t.Assembly == typeof(RequestMessage).Assembly && t.Name.EndsWith("Message")).DefiningTimeToBeReceivedAs(GetExpiration);

            log4net.Config.XmlConfigurator.Configure(); LogManager.Use<Log4NetFactory>();

            configuration.UsePersistence<RavenDBPersistence>();

            configuration.RijndaelEncryptionService();
        }

        //private static TimeSpan GetExpiration(Type type)
        //{
        //    dynamic expiresAttribute = type.GetCustomAttributes(true).SingleOrDefault(t => t.GetType().Name == "ExpiresAttribute"); return expiresAttribute == null ? TimeSpan.MaxValue : expiresAttribute.ExpiresAfter;
        //}

        public void Start()
        {
            LogManager.GetLogger("EndpointConfig").Info("Hello Distributed World!");
        }

        public void Stop()
        {
        }
    }
}
