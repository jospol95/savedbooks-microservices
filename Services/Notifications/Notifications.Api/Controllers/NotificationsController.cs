using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Notifications.Api.Contracts;
using Notifications.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Notifications.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationsController : ControllerBase
    {
        //The idea is to subscribe this service to a RabbitMQ, so everytime an event gets pushed, we send a notification.
        private readonly IEmailService _emailService;
        public NotificationsController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        [HttpPost]
        public Task SendNotifications(IEnumerable<Notification> notifications)
        {
            foreach(var notification in notifications)
            {
                _emailService.SendEmailNotification(notification);
            }
            return Task.CompletedTask;
        }
    }
}
