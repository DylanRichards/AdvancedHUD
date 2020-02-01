using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvancedHUD.Models
{
    public class HUD
    {
        public Queue<Notification> notifications = new Queue<Notification>();
        public Dictionary<string, string> alerts = new Dictionary<string, string>();

        public HUD()
        {
            alerts.Add(Constants.LEFT_CAR, "none");
            alerts.Add(Constants.RIGHT_CAR, "none");
        }

        public void AddNotification(Notification notification)
        {
            notifications.Enqueue(notification);
        }

        public void RemoveExtraNotification()
        {
            if(notifications.Count > 4)
            {
                notifications.Dequeue();
            }
            
        }

    }
}
