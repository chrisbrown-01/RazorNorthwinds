using MediatR;
using RazorNorthwinds.Data;
using RazorNorthwinds.Mediatr.Notifications;

namespace RazorNorthwinds.Mediatr.Handlers
{
    public class CacheInvalidationHandler : INotificationHandler<CustomerRegionUpdatedNotification>
    {
        private readonly NorthwindsDbRepo _db;

        public CacheInvalidationHandler(NorthwindsDbRepo db)
        {
            _db = db;
        }

        public async Task Handle(CustomerRegionUpdatedNotification notification, CancellationToken cancellationToken)
        {
            await _db.EventOccurred(notification.Customer, "CACHE_N");
        }
    }
}