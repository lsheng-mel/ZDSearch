using System;
using System.Collections.Generic;

namespace ZendeskSearch.Model
{
    public class Organization : Searchable
    {
        public long _Id { get; set; }
        public string Url { get; set; }
        public Guid External_id { get; set; }
        public string Name { get; set; }
        public IEnumerable<string> Domain_names { get; set; }
        public DateTime Created_at { get; set; }
        public string Details { get; set; }
        public bool Shared_tickets { get; set; }
        public IEnumerable<string> Tags { get; set; }
    }
}