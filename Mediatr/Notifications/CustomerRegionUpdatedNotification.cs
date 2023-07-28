using MediatR;
using RazorNorthwinds.Models;

namespace RazorNorthwinds.Mediatr.Notifications
{
    public record CustomerRegionUpdatedNotification(Customer Customer) : INotification;
}