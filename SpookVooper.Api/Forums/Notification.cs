using System;
using System.Collections.Generic;
using System.Text;

namespace SpookVooper.Api.Forums
{
    public class Notification
    {
        // Types ex: "Comment", "Post", "Message"
        public string Type { get; set; }

        // Title of notification
        public string Title { get; set; }

        // Content of notification
        public string Content { get; set; }

        // ulong source for backlinking
        public ulong Source { get; set; }

        // Optional author of notification
        public string Author { get; set; }

        // Target of notification
        public string Target { get; set; }

        // Link for notification
        public string Linkback { get; set; }

        // Time sent the notification
        public DateTime TimeSent { get; set; }

        // If the notification has been seen
        public bool Seen { get; set; }

        // Unique ID
        public string NotificationID { get; set; }
    }
}
