namespace NSBServer
{
    using Messages;
    using NServiceBus;
    using NServiceBus.Persistence;
    
    public class EndpointConfig : IConfigureThisEndpoint, AsA_Server
    {
        public void Customize(BusConfiguration configuration)
        {
            configuration.UseSerialization<XmlSerializer>().Namespace("http://acme.com/");
            configuration.Conventions().DefiningMessagesAs(t => t.Assembly == typeof(RequestMessage).Assembly && t.Name.EndsWith("Message"));
            configuration.UsePersistence<RavenDBPersistence>();
        }
    }
}