using webapi.Contracts.Services;

namespace webapi.BackgroundServices
{
    public class SubscriberBackgroundService : BackgroundService
    {
        private readonly ISubService _subService;

        public SubscriberBackgroundService(ISubService subService)
        {
            _subService = subService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await _subService.Receive();
            }
        }
    }
}
