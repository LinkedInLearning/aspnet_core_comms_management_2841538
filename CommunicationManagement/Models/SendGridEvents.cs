using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommunicationManagement.Models
{
    public class SendGridEvents
    {
        public string email { get; set; }
        public long timestamp { get; set; }
        public string @event { get; set; }
        [JsonProperty("smtp-id")]
        public string smtp_id { get; set; }
        public string useragent { get; set; }
        public string ip { get; set; }
        public string sg_event_id { get; set; }
        public string sg_message_id { get; set; }
        public string reason { get; set; }
        public string status { get; set; }
        public string response { get; set; }
        public string tls { get; set; }
        public Uri url { get; set; }
        public string urloffset { get; set; }
        public string attempt { get; set; }
        public string category { get; set; }
        public string type { get; set; }
    }
}
