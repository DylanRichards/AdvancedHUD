using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvancedHUD.Models
{
    public class HUD
    {
        public string test = "HELLO?";
        public Queue<Notification> notifications = new Queue<Notification>();

        public HUD()
        {
            Notification notification1 = new Notification() { content = "TEST 1" };
            Notification notification2 = new Notification() { content = "TEST 2" };

            AddNotification(notification1);
            AddNotification(notification2);
        }

        public void AddNotification(Notification notification)
        {
            notifications.Enqueue(notification);
        }

    }
}
