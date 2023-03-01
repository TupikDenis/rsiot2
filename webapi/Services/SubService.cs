using Google.Cloud.PubSub.V1;
using webapi.Contracts.Services;

namespace webapi.Services
{
    public class SubService : ISubService
    {
        private readonly SubscriptionName _subscription;
        private SubscriberClient _subscriber;
        public SubService(IConfiguration configuration)
        {
            var pubSubSection = configuration.GetSection("PubSub");
            var projectId = pubSubSection.GetSection("ProjectId").Value;
            var subscriptionId = pubSubSection.GetSection("SubscriptionId").Value;
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", "C:\\Users\\scota\\Downloads\\prime-well-379208-552681bf7438.json");
            _subscription = new SubscriptionName(projectId, subscriptionId);
        }

        public async Task<string> Receive()
        {
            _subscriber = SubscriberClient.Create(_subscription);
            var receivedMessages = new List<PubsubMessage>();
            await _subscriber.StartAsync((msg, token) =>
            {
                receivedMessages.Add(msg);
                Console.WriteLine($"Received message {msg.MessageId} published at {msg.PublishTime.ToDateTime()}");
                Console.WriteLine($"Text: '{msg.Data.ToStringUtf8()}'");
                _subscriber.StopAsync(TimeSpan.FromSeconds(15));
                return Task.FromResult(SubscriberClient.Reply.Ack);
            });
            return receivedMessages.Single().Data.ToStringUtf8();
        }
    }
}
