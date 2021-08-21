using System;

namespace SpookVooper.Api.Forums
{
    public class Notification
    {
        // Types ex: "Comment", "Post", "Message"
        public string Type { get; }

        // Title of notification
        public string Title { get; }

        // Content of notification
        public string Content { get; }

        // ulong source for backlinking
        public ulong Source { get; }

        // Optional author of notification
        public string Author { get; }

        // Target of notification
        public string Target { get; }

        // Link for notification
        public string Linkback { get; }

        // Time sent the notification
        public DateTime TimeSent { get; }

        // If the notification has been seen
        public bool Seen { get; }

        // Unique ID
        public string NotificationID { get; }
    }
}
