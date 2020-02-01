using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvancedHUD.Models
{
    public class HUD
    {
        public Queue<Notification> notifications = new Queue<Notification>();

        public HUD()
        {
        }

        public void AddNotification(Notification notification)
        {
            notifications.Enqueue(notification);
        }

    }
}
