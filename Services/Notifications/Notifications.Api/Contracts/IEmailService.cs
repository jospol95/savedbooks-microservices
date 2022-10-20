using Notifications.Api.Models;

namespace Notifications.Api.Contracts
{
    public interface IEmailService
    {
        void SendEmailNotification(Notification notification);
    }
}
