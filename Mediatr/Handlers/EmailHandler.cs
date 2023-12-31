﻿using MediatR;
using RazorNorthwinds.Data;
using RazorNorthwinds.Mediatr.Notifications;

namespace RazorNorthwinds.Mediatr.Handlers
{
    public class EmailHandler : INotificationHandler<CustomerRegionUpdatedNotification>
    {
        private readonly INorthwindsDbRepo _db;

        public EmailHandler(INorthwindsDbRepo db)
        {
            _db = db;
        }

        public async Task Handle(CustomerRegionUpdatedNotification notification, CancellationToken cancellationToken)
        {
            await _db.EventOccurred(notification.Customer, "EMAIL_N");
        }
    }
}