using System;
using System.Collections.Generic;

namespace ZendeskSearch.Model
{
    public class User : Searchable
    {
        public long _Id { get; set; }
        public string Url { get; set; }
        public Guid External_id { get; set; }
        public string Name { get; set; }
        public string Alias { get; set; }
        public DateTime Created_at { get; set; }
        public bool Active { get; set; }
        public bool Verified { get; set; }
        public bool Shared { get; set; }
        public string Locale { get; set; }
        public string Timezone { get; set; }
        public DateTime Last_login_at { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Signature { get; set; }
        public long Organization_id { get; set; }
        public IEnumerable<string> Tags { get; set; }
        public bool Suspended { get; set; }
        public string Role { get; set; }
        
        public override void Print()
        {
            throw new NotImplementedException();
        }
    }
}