using System;
using System.Collections.Generic;

namespace ZendeskSearch.Model
{
    public class Ticket : Searchable
    {
        public Guid _Id { get; set; }
        public string Url { get; set; }
        public Guid External_id { get; set; }
        public DateTime Created_at { get; set; }
        public string Type { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public string Priority { get; set; }
        public string Status { get; set; }
        public long Submitter_id { get; set; }
        public long Assignee_id { get; set; }
        public long Organization_id { get; set; }
        public IEnumerable<string> Tags { get; set; }
        public bool Has_incidents { get; set; }
        public DateTime Due_at { get; set; }
        public string Via { get; set; }
    }
}